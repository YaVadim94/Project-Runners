using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_runners.Common.Enums;
using Project_runners.Common.Models;
using Project_Runners.Runner.EventHandlers;
using Project_Runners.Runner.Models.Enums;
using Project_Runners.Runner.Services;

namespace Project_Runners.Runner.MessageBrokers
{
    /// <summary>
    /// Брокер для работы с RabbitMq
    /// </summary>
    public class MessageBroker : MessageBrokerBase
    {
        public MessageBroker(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        protected override Task Consume(MessageDto dto)
        {
            var handler = dto.Command switch
            {
                Command.RunCase => Runner.ServiceProvider.GetRequiredService<CaseEventHandler>(),
                _ => throw new ArgumentOutOfRangeException(nameof(dto.Command))
            };

            Task.Run(() => HandleMessage(handler, dto));

            return Task.CompletedTask;
        }

        private static async Task HandleMessage(IEventHandler handler, MessageDto dto)
        {
            try
            {
                await handler.Handle(dto);
                Task.Delay(1000).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurs: {ex.Message}");
                Runner.ServiceProvider.GetRequiredService<StateService>().SetState(RunnerState.Waiting);
            }
        }
    }
}