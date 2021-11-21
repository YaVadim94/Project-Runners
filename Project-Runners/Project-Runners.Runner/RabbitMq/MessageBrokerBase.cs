using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Project_runners.Common;
using Project_Runners.Runner.Extensions;
using Project_Runners.Runner.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Project_Runners.Runner.RabbitMq
{
    /// <summary>
    /// Базовый класс брокера для работы с RabbitMq
    /// </summary>
    public abstract class MessageBrokerBase
    {
        private readonly RabbitMQConfig _config;
        private IConnection _connection;
        private IModel _channel;

        protected MessageBrokerBase(IConfiguration configuration)
        {
            _config = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();
            
            OpenConnection();
        }

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        protected abstract void Consume(object obj, BasicDeliverEventArgs args);
        
        public void Subscribe()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consume;
            
            _channel.BasicConsume(queue: CommonConstants.QUEUE_NAME, autoAck: false, consumer: consumer);
        }

        private void OpenConnection()
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
        }
    }
}