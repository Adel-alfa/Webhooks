using Coravel;
using Microsoft.Extensions.Logging.Console;
using WeatherService.Service;

namespace WeatherService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScheduler();
           

            builder.Services.AddScoped<IWeatherFetcher, WeatherFetcher>();
            builder.Services.AddScoped<WeatherInvocable>();
            var app = builder.Build();

            app.ConfigureWeatherScheduler(app.Environment, app.Services);
           

            app.MapGet("/", () => "Weather Services" ).WithTags("Home");
      

            app.Run();
        }
    }
}
