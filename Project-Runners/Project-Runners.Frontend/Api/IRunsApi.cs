using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectRunners.Common.Models.Contracts;

namespace Project_Runners.Frontend.Api
{
    /// <summary>
    /// АПИ прогонов
    /// </summary>
    public interface IRunsApi
    {
        /// <summary>
        /// Получить список прогонов
        /// </summary>
        Task<IEnumerable<RunContract>> GetAll();

        /// <summary>
        /// Получить прогон по идентификатору
        /// </summary>
        Task<RunContract> GetById(long id);

        /// <summary>
        /// Получить тесты прогона
        /// </summary>
        Task<IEnumerable<CaseContract>> GetTestCases(long runId, int pageSize, int pageNumber);
    }
}