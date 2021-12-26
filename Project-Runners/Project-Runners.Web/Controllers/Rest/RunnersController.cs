using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectRunners.Application.Runners.Models.Commands;
using ProjectRunners.Application.Runners.Models.Queries;
using ProjectRunners.Common.Models.Contracts;
using ProjectRunners.Web.Models;

namespace ProjectRunners.Web.Controllers.Rest
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

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetScreen(long id)
        {
            var command = new GetScreenshotCommand {Id = id};

            await _mediator.Send(command);

            return NoContent();
        }
    }
}