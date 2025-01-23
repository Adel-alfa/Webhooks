using Microsoft.EntityFrameworkCore;
using Webhooks.Data;
using Webhooks.Endpoints;
using Webhooks.Services;

namespace Webhooks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<weatherDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddScoped<IWeather, WeatherRepository>();
            var app = builder.Build();

            app.MapGet("/", () => "Hello Weather!")
                .WithTags("Home");
            app.MapWebhookEndpoints(builder.Configuration);
            app.MapWeatherEndpoints();
            app.Run();
        }
    }
}
