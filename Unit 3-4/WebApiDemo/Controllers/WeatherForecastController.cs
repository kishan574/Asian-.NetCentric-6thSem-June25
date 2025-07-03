using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<WeatherForecast> _forecasts;
        private IWeatherService _weatther;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatther = weatherService;
        }

        // GET: /WeatherForecast/GetWeatherForecast
        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET: /WeatherForecast/GetOneForecast
        [HttpGet("GetOneForecast")]
        public WeatherForecast GetOne()
        {
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        // GET: /WeatherForecast/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
           //return Ok(_forecasts);
           return Ok(_weatther.GetAllForecasts());
        }

        // GET: /WeatherForecast/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            //var forecast = _weatther.GetForecastById(id);
            if (forecast == null)
                return NotFound($"Forecast with ID {id} not found.");
            return Ok(forecast);
        }

        // POST: /WeatherForecast
        [HttpPost]
        public IActionResult Create(WeatherForecast forecast)
        {
            forecast.Id = _forecasts.Max(f => f.Id) + 1; // Auto-increment ID
            _forecasts.Add(forecast);
            return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
        }

        // PUT: /WeatherForecast/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, WeatherForecast updatedForecast)
        {
            var existingForecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (existingForecast == null)
                return NotFound($"Forecast with ID {id} not found.");

            // Update properties
            existingForecast.Date = updatedForecast.Date;
            existingForecast.TemperatureC = updatedForecast.TemperatureC;
            existingForecast.Summary = updatedForecast.Summary;

            return NoContent(); // Standard response for PUT
        }

        // DELETE: /WeatherForecast/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
                return NotFound($"Forecast with ID {id} not found.");

            _forecasts.Remove(forecast);
            return NoContent();
        }
    }
}
