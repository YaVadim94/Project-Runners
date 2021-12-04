using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Project_runners.Common.Enums;
using Project_runners.Common.Models.Dto;
using Project_Runners.Runner.APIs;
using Project_Runners.Runner.Services;
using Refit;

namespace Project_Runners.Runner.EventHandlers
{
    /// <summary>
    /// Обработчик для прогона кейсов
    /// </summary>
    public class CaseEventHandler : IEventHandler
    {
        private readonly CasePlayer _player;
        private readonly StateService _stateService;
        private readonly ICaseResultsApi _caseResultsApi;

        public CaseEventHandler(CasePlayer player, StateService stateService, IConfiguration configuration)
        {
            _player = player;
            _stateService = stateService;
            _caseResultsApi = RestService.For<ICaseResultsApi>(configuration.GetSection("Project-Runners.Api").Value);
        }

        public async Task Handle(MessageDto dto)
        {
            if (_stateService.RunnerState == RunnerState.Running)
            {
                Console.WriteLine($"Could not run case. Runner has state: {_stateService.RunnerState}");
                return;
            }
            
            _stateService.SetState(RunnerState.Running);
            
            var result = await _player.Play(dto.Case);
            await _caseResultsApi.Create(result);
            Task.Delay(TimeSpan.FromMinutes(2)).GetAwaiter().GetResult();
            _stateService.SetState(RunnerState.Waiting);
        }
    }
}