//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   AttrRouting
//

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ch04.AttrRouting
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
