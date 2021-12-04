using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectRunners.Runner.MessageBrokers;

namespace ProjectRunners.Runner
{
    /// <summary>
    /// Пока не понятно, зачем этот класс
    /// </summary>
    public class Runner
    {
        /// <summary> Общий доступ к DI </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary> Наименование раннера </summary>
        public static string Name { get; }

        static Runner()
        {
            Console.WriteLine("Input runner name:");
            Name = Console.ReadLine();
        }
        
        public Runner(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task Start()
        {
            Console.WriteLine("Start runner");
            var messageBroker = ServiceProvider.GetRequiredService<MessageBroker>();
            await messageBroker.Subscribe();

            while (true)
                await Task.Delay(1000);
        }
    }
}