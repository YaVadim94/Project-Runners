using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var runner = new Runner(config);
            await runner.Start();
        }
    }
}