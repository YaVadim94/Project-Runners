using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Application.RabbitMQ;
using Project_Runners.Application.Runs.Models.Commands;
using Project_Runners.Data;
using Project_Runners.Data.Enums;

namespace Project_Runners.Application.Runs.CommandHandlers
{
    /// <summary>
    /// Обработчик событий обновления состояния прогонов
    /// </summary>
    public class UpdateRunsCommandHandler : IRequestHandler<UpdateRunsCommand>
    {
        private readonly DataContext _context;
        private readonly IMessageBusService _messageBusService;

        public UpdateRunsCommandHandler(DataContext context, IMessageBusService messageBusService)
        {
            _context = context;
            _messageBusService = messageBusService;
        }

        /// <summary>
        /// Обновить состояние прогонов
        /// </summary>
        public async Task<Unit> Handle(UpdateRunsCommand request, CancellationToken cancellationToken)
        {
            var inProgressRuns = await _context.Runs
                .Where(r => r.Status == RunStatus.InProgress)
                .ToListAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}