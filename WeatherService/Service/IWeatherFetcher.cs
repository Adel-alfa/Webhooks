using WeatherService.Models;

namespace WeatherService.Service
{
    public interface IWeatherFetcher
    {
        Task<WeatherData> GetCurrentWeather();
        Task<string> SendWeatherData(WeatherData data );
    }
}
