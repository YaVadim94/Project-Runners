using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.RabbitMQ;
using ProjectRunners.Application.Runners.Models.Queries;
using ProjectRunners.Application.Runs.Models;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчить команды на обновление очереди прогона
    /// </summary>
    public class UpdateRunQueueHandler : IRequestHandler<UpdateRunQueueCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageBusService _messageBusService;
        private readonly IMediator _mediator;

        public UpdateRunQueueHandler(DataContext context, IMessageBusService messageBusService,
            IMapper mapper, IMediator mediator)
        {
            _context = context;
            _messageBusService = messageBusService;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Обновить очередь прогона
        /// </summary>
        public async Task<Unit> Handle(UpdateRunQueueCommand request, CancellationToken cancellationToken)
        {
            var run = await _context.Runs
                .Include(r => r.Cases).ThenInclude(rc => rc.Case)
                .Include(r => r.CaseResults)
                .GetById(request.Id);

            var casesWithResults = run.Cases.GroupJoin(run.CaseResults,
                c => c.CaseId, result => result.CaseId,
                (c, results) => new CaseWithResults{Case = c.Case, CaseResults = results})
                .ToList();

            var status = GetStatus(casesWithResults);

            switch (status)
            {
                case RunStatus.Successed:
                case RunStatus.Failed:
                    run.Status = status;
                    await _context.SaveChangesAsync(cancellationToken);
                    Console.WriteLine($"---> Run finished: {run.Name}");
                    return Unit.Value;
                
                case RunStatus.InProgress:
                    await  SendCasesToQueue(casesWithResults, run.Id);
                    Console.WriteLine($"---> Run queue has been updated: {run.Name}");
                    return Unit.Value;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(status));
            }
        }

        private static RunStatus GetStatus(ICollection<CaseWithResults> casesWithResults)
        {
            var runFailed = casesWithResults
                .All(cwr => cwr.CaseResults.Any()
                    && cwr.CaseResults.All(result => result.Status == RunStatus.Failed)
                    && cwr.CaseResults.Count() >= 3);

            var runSucceeded = casesWithResults
                .All(cwr => cwr.CaseResults.Any(result => result.Status == RunStatus.Successed)
                    && cwr.CaseResults.Count() <= 3);

            return casesWithResults switch
            {
                { } when runFailed => RunStatus.Failed,
                { } when runSucceeded => RunStatus.Successed,
                _ => RunStatus.InProgress
            };
        }
        
        private async Task SendCasesToQueue(IEnumerable<CaseWithResults> casesWithResults, long runId)
        {
            var casesToSend = casesWithResults
                .Where(cwr => cwr.CaseResults.All(result => result.Status != RunStatus.Successed)
                              && cwr.CaseResults.Count() < 3)
                .Select(cwr => cwr.Case)
                .ToList();

            if(!casesToSend.Any())
                return;

            var availableRunnerNames = await GetAvailableRunnerNamesQueue();

            foreach (var caseToSend in casesToSend)
            {
                if (!availableRunnerNames.Any())
                    break;
                
                var dto = new MessageDto
                {
                    Command = Command.RunCase,
                    Case = _mapper.Map<CaseForRunningDto>(caseToSend, opt =>
                        opt.AfterMap((s, d) => { d.RunId = runId; }))
                };
                
                _messageBusService.Publish(dto, availableRunnerNames.Dequeue());
            }
        }

        private async Task<Queue<string>> GetAvailableRunnerNamesQueue()
        {
            var availableRunners = await _mediator.Send(new GetAllRunnersQuery
            {
                Filter = r => r.State == RunnerState.Waiting
            });

            return new Queue<string>(availableRunners.Select(r => r.Name));
        }
    }
}