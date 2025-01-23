
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;
using WeatherService.Models;

namespace WeatherService.Service
{
    public class WeatherFetcher : IWeatherFetcher
    {
        private static Random _random = new Random();
        public Task<WeatherData> GetCurrentWeather()
        {
            WeatherData d = new WeatherData();  
            d.Temperature = _random.Next(-10, 58);

            d.Humidity = _random.Next(0, 101);
            Console.WriteLine($" Current Time: {d.Date}; Temperature= {d.Temperature}; Humidity= {d.Humidity}");
            return Task.FromResult(d);
        }
        
        public async Task<string> SendWeatherData(WeatherData data)
        {
            var requestUri = "https://localhost:7142/";
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "API-Authen-Key"; 
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(requestUri);
                    if (httpContext.Request.Headers.ContainsKey("Authorization")) 
                    { 
                        client.DefaultRequestHeaders.Authorization = 
                            new AuthenticationHeaderValue( httpContext.Request.Headers["Authorization"]);
                    }
                    var jsonData = JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("api/webhooks", content);
                   
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    else
                        return $"Error - Status: {response.StatusCode}";
                }
            }
            catch (HttpRequestException e )
            {

                return $"Request error: {e.Message}";
            }
            catch(Exception ex)
            {
                return $"General error: {ex.Message}";
            }
            
        }
       
    }
}
