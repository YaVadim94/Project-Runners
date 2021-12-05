using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Data.Mediator.Commands;
using ProjectRunners.Data.Models.Bases;

namespace ProjectRunners.Data.Mediator.Handlers
{
    /// <summary>
    /// Обработчик события простановки времени последнего изменения
    /// </summary>
    public class SetChangeDateHandler : IRequestHandler<SetChangeDateCommand>
    {
        private readonly DataContext _context;

        public SetChangeDateHandler(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Проставить время последнего изменения у сущностей
        /// </summary>
        public Task<Unit> Handle(SetChangeDateCommand request, CancellationToken cancellationToken)
        {
            var trackedEntities = _context.ChangeTracker.Entries<EntityBase>();

            foreach (var entityEntry in trackedEntities)
                entityEntry.Entity.ChangeDate = DateTimeOffset.Now;

            return Unit.Task;
        }
    }
}