using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Runners.Models.Commands;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик отправки скирна на фронт
    /// </summary>
    public class SendScreenshotHandler : IRequestHandler<SendScreenShotCommand>
    {
        /// <summary>
        /// Отправить скрин на фронт
        /// </summary>
        public Task<Unit> Handle(SendScreenShotCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}