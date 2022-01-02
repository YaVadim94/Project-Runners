using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Common.Enums;
using ProjectRunners.Runner.APIs.Grpc;
using ProjectRunners.Runner.EventHandlers;
using ProjectRunners.Runner.MessageBrokers;
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
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddConfiguration()
                .AddSingleton<StateService>()
                .AddSingleton<MessageConsumer>()
                .AddTransient<CasePlayer>()
                .AddTransient<CaseEventHandleRest>()
                .AddTransient<StateEventHandlerRest>()
                .AddTransient<StateEventHandlerGrpc>()
                .AddTransient<ScreenshotHandler>()
                .AddTransient<IRunnersApi, RunnersApi>()
                ;
        }

        /// <summary>
        /// Зарегистрировать конфигурации
        /// </summary>
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton<IConfiguration>(config);

            return services;
        }
    }
}