using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Runners.Runner.MessageBrokers;
using Project_Runners.Runner.Services;

namespace Project_Runners.Runner
{
    /// <summary>
    /// Пока не понятно, зачем этот класс
    /// </summary>
    public class Runner
    {
        public static IServiceProvider ServiceProvider { get; set; }
        
        public Runner(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task Start()
        {
            Console.WriteLine("Start runner");
            var messageBroker = ServiceProvider.GetRequiredService<CaseForRunningConsumer>();
            await messageBroker.Subscribe();

            while (true)
                await Task.Delay(1000);
        }
    }
}