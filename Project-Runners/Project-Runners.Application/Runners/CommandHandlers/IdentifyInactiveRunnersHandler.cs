using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Common.Enums;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик события поика неактивных раннеров
    /// </summary>
    public class IdentifyInactiveRunnersHandler : IRequestHandler<IdentifyInactiveRunnersCommand>
    {
        private readonly DataContext _context;

        public IdentifyInactiveRunnersHandler(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Найти и изменить статус неактиынх раннеров
        /// </summary>
        public async Task<Unit> Handle(IdentifyInactiveRunnersCommand request, CancellationToken cancellationToken)
        {
            var inactiveRunners = await _context.Runners
                .Where(r => r.ChangeDate < DateTimeOffset.Now.AddMinutes(-2))
                .ToListAsync(cancellationToken);

            inactiveRunners.ForEach(ir => ir.State = RunnerState.Disconnected);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}