using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.Runs.Models.Commands;
using Project_runners.Common.Enums;
using Project_Runners.Data;

namespace Project_Runners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчик события запуска прогонов
    /// </summary>
    public class StartRunCommandHandler : IRequestHandler<StartRunCommand>
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public StartRunCommandHandler(DataContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        /// <summary>
        /// Запуск прогона
        /// </summary>
        public async Task<Unit> Handle(StartRunCommand request, CancellationToken cancellationToken)
        {
            var run = await _context.Runs
                          .Include(r => r.Cases).ThenInclude(rc => rc.Case)
                          .GetById(request.Id);
            
            if(run.Status != RunStatus.NotStarted)
                return Unit.Value;

            run.Status = RunStatus.InProgress;
            Console.WriteLine($" -----> Run: \"{run.Name}\" has just started");

            await _context.SaveChangesAsync(cancellationToken);
            
            var updateRunQueueCommand = new UpdateRunQueueCommand {Id = run.Id};
            await _mediator.Send(updateRunQueueCommand, cancellationToken);

            return Unit.Value;
        }
    }
}