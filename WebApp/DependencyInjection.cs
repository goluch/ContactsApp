using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Azure.Identity;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApp.Infrastructure;
using WebApp.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            //To usunąć z Weather forecatem
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IUser, CurrentUser>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddExceptionHandler<CustomExceptionHandler>();


            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddEndpointsApiExplorer();

            services.AddOpenApiDocument((configure, sp) =>
            {
                configure.Title = "ContactsApp API";

            });

            return services;
        }

        public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
        {
            var keyVaultUri = configuration["KeyVaultUri"];
            if (!string.IsNullOrWhiteSpace(keyVaultUri))
            {
                configuration.AddAzureKeyVault(
                    new Uri(keyVaultUri),
                    new DefaultAzureCredential());
            }

            return services;
        }
    }
}
