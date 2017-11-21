//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Middleware
//

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ch14.Middleware.Common.Components
{
    public class MobileDetectionMiddleware
    {
        private readonly RequestDelegate _next;

        public MobileDetectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Parse the user-agent to "guess" if it's a mobile device.
            // WARNING: the logic used here is quite naive :)  
            var isMobile = context.IsMobileDevice();
            context.Items["MobileDetectionMiddleware_IsMobile"] = isMobile;

            // Yields
            await _next(context);

            // Provide some UI only as a proof of existence
            var msg = isMobile ? "MOBILE DEVICE" : "NOT A MOBILE DEVICE";
            await context.Response.WriteAsync("<hr>" + msg + "<hr>");
        }
    }
}
