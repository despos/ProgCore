//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Builder
//

using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Ch14.Builder
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseKestrel()
                //.UseKestrel(options =>
                //    {
                //        options.Listen(IPAddress.Loopback, 5000);
                //        options.Listen(IPAddress.Loopback, 5001);
                //    }
                //)
                //.UseHttpSys()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://localhost:7000")
                .UseStartup(Assembly.Load(new AssemblyName("Ch14.Builder")).FullName)
                .Build();
            host.Run();
        }
    }
}
