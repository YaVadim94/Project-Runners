using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.RabbitMQ;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Data;

namespace ProjectRunners.Application.Runners.CommandHandlers
{
    /// <summary>
    /// Обработчик команды на отправку запроса состояния всех раннеров
    /// </summary>
    public class SendRequestForStateUpdatingCommandHandler : IRequestHandler<SendRequestForStateUpdatingCommand>
    {
        private readonly DataContext _context;
        private readonly IMessageBusService _messageBusService;

        public SendRequestForStateUpdatingCommandHandler(DataContext context, IMessageBusService messageBusService)
        {
            _context = context;
            _messageBusService = messageBusService;
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
                _messageBusService.Publish(message, runner.Name);
            });
            
            return Unit.Value;
        }
    }
}