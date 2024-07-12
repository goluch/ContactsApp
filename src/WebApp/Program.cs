var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddWebAppServices(builder.Configuration);

var app = builder.Build();

app.UseInfrastructureServices();
app.UseWebAppServices();

app.Run();
