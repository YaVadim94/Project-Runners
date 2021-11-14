using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_Runners.Application.Runs.Models.Commands;
using Project_Runners.Application.Runs.Models.Queries;
using Project_Runners.Data;
using Project_Runners.Web.Models;

namespace Project_Runners.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RunsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RunsController(DataContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all runs
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllRunsQuery();

            var dto = await _mediator.Send(query);

            var contract = _mapper.Map<IEnumerable<RunContract>>(dto);

            return Ok(contract);
        }

        /// <summary>
        /// Get run by id
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new GetRunByIdQuery {Id = id};

            var dto = await _mediator.Send(query);

            var contract = _mapper.Map<RunContract>(dto);

            return Ok(contract);
        }

        /// <summary>
        /// Create new run
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateRunContract contract)
        {
            var command = _mapper.Map<CreateRunCommand>(contract);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {Id = id}, id);
        }
    }
}