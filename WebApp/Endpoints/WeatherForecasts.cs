using MediatR;
using WebApp.Infrastructure;

namespace WebApp.Endpoints
{
    public class WeatherForecast
    {
        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; init; }
    }

    public class WeatherForecasts : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .RequireAuthorization()
                .MapGet(GetWeatherForecasts);
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
        {
            return await sender.Send(new GetWeatherForecastsQuery());
        }
    }
    public record GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>;

    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
