using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project_Runners.Application.Extensions;
using Project_Runners.Application.Runners.Models.Commands;
using Project_Runners.Data;

namespace Project_Runners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик события обновления состояния раннера
    /// </summary>
    public class SetStateCommandHandler : IRequestHandler<SetStateCommand>
    {
        private readonly DataContext _context;

        public SetStateCommandHandler(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Обновить состония раннера
        /// </summary>
        public async Task<Unit> Handle(SetStateCommand request, CancellationToken cancellationToken)
        {
            var runner = await _context.Runners.GetById(request.RunnerId);

            runner.State = request.State;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}