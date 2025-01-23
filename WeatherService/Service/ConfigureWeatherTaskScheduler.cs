using Coravel.Scheduling.Schedule.Interfaces;

namespace WeatherService.Service
{
    public static class ConfigureApp
    {
        public static void ConfigureWeatherScheduler(this WebApplication app, IHostEnvironment env, IServiceProvider services)
        {
            var scheduler = services.GetService<IScheduler>();

            scheduler.Schedule<WeatherInvocable>()
                     //.EverySecond()
                     //.EveryTenMinutes()
                     .EverySeconds(10)
                     .PreventOverlapping("WeatherInvocable");
        }
    }

}
