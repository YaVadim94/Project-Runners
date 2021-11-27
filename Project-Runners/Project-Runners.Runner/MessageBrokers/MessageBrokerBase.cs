using System;
using System.Threading.Tasks;
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
        protected abstract Task Consume(object obj, BasicDeliverEventArgs args);

        public async Task Subscribe()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += ConsumeBase;

            _channel.BasicConsume(CommonConstants.DIRECT_QUEUE, false, consumer);

            Console.WriteLine("Subscribed");
        }

        private async Task ConsumeBase(object obj, BasicDeliverEventArgs args)
        {
            try
            {
                await Consume(obj, args);
                
                _channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        
        private void OpenConnection()
        {
            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось подключиться к шине данных: {ex.Message}");
                Task.Delay(TimeSpan.FromSeconds(10)).GetAwaiter().GetResult();
            }
            finally
            {
                if (_channel.IsClosed)
                    Connect();
            }
        }

        private void Connect()
        {
            var factory = new ConnectionFactory
            {
                HostName = _config.HostName,
                Port = _config.Port,
                UserName = _config.UserName,
                Password = _config.Password,
                DispatchConsumersAsync = true
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: CommonConstants.DIRECT_QUEUE,
                durable: true,
                exclusive: false,
                autoDelete: true,
                arguments: null);

            _channel.QueueBind(
                queue: CommonConstants.DIRECT_QUEUE,
                exchange: CommonConstants.DIRECT_EXCHANGE,
                routingKey: CommonConstants.DIRECT_QUEUE,
                arguments: null);
        }
    }
}