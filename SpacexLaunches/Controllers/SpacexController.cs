﻿using Microsoft.AspNetCore.Mvc;
using SpacexLaunches.DTO;
using System.Text.Json;

namespace SpacexLaunches.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpacexController : ControllerBase
    {
        private readonly HttpClient _http;
        private const string LaunchUrl = "https://api.spacexdata.com/v3/launches/";

        public SpacexController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLaunchAsync()
        {
            using var response = await _http.GetAsync(LaunchUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    var launch = JsonSerializer.Deserialize<IEnumerable<Launch>>(apiResponse);
                    return Ok(launch);
                }
                catch (Exception e)
                {
                    return Problem(detail: e.Message);
                }
                    
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLaunchByIdAsync(int id)
        {
            using var response = await _http.GetAsync(LaunchUrl + id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    var launch = JsonSerializer.Deserialize<Launch>(apiResponse);
                    return Ok(launch);
                }
                catch (Exception e)
                {
                    return Problem(detail: e.Message);
                }
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
