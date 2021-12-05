using System.Threading.Tasks;
using StackExchange.Redis;

namespace ProjectRunners.Application.Services
{
    /// <summary>
    /// Сервис для работы с кешем через Redis
    /// </summary>
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        /// <summary>
        /// Получить значени по ключу
        /// </summary>
        public async Task<string> GetValue(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();

            return await db.StringGetAsync(key);
        }

        
        /// <summary>
        /// Положить данные в кеш
        /// </summary>
        public async Task SetValue(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();

            await db.StringSetAsync(key, value);
        }
    }
}