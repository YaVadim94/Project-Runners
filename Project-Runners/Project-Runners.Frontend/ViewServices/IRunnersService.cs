using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Runners.Frontend.Models;

namespace Project_Runners.Frontend.ViewServices
{
    /// <summary>
    /// Сервис для работы с раннерами
    /// </summary>
    public interface IRunnersService
    {
        /// <summary>
        /// Получить список раннеров
        /// </summary>
        Task<IEnumerable<Runner>> GetAll();

        /// <summary>
        /// Запросить скриншот раннера
        /// </summary>
        Task RequestForScreenshot(long runnerId);
    }
}