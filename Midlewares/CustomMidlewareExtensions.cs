using Microsoft.AspNetCore.Builder;

namespace Day4.Midlewares
{
    public static class CustomMidlewareExtensions
    {
        public static IApplicationBuilder UseCustomMidleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMidleware>();
        }
    }
}