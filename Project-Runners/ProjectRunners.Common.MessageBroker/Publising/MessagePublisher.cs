using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjectRunners.Common.MessageBroker.Extensions;
using ProjectRunners.Common.MessageBroker.Models;
using RabbitMQ.Client;

namespace ProjectRunners.Common.MessageBroker.Publising
{
    /// <summary>
    /// Отправитель сообщений по шине
    /// </summary>
    public class MessagePublisher : IMessagePublisher
    {
        private readonly RabbitMQConfig _config;
        private IModel _channel;
        private IConnection _connection;

        public MessagePublisher(IConfiguration configuration)
        {
            _config = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            TryToCreateConnection();
        }
        
        /// <summary>
        /// Опубликовать сообщение
        /// </summary>
        public void Publish<T>(T messageDto, DeliveringAddress address)
        {
            if (!_connection.IsOpen && TryToCreateConnection())
                return;
                
            _channel.ExchangeDeclare(
                exchange: address.Exchange,
                type: CommonConstants.DIRECT,
                durable: true,
                autoDelete: false,
                arguments: null);
            
            var json = JsonConvert.SerializeObject(messageDto);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(
                exchange: address.Exchange,
                routingKey: address.Queue,
                body: body);
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
            
            if(!_connection.IsOpen)
                Console.WriteLine("Не удалось подключиться к шине данных");
            
            return _connection.IsOpen;
        }
    }
}