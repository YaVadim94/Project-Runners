using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectRunners.Application.Runs.Models.Commands;
using ProjectRunners.Application.Runs.Models.Queries;
using ProjectRunners.Common.Models.Contracts;

namespace ProjectRunners.Web.Controllers.Rest
{
    /// <summary>
    /// Контроллер для работы с прогонами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RunsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RunsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Получить все прогоны
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
        /// Получить прогон по id
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
        /// Создать новый прогон
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateRunContract contract)
        {
            var command = _mapper.Map<CreateRunCommand>(contract);

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {Id = id}, id);
        }

        /// <summary>
        /// Начать прогон тестов
        /// </summary>
        [HttpPatch("{id:long}/start")]
        public async Task<IActionResult> Start(long id)
        {
            var command = new StartRunCommand {Id = id};

            await _mediator.Send(command);

            return NoContent();
        }
    }
}