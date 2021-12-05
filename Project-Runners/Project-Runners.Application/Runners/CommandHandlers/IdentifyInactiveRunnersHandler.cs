using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Runners.Models.Commands;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик события поика неактивных раннеров
    /// </summary>
    public class IdentifyInactiveRunnersHandler : IRequestHandler<IdentifyInactiveRunnersCommand>
    {
        /// <summary>
        /// Найти и изменить статус неактиынх раннеров
        /// </summary>
        public Task<Unit> Handle(IdentifyInactiveRunnersCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}