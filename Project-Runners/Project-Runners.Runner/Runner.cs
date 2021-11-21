using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Project_Runners.Runner.Extensions;
using Project_Runners.Runner.Models;
using Project_Runners.Runner.RabbitMq;

namespace Project_Runners.Runner
{
    /// <summary>
    /// Пока не понятно, зачем этот класс
    /// </summary>
    public class Runner
    {
        /// <summary> Конфигерации </summary>
        private IConfiguration Configuration { get; set; }
        
        public Runner(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task Start()
        {
            var messageBroker = new MessageBroker(Configuration);
            messageBroker.Subscribe();

            while (true)
                await Task.Delay(1000);
        }
    }
}