using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_Runners.Application.CaseResults.Models.Commands;
using Project_runners.Common.Models;
using Project_runners.Common.Models.Contracts;

namespace Project_Runners.Web.Controllers
{
    [ApiController]
    [Route("api/case-results")]
    public class CaseResultsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CaseResultsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CaseResultContract contract)
        {
            var command = _mapper.Map<CreateCaseResultCommand>(contract);

            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}