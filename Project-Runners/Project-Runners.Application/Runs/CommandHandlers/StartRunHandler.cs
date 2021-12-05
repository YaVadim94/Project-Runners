using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Common.Enums;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчик события запуска прогонов
    /// </summary>
    public class StartRunHandler : IRequestHandler<StartRunCommand>
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public StartRunHandler(DataContext context, IMediator mediator)
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