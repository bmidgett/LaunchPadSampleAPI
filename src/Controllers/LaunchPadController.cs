using System.Threading.Tasks;
using LaunchPadAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LaunchPadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchPadController : ControllerBase
    {
        private readonly ILaunchPadService _launchPadService;
        private readonly ILogger<LaunchPadController> _logger;

        private readonly string _baseUri;

        public LaunchPadController(ILaunchPadService launchPadService,
            ILogger<LaunchPadController> logger,
            IConfiguration config)
        {
            _launchPadService = launchPadService;
            _logger = logger;

            _baseUri = config.GetValue<string>("SpaceX:BaseUri");
        }

        [HttpGet]
        public async Task<IActionResult> Get(int limit = 10, int offset = 1)
        {
            _logger.LogInformation("Get method was called...");

            var result = await _launchPadService.GetLaunchPads(_baseUri, limit, offset);

            return Ok(result);
        }
    }
}