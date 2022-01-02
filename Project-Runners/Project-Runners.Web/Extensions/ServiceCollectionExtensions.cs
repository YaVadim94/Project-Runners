using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Common.MessageBroker.Publishing;
using ProjectRunners.Common.MessageBroker.Publising;

namespace ProjectRunners.Web.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистрировать отправителя </summary>
        public static IServiceCollection AddMessagePublisher(this IServiceCollection services, IConfiguration config)
        {
            var rabbitConfig = config.GetSection("RabbitMQ").Get<RabbitMQConfig>();
            
            var publisher = new MessagePublisher(rabbitConfig);

            services.AddSingleton<IMessagePublisher>(publisher);
            
            return services;
        }
    }
}