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

        /// <summary> Идентификатор раннера </summary>
        public static long Id { get; }

        static Runner()
        {
            Id = GetRunnerId();
        }
        
        public Runner(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task Start()
        {
            Console.WriteLine("Start runner");
            var messageBroker = ServiceProvider.GetRequiredService<MessageConsumer>();
            await messageBroker.Subscribe();

            while (true)
                await Task.Delay(1000);
        }

        private static long GetRunnerId()
        {
            while (true)
            {
                Console.WriteLine("Input runner id:");
                
                if (long.TryParse(Console.ReadLine(), out var id))
                    return id;

                Console.WriteLine("Runner id must be numeric");
            }
        }
    }
}