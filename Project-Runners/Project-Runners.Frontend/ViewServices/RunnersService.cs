using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Project_Runners.Frontend.Api;
using Project_Runners.Frontend.Models;
using Refit;

namespace Project_Runners.Frontend.ViewServices
{
    /// <summary>
    /// Сервис для работы с контроллером раннеров
    /// </summary>
    public class RunnersService : IRunnersService
    {
        private readonly IRunnersApi _runnersApi;
        private readonly IMapper _mapper;
        public RunnersService(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            _runnersApi = RestService.For<IRunnersApi>(configuration.GetSection("ProjectRunners.Api").Value);
        }

        public async Task<IEnumerable<Runner>> GetAll()
        {
            var contracts = await _runnersApi.GetAll();

            return _mapper.Map<IEnumerable<Runner>>(contracts);
        }
    }
}