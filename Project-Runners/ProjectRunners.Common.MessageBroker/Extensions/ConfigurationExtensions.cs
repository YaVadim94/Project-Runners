using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ProjectRunners.Common.MessageBroker.Extensions
{
    /// <summary>
    /// Расширерия для работы с кофигурациями
    /// </summary>
    public static class ConfigurationExtensions
    {
        public static T Get<T>(this IConfigurationSection section)
        {
            var tempJson = JsonConvert.SerializeObject(
                section.GetChildren().ToDictionary(s => s.Key, s => s.Value));
            
            return JsonConvert.DeserializeObject<T>(tempJson);
        }
            
    }
}