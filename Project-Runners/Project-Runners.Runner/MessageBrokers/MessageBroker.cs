using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Project_runners.Common.Enums;
using Project_runners.Common.Models;
using Project_Runners.Runner.APIs;
using Project_Runners.Runner.EventHandlers;
using Project_Runners.Runner.Models.Enums;
using Project_Runners.Runner.Services;
using RabbitMQ.Client.Events;
using Refit;

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
        protected override async Task Consume(MessageDto dto)
        {
            var handler = dto.Command switch
            {
                Command.RunCase => Runner.ServiceProvider.GetRequiredService<CaseHandler>(),
                _ => throw new ArgumentOutOfRangeException(nameof(dto.Command))
            };

            await handler.Handle(dto);
            Task.Delay(1000).GetAwaiter().GetResult();
        }

 
    }
}