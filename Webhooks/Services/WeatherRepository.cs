using Microsoft.EntityFrameworkCore;
using Webhooks.Data;
using Webhooks.Models;

namespace Webhooks.Services
{
    public class WeatherRepository : IWeather
    {
        private readonly weatherDbContext _context;
        public WeatherRepository(weatherDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(WeatherData entity, CancellationToken cancellationToken = default)
        {
            await _context.Weathers.AddAsync(entity, cancellationToken);
            await Commit(cancellationToken);
        }

        public async Task<IEnumerable<WeatherData>> GetAllAsync(CancellationToken cancellationToken = default)=>
        await _context.Weathers.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<WeatherData?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)=>        
            await _context.Weathers.FindAsync(id, cancellationToken);
        
        public async Task<IEnumerable<WeatherData>> GetFromToAsync(DateTime from, DateTime to, CancellationToken cancellationToken = default)
        {
            return await _context.Weathers.Where(_=> _.Date >= from && _.Date < to).ToListAsync(cancellationToken);
        }
        private async Task Commit(CancellationToken cancellationToken) => await _context.SaveChangesAsync();
    }
}
