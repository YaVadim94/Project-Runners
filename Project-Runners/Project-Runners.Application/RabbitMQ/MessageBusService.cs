using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project_runners.Common;
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

        public MessageBusService(IConfiguration configuration)
        {
            _config = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            TryToCreateConnection();
        }


        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        public void Publish(object messageDto, string routingKey = "")
        {
            if (!_connection.IsOpen && TryToCreateConnection())
                return;
                
            var json = JsonConvert.SerializeObject(messageDto);
            var body = Encoding.UTF8.GetBytes(json);
            
            _channel.BasicPublish(string.Empty, routingKey: CommonConstants.QUEUE_NAME, body: body);
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

            _channel.QueueDeclare(
                queue: CommonConstants.QUEUE_NAME,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            
            if(!_connection.IsOpen)
                Console.WriteLine("Не удалось подключиться к шине данных");
            
            return _connection.IsOpen;
        }
    }
}