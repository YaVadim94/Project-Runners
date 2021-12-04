using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using MediatR;
using ProjectRunners.Application.CaseResults.Models.Commands;
using ProjectRunners.Protos;
using ProjectRunners.Web.Controllers.Rest;

namespace ProjectRunners.Web.Controllers.Grpc
{
    /// <summary>
    /// Контроллер для работы с результатами тестов
    /// </summary>
    public class CaseResultController : CaseResultControllerGrpc.CaseResultControllerGrpcBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CaseResultController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Создать результат прогона теста
        /// </summary>
        public override async Task<NoResponseCaseResultsGrpc> Create(CaseResultContractGrpc contract,
            ServerCallContext context)
        {
            var command = _mapper.Map<CreateCaseResultCommand>(contract);

            await _mediator.Send(command);
            
            return new NoResponseCaseResultsGrpc();
        }
    }
}