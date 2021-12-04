using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_Runners.Application.Runners.Models.Commands;
using Project_Runners.Application.Runners.Models.Queries;
using Project_runners.Common.Models.Contracts;
using Project_Runners.Web.Models;

namespace Project_Runners.Web.Controllers
{
    /// <summary>
    /// Контроллер для работы с раннерами
    /// </summary>
    [ApiController]
    [Route("api/runners")]
    public class RunnersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RunnersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllRunnersQuery();

            var dto = await _mediator.Send(query);

            var contract = _mapper.Map<IEnumerable<RunnerContract>>(dto);

            return Ok(contract);
        }
        
        [HttpPatch("set-state")]
        public async Task<IActionResult> SetState(RunnerStateContract contract)
        {
            var command = _mapper.Map<SetStateCommand>(contract);
            
            await _mediator.Send(command);
            
            return NoContent();
        } 
    }
}