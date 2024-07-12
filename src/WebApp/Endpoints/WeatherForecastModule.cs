using MediatR;
using WebApp.Swagger;

namespace WebApp.Endpoints
{
    public static class WeatherForecastModule
    {
        private const string ApiRouteBase = "";

        private static void AddWeatherForecastEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/WeatherForecast", async (
                        ISender sender,
                        CancellationToken ct
                    ) =>
                    Results.Ok(await sender.Send(new GetWeatherForecastsQuery(), ct)))
                //.RequireAuthorization(Permission.ProjectRead.ToString())
                .WithTags("WeatherForecast");
        }
        public static void UseWeatherForecastEndpoints(this IEndpointRouteBuilder app) => app.MapGroup(ApiRouteBase).AddWeatherForecastEndpoints();
    }
}
