using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Runner.MessageBrokers;
using Project_Runners.Runner.Services;

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
                .AddTransient<CaseForRunningConsumer>()
                .AddTransient<CaseRunService>()
                .AddSingleton<StateService>()
                ;
        }
        
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