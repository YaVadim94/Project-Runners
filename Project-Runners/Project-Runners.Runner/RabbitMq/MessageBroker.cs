using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;

namespace Project_Runners.Runner.RabbitMq
{
    /// <summary>
    /// Брокер для работы с RabbitMq
    /// </summary>
    public class MessageBroker : MessageBrokerBase
    {
        public MessageBroker(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Обработать сообщение
        /// </summary>
        protected override void Consume(object obj, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
        }
    }
}