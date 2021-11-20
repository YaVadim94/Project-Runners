using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project_Runners.Application.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Project_Runners.Application.RabbitMQ
{
    /// <summary>
    /// Сервис дял работы с RabbitMQ
    /// </summary>
    public class MessageBusService : IMessageBusService
    {
        private IConnection _connection;
        private IModel _channel;

        private const string EXCHANGE_NAME = "direct-exchange";
        
        public MessageBusService(IConfiguration configuration)
        {
            var config = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();
            
            var factory = new ConnectionFactory
            {
                HostName = config.HostName,
                Port = config.Port,
                UserName = config.UserName,
                Password = config.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: EXCHANGE_NAME, type: ExchangeType.Direct);
        }


        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        public void Publish(MessageDto message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            _channel.BasicPublish(EXCHANGE_NAME, routingKey: string.Empty, body: body);
        }
    }
}