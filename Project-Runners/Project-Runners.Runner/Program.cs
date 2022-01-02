using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Runner.Extensions;

namespace ProjectRunners.Runner
{
    /// <summary>
    /// Вход в приложение
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Построение конфигураций, запуск раннера
        /// </summary>
        private static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            services.AddServices(configuration);
            services.AddMessageBroker(configuration);
            
            var serviceProvider = services.BuildServiceProvider();

            var runner = new Runner(serviceProvider);
            await runner.Start();
        }
    }
}