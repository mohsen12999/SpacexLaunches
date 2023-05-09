using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacexLaunches.DTO;
using System.Text.Json;

namespace SpacexLaunches.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpacexController : ControllerBase
    {
        private readonly ILogger<SpacexController> _logger;
        const string launch_url = "https://api.spacexdata.com/v3/launches/";

        public SpacexController(ILogger<SpacexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLaunchAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(launch_url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var launch = JsonSerializer.Deserialize<IEnumerable<Launch>>(apiResponse);
                    return Ok(launch);
                }
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLaunchByIdAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(launch_url + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var launch = JsonSerializer.Deserialize<Launch>(apiResponse);
                    return Ok(launch);
                }
            }
        }
    }
}
