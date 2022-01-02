using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Services.Publishing;
using ProjectRunners.Common.Enums;
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
        private readonly IRunnersPublishService _runnersPublishService;

        public SendRequestForStateUpdatingHandler(DataContext context, IRunnersPublishService runnersPublishService)
        {
            _context = context;
            _runnersPublishService = runnersPublishService;
        }

        /// <summary>
        /// Отправить команду на отправку состояния всех раннеров
        /// </summary>
        public async Task<Unit> Handle(SendRequestForStateUpdatingCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"----> Send State at {DateTime.Now.Second}");
            
            var runners = await _context.Runners.ToListAsync(cancellationToken);

            var message = new RunnerCommandDto {Command = Command.SendState};
            
            runners.ForEach(runner =>
            {
                _runnersPublishService.Publish(message, runner.Id);
            });
            
            return Unit.Value;
        }
    }
}