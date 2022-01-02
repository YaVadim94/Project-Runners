using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectRunners.Application.Services;
using ProjectRunners.Application.Services.Caching;

namespace ProjectRunners.Web.Controllers.Rest
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public TestController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _cacheService.GetValue("key");

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Set()
        {
            await _cacheService.SetValue("key", "you are loh");

            return NoContent();
        }

        [HttpGet("connection")]
        public IActionResult TestConnection()
        {
            return Ok("All is alright");
        }
    }
}