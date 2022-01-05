using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ProjectRunners.Common.Models.Contracts;

namespace Project_Runners.Frontend.Api
{
    /// <summary>
    /// АПИ прогонов
    /// </summary>
    public class RunsApi : ApiBase, IRunsApi
    {
        public RunsApi(HttpClient apiClient) : base(apiClient)
        {
        }

        protected override string ControllerUrl => "api/runs";

        /// <summary>
        /// Получить список прогонов
        /// </summary>
        public async Task<IEnumerable<RunContract>> GetAll() =>
            await GetAsync<IEnumerable<RunContract>>(string.Empty);

        /// <summary>
        /// Получить прогон по идентификатору
        /// </summary>
        public async Task<RunContract> GetById(long id) =>
            await GetAsync<RunContract>($"{id}");
    }
}