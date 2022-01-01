using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.MessageBroker;
using ProjectRunners.Common.MessageBroker.Publishing;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик команды на отправку запроса состояния всех раннеров
    /// </summary>
    public class SendRequestForStateUpdatingHandler : IRequestHandler<SendRequestForStateUpdatingCommand>
    {
        private readonly DataContext _context;
        private readonly IMessagePublishService _messagePublishService;

        public SendRequestForStateUpdatingHandler(DataContext context, IMessagePublishService messagePublishService)
        {
            _context = context;
            _messagePublishService = messagePublishService;
        }

        /// <summary>
        /// Отправить команду на отправку состояния всех раннеров
        /// </summary>
        public async Task<Unit> Handle(SendRequestForStateUpdatingCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"----> Send State at {DateTime.Now.Second}");
            
            var runners = await _context.Runners.ToListAsync(cancellationToken);

            var message = new MessageDto {Command = Command.SendState};
            
            runners.ForEach(runner =>
            {
                _messagePublishService.Publish(message, $"runner_{runner.Id}");
            });
            
            return Unit.Value;
        }
    }
}