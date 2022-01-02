using System.Threading.Tasks;

namespace ProjectRunners.Application.Services.Caching
{
    /// <summary>
    /// Сервис для работы с кешем
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Получить значени по ключу
        /// </summary>
        Task<string> GetValue(string key);

        /// <summary>
        /// Положить данные в кеш
        /// </summary>
        Task SetValue(string key, string value);
    }
}