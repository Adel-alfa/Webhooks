using Microsoft.EntityFrameworkCore;
using Webhooks.Models;

namespace Webhooks.Data
{
    public class weatherDbContext : DbContext
    {

        public weatherDbContext(DbContextOptions<weatherDbContext> options) : base(options)
        {

        }

        public DbSet<WeatherData> Weathers { get; set; }
    }
}
