using Webhooks.Models;

namespace Webhooks.Services
{
    public interface IWeather
    {
        Task AddAsync(WeatherData entity, CancellationToken cancellationToken = default);
        Task<WeatherData?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<WeatherData>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<WeatherData>> GetFromToAsync(DateTime from, DateTime to,CancellationToken cancellationToken = default);
    }
}
