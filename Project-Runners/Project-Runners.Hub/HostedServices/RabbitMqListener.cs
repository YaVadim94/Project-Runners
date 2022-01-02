using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Project_Runners.Hub.HostedServices
{
    /// <summary>
    /// Слушатель сообщений по шине данных
    /// </summary>
    public class RabbitMqListener : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}