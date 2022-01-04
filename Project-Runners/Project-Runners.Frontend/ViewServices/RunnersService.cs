using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Project_Runners.Frontend.Api;
using Project_Runners.Frontend.Models;

namespace Project_Runners.Frontend.ViewServices
{
    /// <summary>
    /// Сервис для работы с контроллером раннеров
    /// </summary>
    public class RunnersService : IRunnersService
    {
        private readonly IMapper _mapper;
        private readonly IRunnersApi _runnersApi;

        public RunnersService(IMapper mapper, IRunnersApi runnersApi)
        {
            _mapper = mapper;
            _runnersApi = runnersApi;
        }

        public async Task<IEnumerable<Runner>> GetAll()
        {
            var contracts = await _runnersApi.GetAll();

            return _mapper.Map<IEnumerable<Runner>>(contracts);
        }
    }
}