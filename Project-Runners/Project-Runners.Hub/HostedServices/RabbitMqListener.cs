using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Project_Runners.Hub.Consumers;

namespace Project_Runners.Hub.HostedServices
{
    /// <summary>
    /// Слушатель сообщений по шине данных
    /// </summary>
    public class RabbitMqListener : IHostedService
    {
        private readonly MainConsumer _mainConsumer;

        public RabbitMqListener(MainConsumer mainConsumer)
        {
            _mainConsumer = mainConsumer;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _mainConsumer.Subscribe();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _mainConsumer.Unsubscribe();
        }
    }
}