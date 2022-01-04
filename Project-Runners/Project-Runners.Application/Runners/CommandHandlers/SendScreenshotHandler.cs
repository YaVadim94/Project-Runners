using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Services.Publishing;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик отправки скирна на фронт
    /// </summary>
    public class SendScreenshotHandler : IRequestHandler<SendScreenShotCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHubPublishingService _hubPublishingService;
        
        public SendScreenshotHandler(DataContext context, IMapper mapper, IHubPublishingService hubPublishingService)
        {
            _context = context;
            _mapper = mapper;
            _hubPublishingService = hubPublishingService;
        }

        /// <summary>
        /// Отправить скрин на фронт
        /// </summary>
        public async Task<Unit> Handle(SendScreenShotCommand request, CancellationToken cancellationToken)
        {
            var runner = await _context.Runners.GetById(request.RunnerId);
            
            var publishDto = _mapper.Map<RunnerPublishDto>(runner);

            publishDto.Screenshot = request.Payload;
            
            _hubPublishingService.Publish(publishDto);
            
            return Unit.Value;
        }
    }
}