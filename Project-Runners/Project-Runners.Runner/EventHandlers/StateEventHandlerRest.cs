using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProjectRunners.Common.Models.Contracts;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Runner.APIs.Rest;
using ProjectRunners.Runner.Services;
using Refit;

namespace ProjectRunners.Runner.EventHandlers
{
    /// <summary>
    /// Обработчик события на отправку состония по rest
    /// </summary>
    public class StateEventHandlerRest : IEventHandler
    {
        private readonly StateService _stateService;
        private readonly IRunnersApi _runnersApi;

        public StateEventHandlerRest(StateService stateService, IConfiguration configuration)
        {
            _stateService = stateService;
            _runnersApi = RestService.For<IRunnersApi>(configuration.GetSection("ProjectRunners").Value);
        }

        /// <summary>
        /// Обравить состояние
        /// </summary>
        public async Task Handle(RunnerCommandDto dto)
        {
            Console.WriteLine($"Sending state at {DateTime.Now.Second}");
            var contract = new RunnerStateContract
            {
                State = _stateService.RunnerState,
                RunnerId = Runner.Id
            };
            
            await _runnersApi.SetState(contract);
        }
    }
}