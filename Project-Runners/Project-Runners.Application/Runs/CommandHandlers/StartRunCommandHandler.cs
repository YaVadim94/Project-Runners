using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Application.RabbitMQ;
using Project_Runners.Application.RabbitMQ.Models;
using Project_Runners.Application.Runs.Models.Commands;
using Project_Runners.Application.Runs.Models.Dto;
using Project_Runners.Data;
using Project_Runners.Data.Enums;

namespace Project_Runners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчик события запуска прогонов
    /// </summary>
    public class StartRunCommandHandler : IRequestHandler<StartRunCommand>
    {
        private readonly DataContext _context;
        private readonly IMessageBusService _messageBusService;
        private readonly IMapper _mapper;

        public StartRunCommandHandler(DataContext context, IMessageBusService messageBusService, IMapper mapper)
        {
            _context = context;
            _messageBusService = messageBusService;
            _mapper = mapper;
        }

        /// <summary>
        /// Запуск прогона
        /// </summary>
        public async Task<Unit> Handle(StartRunCommand request, CancellationToken cancellationToken)
        {
            var run = await _context.Runs
                          .Include(r => r.Cases).ThenInclude(rc => rc.Case)
                          .SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken: cancellationToken)
                      ?? throw new ArgumentException(nameof(request.Id));
            
            if(run.Status != RunStatus.NotStarted)
                return Unit.Value;

            run.Status = RunStatus.InProgress;
            Console.WriteLine($" -----> Run: \"{run.Name}\" has just started");

            foreach (var runCase in run.Cases.Select(x => x.Case))
            {
                var dto = _mapper.Map<CaseForRunningDto>(runCase);
                dto.RunId = run.Id;
                
                _messageBusService.Publish(new MessageDto{Body = dto});
            }
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}