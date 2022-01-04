using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectRunners.Web.Models;

namespace Project_Runners.Frontend.Api
{
    /// <summary>
    /// Api раннеров
    /// </summary>
    public interface IRunnersApi
    {
        /// <summary>
        /// Получить список раннеров
        /// </summary>
        Task<IEnumerable<RunnerContract>> GetAll();
        
        /// <summary>
        /// Запросить скриншот раннера
        /// </summary>
        Task RequestForScreenshot(long runnerId);
    }
}