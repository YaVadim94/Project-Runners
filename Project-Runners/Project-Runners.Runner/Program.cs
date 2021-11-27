using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Runner.Extensions;
using Project_Runners.Runner.Services;

namespace Project_Runners.Runner
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
            IServiceCollection services = new ServiceCollection();

            services.AddServices();

            var serviceProvider = services.BuildServiceProvider();
            
            var runner = new Runner(serviceProvider);
            await runner.Start();
        }
    }
}