using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Common.Enums;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчик событий обновления состояния прогонов
    /// </summary>
    public class UpdateRunsQueueCommandHandler : IRequestHandler<UpdateRunsQueueCommand>
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public UpdateRunsQueueCommandHandler(DataContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        /// <summary>
        /// Обновить состояние прогонов
        /// </summary>
        public async Task<Unit> Handle(UpdateRunsQueueCommand request, CancellationToken cancellationToken)
        {
            var inProgressRunIds = await _context.Runs
                .Where(r => r.Status == RunStatus.InProgress)
                .Select(r => r.Id)
                .ToListAsync(cancellationToken);

            foreach (var id in inProgressRunIds)
            {
                var updateCommand = new UpdateRunQueueCommand {Id = id};
                await _mediator.Send(updateCommand, cancellationToken);
            }

            return Unit.Value;
        }
    }
}