using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Project_Runners.Runner.MessageBrokers;
using Project_Runners.Runner.Services;

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
            var messageBroker = new CaseForRunningConsumer(Configuration, new CaseRunService());
            messageBroker.Subscribe();

            while (true)
                await Task.Delay(1000);
        }
    }
}