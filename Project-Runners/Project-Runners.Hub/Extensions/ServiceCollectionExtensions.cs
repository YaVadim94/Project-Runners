using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Hub.Consumers;
using ProjectRunners.Common.MessageBroker.Models;

namespace Project_Runners.Hub.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageConsumer(this IServiceCollection services,
            IConfiguration configuration)
        {
            var rabbitConfig = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            services.AddSingleton(rabbitConfig);
            services.AddTransient<MainConsumer>();

            return services;
        }
    }
}