//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   FileServer
//

using System.IO;
using Ch02.FileServer.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Ch02.FileServer
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, nextMiddleware) =>
            {
                // first pass here
                var isMobile = context.IsMobileDevice();
                context.Items["Mobile"] = isMobile;

                if (isMobile)
                {
                    await context.Response.WriteAsync("MOBILE DEVICE DETECTED");
                    return;
                }

                await nextMiddleware();   // optional, but ...

                // second pass here
            });
            
            // Enable serving files from the configured web root folder (i.e., WWWROOT)
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Enable serving files from \Assets located under the root folder of the site
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Assets")),
                RequestPath = new PathString("/Public/MyAssets")
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(context.Items["Mobile"].ToString());
            });
        }
    }
}
