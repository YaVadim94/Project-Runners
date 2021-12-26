using ProjectRunners.Common.Models.Dto;

namespace ProjectRunners.Application.RabbitMQ
{
    /// <summary>
    /// Сервис дял работы с RabbitMQ
    /// </summary>
    public interface IMessageBusService
    {
        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        void Publish(MessageDto messageDto, string routingKey);
    }
}