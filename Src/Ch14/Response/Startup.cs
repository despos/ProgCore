//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Response
//

using System.IO;
using System.Threading.Tasks;
using Ch14.Response.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Ch14.Response
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Add a sample response header 
            app.Use(async (context, nextMiddleware) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("Book", "Programming ASP.NET Core");
                    return Task.FromResult(0);
                });
                await nextMiddleware();
            });

            app.Use(async (context, nextMiddleware) =>
            {
                using (var memory = new MemoryStream())
                {
                    var originalStream = context.Response.Body;
                    context.Response.Body = memory;

                    await nextMiddleware();


                    memory.Seek(0, SeekOrigin.Begin);
                    var content = new StreamReader(memory).ReadToEnd();
                    memory.Seek(0, SeekOrigin.Begin);

                    // Apply logic here for deciding which headers to add
                    context.Response.Headers.Add("Body", content);

                    await memory.CopyToAsync(originalStream);
                    context.Response.Body = originalStream;
                }
            });

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
