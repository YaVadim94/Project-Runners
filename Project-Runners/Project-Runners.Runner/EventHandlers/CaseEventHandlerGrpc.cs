using System;
using System.Threading.Tasks;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Protos;
using ProjectRunners.Runner.APIs.Grpc;
using ProjectRunners.Runner.Extensions;
using ProjectRunners.Runner.Services;

namespace ProjectRunners.Runner.EventHandlers
{
    /// <summary>
    /// Обработчик для прогона кейсов
    /// </summary>
    public class CaseEventHandlerGrpc : IEventHandler
    {
        private readonly CasePlayer _player;
        private readonly StateService _stateService;
        private readonly ICaseResultsApi _caseResultsApi;

        public CaseEventHandlerGrpc(CasePlayer player, StateService stateService, ICaseResultsApi caseResultsApi)
        {
            _player = player;
            _stateService = stateService;
            _caseResultsApi = caseResultsApi;
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

            var contract = new CaseResultContractGrpc
            {
                Id = result.Id,
                RunId = result.RunId,
                Status = result.Status.MapToGrpc<RunStatus, RunStatusGrpc>()
            };
            
            await _caseResultsApi.Create(contract);
            
            _stateService.SetState(RunnerState.Waiting);
        }
    }
}