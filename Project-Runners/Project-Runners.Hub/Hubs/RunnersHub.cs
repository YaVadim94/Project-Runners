#nullable enable
using System;
using System.Threading.Tasks;

namespace Project_Runners.Hub.Hubs
{
    /// <summary>
    /// Хаб раннеров
    /// </summary>
    public class RunnersHub : Microsoft.AspNetCore.SignalR.Hub
    {
        /// <summary>
        /// Действия при подключении клиента
        /// </summary>
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected");

            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Действия при отключении клиента
        /// </summary>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine("Client disconnected");
            
            return base.OnDisconnectedAsync(exception);
        }
    }
}