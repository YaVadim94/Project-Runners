using System.Threading.Tasks;
using Project_runners.Common.Models.Contracts;
using Refit;

namespace Project_Runners.Runner.APIs
{
    /// <summary>
    /// API прогонов
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