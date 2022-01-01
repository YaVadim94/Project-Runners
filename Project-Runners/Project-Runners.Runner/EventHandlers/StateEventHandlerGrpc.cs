using System;
using System.Threading.Tasks;
using ProjectRunners.Common.Enums;
using ProjectRunners.Common.Models.Dto;
using ProjectRunners.Common.Protos;
using ProjectRunners.Runner.APIs.Grpc;
using ProjectRunners.Runner.Extensions;
using ProjectRunners.Runner.Services;

namespace ProjectRunners.Runner.EventHandlers
{
    /// <summary>
    /// Обработчик события на отправку состония по grpc
    /// </summary>
    public class StateEventHandlerGrpc : IEventHandler
    {
        private readonly IRunnersApi _runnersApi;
        private readonly StateService _stateService;

        public StateEventHandlerGrpc(StateService stateService, IRunnersApi runnersApi)
        {
            _stateService = stateService;
            _runnersApi = runnersApi;
        }

        /// <summary>
        /// Отправить состояние
        /// </summary>
        public async Task Handle(MessageDto dto)
        {
            Console.WriteLine($"---> Sending state at {DateTime.Now.Second}");
            var contract = new RunnerStateContractGrpc
            {
                State = _stateService.RunnerState.MapToGrpc<RunnerState, RunnerStateGrpc>(),
                RunnerId = Runner.Id
            };

            await _runnersApi.SetState(contract);
        }
    }
}