//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   Environments
//

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ch02.Environments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseStartup<GlobalAsax>()
                //.UseStartup(Assembly.GetEntryAssembly().GetName().Name)
                .UseStartup<Startup>()
                .Build();
    }
}
