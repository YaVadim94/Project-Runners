using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Runners.Data.Models;

namespace Project_Runners.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;
        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("cases")]
        public async Task<IActionResult> GetCases()
        {
            var cases = await _context.Cases.ToListAsync();
            return Ok(cases);
        }
        
        [HttpGet("runs")]
        public async Task<IActionResult> GetRuns()
        {
            var runs = await _context.Runs.ToListAsync();
            return Ok(runs);
        }
    }
}