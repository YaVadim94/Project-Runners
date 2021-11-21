using System.Threading.Tasks;
using Project_runners.Common.Models;
using Refit;

namespace Project_Runners.Runner.APIs
{
    /// <summary>
    /// API для прогонов
    /// </summary>
    public interface ICaseResultsApi
    {
        /// <summary>
        /// Отправить результат прогона
        /// </summary>
        [Post("/case-results")]
        public Task Create(CaseResultContract contract);
    }
}