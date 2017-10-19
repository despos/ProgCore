//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch03 - Bootstrapping ASP.NET MVC 
//   RoutesEx
//

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ch03.RoutesEx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
