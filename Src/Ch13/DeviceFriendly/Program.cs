//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch13 - Building Device-friendly Views
//   DeviceFriendly
//

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Ch13.DeviceFriendly
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
