namespace WebApiDemo
{
    public class MockWeatherService : IWeatherService
    {
        private static readonly List<WeatherForecast> _forecasts = new()
        {
            new WeatherForecast { Id = 1, Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 20, Summary = "Cool" },
            new WeatherForecast { Id = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = 25, Summary = "Warm" },
        };
        public string GetWeatherForecast()
        {
            // Simulate returning a summary of all forecasts
            return string.Join(", ", _forecasts.Select(f => $"{f.Date}: {f.Summary}"));
        }
        public WeatherForecast GetForecastById(int id)
        {
            // Return a specific forecast by ID
            return _forecasts.FirstOrDefault(f => f.Id == id);
        }
        public List<WeatherForecast> GetAllForecasts()
        {
            // Return all forecasts
            return _forecasts;
        }
    }
}
