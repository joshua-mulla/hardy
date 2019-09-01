using System.Threading.Tasks;
using Hardy.Application;
using Hardy.Gateways.OpenWeather;
using Microsoft.AspNetCore.Mvc;

namespace Hardy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _weatherService.GetWeatherAsync();

            return Ok(result.Content);
        }
    }
}