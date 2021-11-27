using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Runner.EventHandlers;
using Project_Runners.Runner.MessageBrokers;
using Project_Runners.Runner.Services;
using Refit;

namespace Project_Runners.Runner.Extensions
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
                .AddSingleton<MessageBroker>()
                .AddTransient<CasePlayer>()
                .AddTransient<CaseHandler>()
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