using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using ProjectRunners.Common.Models.Dto;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace Project_Runners.Hub.Hubs
{
    /// <summary>
    /// Хаб раннеров
    /// </summary>
    public class RunnersHub : Microsoft.AspNetCore.SignalR.Hub
    {
    }
}