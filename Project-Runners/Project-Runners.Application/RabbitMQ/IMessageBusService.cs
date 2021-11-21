namespace Project_Runners.Application.RabbitMQ
{
    /// <summary>
    /// Сервис дял работы с RabbitMQ
    /// </summary>
    public interface IMessageBusService
    {
        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        void Publish(object messageDto, string routingKey = "");
    }
}