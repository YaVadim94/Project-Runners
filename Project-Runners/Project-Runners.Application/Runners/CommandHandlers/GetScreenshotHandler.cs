﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectRunners.Application.Extensions;
using ProjectRunners.Application.RabbitMQ;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Common.Enums;
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
        private readonly IMessageBusService _messageBusService;

        public GetScreenshotHandler(IMessageBusService messageBusService, DataContext context)
        {
            _messageBusService = messageBusService;
            _context = context;
        }

        /// <summary>
        /// Отправить скриншот
        /// </summary>
        public async Task<Unit> Handle(GetScreenshotCommand request, CancellationToken cancellationToken)
        {
            var runner = await _context.Runners.GetById(request.Id);

            var dto = new MessageDto {Command = Command.Screenshot};

            _messageBusService.Publish(dto, runner.Name);
            
            return Unit.Value;
        }
    }
}