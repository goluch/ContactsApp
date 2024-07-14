using Ardalis.GuardClauses;
using System.Diagnostics.CodeAnalysis;

namespace WebApp.Infrastructure
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        {
            pattern = ConstructPattern(handler, pattern);
            builder.MapGet(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        {
            pattern = ConstructPattern(handler, pattern);
            builder.MapPost(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
        {
            pattern = ConstructPattern(handler, pattern);
            builder.MapPut(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
        {
            pattern = ConstructPattern(handler, pattern);
            builder.MapDelete(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        private static string ConstructPattern(Delegate handler, string pattern)
        {
            Guard.Against.AnonymousMethod(handler);
            pattern = (pattern == "") ? handler.Method.Name : handler.Method.Name + "/" + pattern;
            return pattern;
        }
    }
}
