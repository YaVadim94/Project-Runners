using System;
using System.Threading.Tasks;
using Project_Runners.Application.RabbitMQ.Models;

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
        void Publish(MessageDto message, string routingKey = "");
    }
}