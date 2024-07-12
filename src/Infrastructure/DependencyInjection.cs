using Ardalis.GuardClauses;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Domain.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddSwaggerGen();
        services.AddCors();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services
            .AddIdentityApiEndpoints<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthorization(options =>
        options.AddPolicy(Policies.CanViewSecrets, policy => policy.RequireRole(Roles.Administrator)));

        services.AddAuthorizationBuilder();
        services.AddAntiforgery();

        return services;
    }

    public static void UseInfrastructureServices(this WebApplication app)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocExpansion(DocExpansion.None);
                c.EnableFilter();
                c.EnableDeepLinking();
            });
            //app.UseCors(x => x
            //    .AllowCredentials()
            //    .WithOrigins("http://localhost:4200")
            //    .AllowAnyHeader()
            //    .AllowAnyMethod());
        }
        else
        {
            app.UseExceptionHandler();
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAntiforgery();

        app.MapControllers();
        app.MapIdentityApi<ApplicationUser>();
    }

}
