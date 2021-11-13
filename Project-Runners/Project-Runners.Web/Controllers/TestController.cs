using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Data;

namespace Project_Runners.Controllers
{
    /// <summary>
    /// Тестовый контроллер
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Тестовый метод
        /// </summary>
        public async Task<IActionResult> Test()
        {
            var test = await _context.Runs.ToListAsync();
            
            return NoContent();
        }
    }
}