using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Services.Publishing;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.MessageBroker;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик события создания скриншота
    /// </summary>
    public class GetScreenshotHandler : IRequestHandler<GetScreenshotCommand>
    {
        private readonly DataContext _context;
        private readonly IRunnersPublishService _runnersPublishService;


        public GetScreenshotHandler(DataContext context, IRunnersPublishService runnersPublishService)
        {
            _context = context;
            _runnersPublishService = runnersPublishService;
        }

        /// <summary>
        /// Отправить скриншот
        /// </summary>
        public async Task<Unit> Handle(GetScreenshotCommand request, CancellationToken cancellationToken)
        {
            var dto = new RunnerCommandDto {Command = Command.Screenshot};

            _runnersPublishService.Publish(dto, request.RunnerId);
            
            return Unit.Value;
        }
    }
}