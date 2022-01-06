using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Project_Runners.Frontend.Api;
using Project_Runners.Frontend.Models;
using ProjectRunners.Common.Models.Contracts;

namespace Project_Runners.Frontend.ViewServices
{
    /// <summary>
    /// Сервис для работы с прогонами
    /// </summary>
    public class RunsService : IRunsService
    {
        private readonly IRunsApi _runsApi;
        private readonly IMapper _mapper;

        public RunsService(IRunsApi runsApi, IMapper mapper)
        {
            _runsApi = runsApi;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все прогоны
        /// </summary>
        public async Task<IEnumerable<Run>> GetAll()
        {
            var contracts = await _runsApi.GetAll();

            return _mapper.Map<IEnumerable<Run>>(contracts);
        }

        /// <summary>
        /// Получить прогон по идентификатору
        /// </summary>
        public async Task<Run> GetById(long id)
        {
            var contract = await _runsApi.GetById(id);

            return _mapper.Map<Run>(contract);
        }

        /// <summary>
        /// Получить тесты прогона
        /// </summary>
        public async Task<IEnumerable<TestCase>> GetTestCases(long runId, int pageSize, int pageNumber)
        {
            var contracts = await _runsApi.GetTestCases(runId, pageSize, pageNumber);

            return _mapper.Map<IEnumerable<TestCase>>(contracts);
        }
    }
}