//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Encrypt
//    

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ch07.Encrypt
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
