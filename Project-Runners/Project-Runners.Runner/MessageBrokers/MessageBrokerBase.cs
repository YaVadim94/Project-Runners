using Microsoft.Extensions.Configuration;
using Project_runners.Common;
using Project_runners.Common.Models;
using Project_Runners.Runner.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Project_Runners.Runner.MessageBrokers
{
    /// <summary>
    /// Базовый класс брокера для работы с RabbitMq
    /// </summary>
    public abstract class MessageBrokerBase
    {
        private readonly RabbitMQConfig _config;
        private IModel _channel;
        private IConnection _connection;

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

            consumer.Received += ConsumeBase;

            _channel.BasicConsume(CommonConstants.QUEUE_NAME, false, consumer);
        }

        private void ConsumeBase(object obj, BasicDeliverEventArgs args)
        {
            Consume(obj, args);
            
            _channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
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
                CommonConstants.QUEUE_NAME,
                true,
                false,
                false,
                null);
        }
    }
}