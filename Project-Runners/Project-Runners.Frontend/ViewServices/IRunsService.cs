using System.Collections.Generic;
using System.Threading.Tasks;
using Project_Runners.Frontend.Models;
using ProjectRunners.Common.Models.Contracts;

namespace Project_Runners.Frontend.ViewServices
{
    /// <summary>
    /// Сервис для работы с прогонами
    /// </summary>
    public interface IRunsService
    {
        /// <summary>
        /// Получить все прогоны
        /// </summary>
        Task<IEnumerable<Run>> GetAll();

        /// <summary>
        /// Получить прогон по идентификатору
        /// </summary>
        Task<Run> GetById(long id);

        /// <summary>
        /// Получить тесты прогона
        /// </summary>
        Task<IEnumerable<TestCase>> GetTestCases(long runId, int pageSize, int pageNumber);
    }
}