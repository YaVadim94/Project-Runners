﻿using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.Models.Dto;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProjectRunners.Common.MessageBroker.Consuming
{
    /// <summary>
    /// Базовый класс брокера для работы с RabbitMq
    /// </summary>
    public abstract class MessageConsumerBase
    {
        private readonly RabbitMQConfig _config;
        private IModel _channel;
        private IConnection _connection;

        protected MessageConsumerBase(RabbitMQConfig config)
        {
            _config = config;

            OpenConnection();
        }

        /// <summary> Наименование очереди для потребления сообщений </summary>
        protected abstract string QueueName { get; }

        /// <summary> Наименование эксченжа для потребления сообщений </summary>
        protected abstract string ExchangeName { get; }

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        protected abstract Task Consume(RunnerCommandDto runnerCommand);

        public async Task Subscribe()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.Received += ConsumeBase;

            _channel.BasicConsume(QueueName, false, consumer);

            Console.WriteLine("Subscribed");

            await Task.CompletedTask;
        }

        private async Task ConsumeBase(object obj, BasicDeliverEventArgs args)
        {
            try
            {
                Console.WriteLine("Received a message");

                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var dto = JsonConvert.DeserializeObject<RunnerCommandDto>(message);

                await Consume(dto);

                _channel.BasicAck(args.DeliveryTag, false);
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
                QueueName,
                true,
                false,
                true,
                null);

            _channel.QueueBind(
                QueueName,
                ExchangeName,
                QueueName,
                null);
        }
    }
}