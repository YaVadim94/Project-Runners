using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Common.MessageBroker.Publising;

namespace ProjectRunners.Common.MessageBroker.Extensions
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
            var publisher = new MessagePublisher(config);

            services.AddSingleton<IMessagePublisher>(publisher);
            
            return services;
        }
    }
}