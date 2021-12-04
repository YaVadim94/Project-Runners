using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Project_runners.Common.Models.Contracts;
using Project_runners.Common.Models.Dto;
using Project_Runners.Runner.APIs;
using Project_Runners.Runner.Services;
using Refit;

namespace Project_Runners.Runner.EventHandlers
{
    /// <summary>
    /// Обработчик события на отправку состония
    /// </summary>
    public class StateEventHandler : IEventHandler
    {
        private readonly StateService _stateService;
        private readonly IRunnersApi _runnersApi;

        public StateEventHandler(StateService stateService, IConfiguration configuration)
        {
            _stateService = stateService;
            _runnersApi = RestService.For<IRunnersApi>(configuration.GetSection("Project-Runners.Api").Value);
        }

        /// <summary>
        /// Обравить состояние
        /// </summary>
        public async Task Handle(MessageDto dto)
        {
            Console.WriteLine($"Sending state at {DateTime.Now.Second}");
            var contract = new RunnerStateContract
            {
                State = _stateService.RunnerState,
                RunnerId = int.Parse(Runner.Name)
            };
            
            await _runnersApi.SetState(contract);
        }
    }
}