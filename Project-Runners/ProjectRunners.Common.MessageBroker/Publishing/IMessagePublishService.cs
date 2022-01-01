using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Common.MessageBroker.Publishing
{
    /// <summary>
    /// Сервис дял работы с RabbitMQ
    /// </summary>
    public interface IMessagePublishService
    {
        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        void Publish(MessageDto messageDto, string routingKey);
    }
}