using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Project_Runners.Runner.MessageBrokers;

namespace Project_Runners.Runner
{
    /// <summary>
    /// Пока не понятно, зачем этот класс
    /// </summary>
    public class Runner
    {
        public Runner(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary> Конфигерации </summary>
        private IConfiguration Configuration { get; }

        public async Task Start()
        {
            var messageBroker = new CaseForRunningConsumer(Configuration);
            messageBroker.Subscribe();

            while (true)
                await Task.Delay(1000);
        }
    }
}