using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Project_Runners.Hub.Hubs;
using ProjectRunners.Common;
using ProjectRunners.Common.MessageBroker.Consuming;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.Models.Dto;

namespace Project_Runners.Hub.Consumers
{
    /// <summary>
    /// Основной потребитель сообщений для отправки по хабу
    /// </summary>
    public class MainConsumer : MessageConsumerBase<RunnerPublishDto>
    {
        private readonly IHubContext<RunnersHub> _hubContext;

        public MainConsumer(RabbitMQConfig config, IHubContext<RunnersHub> hubContext) : base(config)
        {
            _hubContext = hubContext;
        }

        protected override string QueueName => CommonConstants.HUB_QUEUE;
        protected override string ExchangeName => CommonConstants.HUB_EXCHANGE;

        protected override async Task Consume(RunnerPublishDto dto)
        {
            await _hubContext.Clients.All.SendAsync($"{nameof(Consume)}", dto);
        }
    }
}