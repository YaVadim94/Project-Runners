using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project_Runners.Application.RabbitMQ.Models;
using Project_runners.Common.Models;
using RabbitMQ.Client;

namespace Project_Runners.Application.RabbitMQ
{
    /// <summary>
    /// Сервис дял работы с RabbitMQ
    /// </summary>
    public class MessageBusService : IMessageBusService
    {
        private readonly RabbitMQConfig _config;
        
        private IConnection _connection;
        private IModel _channel;

        private const string EXCHANGE_NAME = "direct-exchange";
        
        public MessageBusService(IConfiguration configuration)
        {
            _config = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            TryToCreateConnection();
        }


        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        public void Publish(MessageDto message, string routingKey = "")
        {
            if (!_connection.IsOpen && TryToCreateConnection())
                return;
                
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            _channel.BasicPublish(EXCHANGE_NAME, routingKey, body: body);
        }

        private bool TryToCreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _config.HostName,
                Port = _config.Port,
                UserName = _config.UserName,
                Password = _config.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: EXCHANGE_NAME, type: ExchangeType.Direct);

            if(!_connection.IsOpen)
                Console.WriteLine("Не удалось подключиться к шине данных");
            
            return _connection.IsOpen;
        }
    }
}