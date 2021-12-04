using System.Threading.Tasks;
using Project_runners.Common.Models.Contracts;
using Refit;

namespace ProjectRunners.Runner.APIs.Rest
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