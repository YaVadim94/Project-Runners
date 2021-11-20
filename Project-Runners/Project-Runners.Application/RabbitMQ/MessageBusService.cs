using Microsoft.Extensions.Configuration;
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
            _channel.ExchangeDeclare(exchange: "direct-exchange", type: ExchangeType.Direct);
        }
    }
}