using Application.Common.Interfaces;
using Azure.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApp.Infrastructure;
using WebApp.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAppServices(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddKeyVaultIfConfigured(configuration);

            //To usunąć z Weather forecatem
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IUser, CurrentUser>();

            services.AddHttpContextAccessor();

            services.AddExceptionHandler<CustomExceptionHandler>();


            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddEndpointsApiExplorer();

            return services;
        }

        public static void UseWebAppServices(this WebApplication app)
        {
            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            //app.UseRouting();

            app.MapFallbackToFile("/index.html");
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
