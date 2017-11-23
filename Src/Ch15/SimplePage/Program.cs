//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch15 - Deploying an ASP.NET Core Application
//   SimplePage
//

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ch15.SimplePage
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
