using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Runner.APIs.Rest;
using ProjectRunners.Runner.Services;
using Refit;

namespace ProjectRunners.Runner.EventHandlers
{
    /// <summary>
    /// Обработчик для прогона кейсов
    /// </summary>
    public class CaseEventHandleRest : IEventHandler
    {
        private readonly CasePlayer _player;
        private readonly StateService _stateService;
        private readonly ICaseResultsApi _caseResultsApi;

        public CaseEventHandleRest(CasePlayer player, StateService stateService, IConfiguration configuration)
        {
            _player = player;
            _stateService = stateService;
            _caseResultsApi = RestService.For<ICaseResultsApi>(configuration.GetSection("ProjectRunners").Value);
        }

        public async Task Handle(MessageDto dto)
        {
            if (dto.AddedData is not CaseForRunningDto testCase)
            {
                Console.WriteLine("Received incorrect message");
                return;
            }
            
            if (_stateService.RunnerState == RunnerState.Running)
            {
                Console.WriteLine($"Could not run case. Runner has state: {_stateService.RunnerState}");
                return;
            }
            
            _stateService.SetState(RunnerState.Running);
            
            var result = await _player.Play(testCase);

            await _caseResultsApi.Create(result);
            
            _stateService.SetState(RunnerState.Waiting);
        }
    }
}