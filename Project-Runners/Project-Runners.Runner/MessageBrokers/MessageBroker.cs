using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Runner.EventHandlers;
using ProjectRunners.Runner.Services;

namespace ProjectRunners.Runner.MessageBrokers
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
            IEventHandler handler = dto.Command switch
            {
                Command.RunCase => Runner.ServiceProvider.GetRequiredService<CaseEventHandleRest>(),
                Command.SendState => Runner.ServiceProvider.GetRequiredService<StateEventHandlerGrpc>(),
                Command.Screenshot => Runner.ServiceProvider.GetRequiredService<ScreenshotHandler>(),
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
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurs: {ex.Message}");
                Runner.ServiceProvider.GetRequiredService<StateService>().SetState(RunnerState.Waiting);
            }
        }
    }
}