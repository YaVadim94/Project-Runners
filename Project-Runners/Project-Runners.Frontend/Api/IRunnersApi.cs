using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectRunners.Web.Models;
using Refit;

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
        [Get("/api/runners")]
        Task<IEnumerable<RunnerContract>> GetAll();
    }
}