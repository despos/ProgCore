//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   Echo
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Ch02.Echo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .Configure(app => {
                    app.Run(async (context) => {
                        var path = context.Request.Path;
                        await context.Response.WriteAsync("<h1>" + path + "</h1>");
                    });
                })
                .Build();
            host.Run();
        }
    }
}
