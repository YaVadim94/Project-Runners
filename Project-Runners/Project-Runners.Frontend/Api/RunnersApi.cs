using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ProjectRunners.Web.Models;

namespace Project_Runners.Frontend.Api
{
    public class RunnersApi : ApiBase, IRunnersApi
    {
        public RunnersApi(HttpClient apiClient) : base(apiClient)
        {
        }

        protected override string ControllerUrl => "/api/runners";

        public async Task<IEnumerable<RunnerContract>> GetAll() =>
            await GetAsync<IEnumerable<RunnerContract>>(string.Empty);
    }
}