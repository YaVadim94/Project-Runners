﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.RabbitMQ;
using Project_Runners.Application.RabbitMQ.Models;
using Project_Runners.Application.Runs.Models;
using Project_Runners.Application.Runs.Models.Commands;
using Project_Runners.Application.Runs.Models.Dto;
using Project_Runners.Data;
using Project_Runners.Data.Enums;

namespace Project_Runners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчить команды на обновление очереди прогона
    /// </summary>
    public class UpdateRunQueueCommandHandler : IRequestHandler<UpdateRunQueueCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageBusService _messageBusService;

        public UpdateRunQueueCommandHandler(DataContext context, IMessageBusService messageBusService, IMapper mapper)
        {
            _context = context;
            _messageBusService = messageBusService;
            _mapper = mapper;
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

            var runFailed = casesWithResults
                .Any(cwr => cwr.CaseResults.Any(result => result.Status == RunStatus.Successed)
                            || cwr.CaseResults.Count() >= 3);

            if (runFailed)
            {
                run.Status = RunStatus.Failed;
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            
            SendCasesToQueue(casesWithResults, run.Id);
            return Unit.Value;
        }

        private void SendCasesToQueue(IEnumerable<CaseWithResults> casesWithResults, long runId)
        {
            var casesToSend = casesWithResults
                .Where(cwr => cwr.CaseResults.All(result => result.Status != RunStatus.Successed)
                              && cwr.CaseResults.Count() < 3)
                .Select(cwr => cwr.Case);

            foreach (var caseToSend in casesToSend)
            {
                var dto = _mapper.Map<CaseForRunningDto>(caseToSend);
                dto.RunId = runId;
                
                _messageBusService.Publish(new MessageDto{Body = dto});
            }
        }
    }
}