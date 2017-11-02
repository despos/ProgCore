//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch01 - Why Another (ASP).NET
//   HelloWorldWeb
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Ch01.HelloWorldWeb
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
