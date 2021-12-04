using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Project_runners.Common;
using Project_runners.Common.Models;
using Project_runners.Common.Models.Dto;
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
        protected abstract Task Consume(MessageDto message);

        public async Task Subscribe()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += ConsumeBase;

            _channel.BasicConsume(Runner.Name, false, consumer);

            Console.WriteLine("Subscribed");
        }

        private async Task ConsumeBase(object obj, BasicDeliverEventArgs args)
        {
            try
            {
                Console.WriteLine("Received a message");
                
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var dto = JsonConvert.DeserializeObject<MessageDto>(message);

                await Consume(dto);
                
                _channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurs: {ex.Message}");
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
                Console.WriteLine($"Could not connect to RabbitMQ: {ex.Message}");
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
                queue: Runner.Name,
                durable: true,
                exclusive: false,
                autoDelete: true,
                arguments: null);

            _channel.QueueBind(
                queue: Runner.Name,
                exchange: CommonConstants.DIRECT_EXCHANGE,
                routingKey: Runner.Name,
                arguments: null);
        }
    }
}