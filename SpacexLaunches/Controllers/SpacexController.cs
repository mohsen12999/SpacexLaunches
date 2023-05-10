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
        private readonly HttpClient _http;
        const string launch_url = "https://api.spacexdata.com/v3/launches/";

        public SpacexController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLaunchAsync()
        {
            using (var response = await _http.GetAsync(launch_url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var launch = JsonSerializer.Deserialize<IEnumerable<Launch>>(apiResponse);
                    return Ok(launch);
                }
                else
                {
                    return BadRequest(response);
                }
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLaunchByIdAsync(int id)
        {
            using (var response = await _http.GetAsync(launch_url + id))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var launch = JsonSerializer.Deserialize<Launch>(apiResponse);
                    return Ok(launch);
                }
                else
                {
                    return BadRequest(response);
                }

            }
        }
    }
}
