using Coravel.Invocable;
using System;

namespace WeatherService.Service
{
    public class WeatherInvocable(IWeatherFetcher weatherFetcher) : IInvocable
    {
        public async Task Invoke()
        {
           var data= await weatherFetcher.GetCurrentWeather();
            var respons = await weatherFetcher.SendWeatherData(data);
            Console.WriteLine($"WebHook Response: {respons} " );

            
            Results.Redirect("/");

        }
    }
}

