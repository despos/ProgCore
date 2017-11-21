//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Middleware
//

using Microsoft.AspNetCore.Builder;

namespace Ch14.Middleware.Common.Components
{
    public static class MobileDetectionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMobileDetection(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MobileDetectionMiddleware>();
        }
    }
}
