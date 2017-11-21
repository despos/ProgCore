//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Middleware
//

using System;
using Ch14.Middleware.Common;
using Ch14.Middleware.Common.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Ch14.Middleware
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // MAP
            app.Map("/now", now =>
            {
                now.Run(async context =>
                {
                    var time = DateTime.UtcNow.ToString("HH:mm:ss (UTC)");
                    await context
                        .Response
                        .WriteAsync("<h1 style='color:red;'>" + time + "</h1>");
                });
            });

            // MAPWHEN
            app.MapWhen(
                context => context.Request.Query.ContainsKey("utc"),
                utc =>
                {
                    utc.Run(async context =>
                    {
                        var time = DateTime.UtcNow.ToString("HH:mm:ss (UTC)");
                        await context
                            .Response
                            .WriteAsync("<h1 style='color:blue;'>" + time + "</h1>");
                    });
                });

            // BEFORE/AFTER
            app.Use(async (context, nextMiddleware) =>
            {
                await context.Response.WriteAsync("BEFORE");
                await nextMiddleware();   
                await context.Response.WriteAsync("AFTER");
            });

            // BODY SIZE
            app.Use(async (context, nextMiddleware) =>
            {
                context.Features
                    .Get<IHttpMaxRequestBodySizeFeature>()
                    .MaxRequestBodySize = 10 * 1024;
                await nextMiddleware.Invoke();
            });

            // MOBILE
            // app.UseMiddleware<MobileDetectionMiddleware>();
            app.UseMobileDetection();

            app.Run(async (context) =>
            {
                var obj = new SomeWork();
                await context
                    .Response
                    .WriteAsync("<h1 style='color:red;'>" + obj.Now() + "</h1>");
            });
        }
    }
}
