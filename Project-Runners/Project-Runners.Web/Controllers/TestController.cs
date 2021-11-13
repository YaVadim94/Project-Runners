using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public TestController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("runs")]
        public async Task<IEnumerable<RunDto>> GetRuns()
        {
            var runs = await _context.Runs
                .Include(r => r.Cases).ThenInclude(c => c.Case)
                .ToListAsync();
            
            return _mapper.Map<IEnumerable<RunDto>>(runs);
        }
        
    }
}