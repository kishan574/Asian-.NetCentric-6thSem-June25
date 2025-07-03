namespace WebApiDemo
{
    public interface IWeatherService
    {
        string GetWeatherForecast();
        WeatherForecast GetForecastById(int id);
        List<WeatherForecast> GetAllForecasts();
    }
}