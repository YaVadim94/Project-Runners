using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Project_Runners.Runner.Extensions;
using Project_Runners.Runner.Models;

namespace Project_Runners.Runner
{
    /// <summary>
    /// Пока не понятно, зачем этот класс
    /// </summary>
    public class Runner
    {
        /// <summary> Конфигерации </summary>
        public IConfiguration Configuration { get; set; }
        
        public Runner(IConfiguration configuration)
        {
            Configuration = configuration;

            var test = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();
        }

        public async Task Start()
        {
            while (true)
                await Task.Delay(1000);
        }
    }
}