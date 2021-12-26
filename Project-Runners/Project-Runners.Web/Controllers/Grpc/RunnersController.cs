using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using MediatR;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Common.Protos;

namespace ProjectRunners.Web.Controllers.Grpc
{
    /// <summary>
    /// Контроллер для работы с раннерами
    /// </summary>
    public class RunnersController : RunnersControllerGrpc.RunnersControllerGrpcBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RunnersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Выставить состояние раннера
        /// </summary>
        public override async Task<NoResponseGrpc> SetState(RunnerStateContractGrpc contract, ServerCallContext context)
        {
            var command = _mapper.Map<SetStateCommand>(contract);

            await _mediator.Send(command);

            return new NoResponseGrpc();
        }

        public override async Task<NoResponseGrpc> SendScreenshot(ScreenshotContract request, ServerCallContext context)
        {
            var command = _mapper.Map<SendScreenShotCommand>(request);

            await _mediator.Send(command);
            
            return new NoResponseGrpc();
        }
    }
}