using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Common.MessageBroker.Models;
using ProjectRunners.Runner.APIs.Grpc;
using ProjectRunners.Runner.EventHandlers;
using ProjectRunners.Runner.MessageConsumers;
using ProjectRunners.Runner.Services;

namespace ProjectRunners.Runner.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Зарегистировать сервисы приложения
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton(configuration)
                .AddSingleton<StateService>()
                .AddTransient<CasePlayer>()
                .AddTransient<CaseEventHandleRest>()
                .AddTransient<StateEventHandlerRest>()
                .AddTransient<StateEventHandlerGrpc>()
                .AddTransient<ScreenshotHandler>()
                .AddTransient<IRunnersApi, RunnersApi>()
                ;

            return services;
        }

        public static IServiceCollection AddMessageBroker(this IServiceCollection services,
            IConfiguration configuration)
        {
            var config = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

            var consumer = new MessageConsumer(config);

            services.AddSingleton(consumer);

            return services;
        }
    }
}