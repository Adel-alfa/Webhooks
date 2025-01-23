using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Webhooks.Models;
using Webhooks.Services;

namespace Webhooks.Endpoints
{
    public static class WebhookEndpoints
    {
       
        public static void MapWebhookEndpoints(this IEndpointRouteBuilder app, IConfiguration configuration)
        {
            var WebhooksGroup = app.MapGroup("api/webhooks");

            WebhooksGroup.MapPost("/", async (HttpContext httpContext, IWeather service, CancellationToken cancellationToken) => {
                if (!httpContext.Request.Headers.ContainsKey("Authorization"))
                {                   
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Unauthorized");
                    return;
                }

                var apiKey = httpContext.Request.Headers["Authorization"];
                var configurationKey = configuration.GetSection("apiKey").Value;
                
                if (apiKey != configurationKey)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Unauthorized");
                    return;
                }
                var requestBody = await httpContext.Request.ReadFromJsonAsync<WeatherData>();
                

                if (requestBody == null)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    await httpContext.Response.WriteAsync("Unprocessable Entity: malformed or invalid Entity");
                    return;

                }
                 await service.AddAsync(requestBody, cancellationToken);
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                await httpContext.Response.WriteAsync("Webhook: Request processed successfully");
            
            });

            
        }
    }
}
