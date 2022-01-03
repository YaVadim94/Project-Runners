using ProjectRunners.Common;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.MessageBroker.Publising;
using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Application.Services.Publishing
{
    /// <summary>
    /// Сервис для публикации сообщения по шине для хаба
    /// </summary>
    public class HubPublishingService : IHubPublishingService
    {
        private readonly IMessagePublisher _messagePublisher;

        public HubPublishingService(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        /// <summary>
        /// Отправить сообщение по хабу
        /// </summary>
        public void Publish(RunnerPublishDto dto)
        {
            var address = new DeliveringAddress(CommonConstants.HUB_EXCHANGE, CommonConstants.HUB_QUEUE);
            
            _messagePublisher.Publish(dto, address);
        }
    }
}