using System;
using System.Text;
using Newtonsoft.Json;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.MessageBroker.Publising;
using RabbitMQ.Client;

namespace ProjectRunners.Common.MessageBroker.Publishing
{
    /// <summary>
    /// Отправитель сообщений по шине
    /// </summary>
    public class MessagePublisher : IMessagePublisher
    {
        private readonly RabbitMQConfig _config;
        private IModel _channel;
        private IConnection _connection;

        public MessagePublisher(RabbitMQConfig config)
        {
            _config = config;

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
                address.Exchange,
                CommonConstants.DIRECT,
                true,
                false,
                null);

            var json = JsonConvert.SerializeObject(messageDto);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(
                address.Exchange,
                address.Queue,
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

            if (!_connection.IsOpen)
                Console.WriteLine("Не удалось подключиться к шине данных");

            return _connection.IsOpen;
        }
    }
}