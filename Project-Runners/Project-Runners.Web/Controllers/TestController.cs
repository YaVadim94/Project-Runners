using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Runners.Application.Runs.Models.Queries;
using Project_Runners.Data;
using Project_Runners.Data.Models;
using Project_Runners.Web.Models;

namespace Project_Runners.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public TestController(DataContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("runs")]
        public async Task<IActionResult> GetRuns()
        {
            var query = new GetAllRunsQuery();

            var dto = await _mediator.Send(query);
            
            var contract = _mapper.Map<IEnumerable<RunContract>>(dto);
            
            return Ok(contract);
        }
        
    }
}