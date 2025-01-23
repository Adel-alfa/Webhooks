using Webhooks.Services;

namespace Webhooks.Endpoints
{
    public static class WeatherEndpoints
    {

        public static void MapWeatherEndpoints(this IEndpointRouteBuilder app)
        {
            var WeatherGroup = app.MapGroup("api/weather");

            WeatherGroup.MapGet("/{id:guid}", async (Guid id, IWeather service, CancellationToken cancellationToken) =>
            {
                var data = await service.GetByIdAsync(id, cancellationToken);
                if (data == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(data);
            });

            WeatherGroup.MapGet("", async (IWeather service, CancellationToken cancellationToken) =>
            {
                var data = await service.GetAllAsync(cancellationToken);
                return Results.Ok(data);
            });

            WeatherGroup.MapGet("/fromto/{from:datetime}/{to:datetime}", async (DateTime from, DateTime to, IWeather service, CancellationToken cancellationToken) =>
            {
                var data = await service.GetFromToAsync(from, to, cancellationToken);
                return Results.Ok(data);
            });
        }
    }
}
