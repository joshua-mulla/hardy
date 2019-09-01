using System.Threading.Tasks;
using Hardy.Gateways.OpenWeather;
using Microsoft.AspNetCore.Mvc;

namespace Hardy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOpenWeatherApiClient _client;

        public ValuesController(IOpenWeatherApiClient client)
        {
            _client = client;
        }


        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = await _client.GetCurrentWeatherAsync();
            return Ok(res.Content);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
