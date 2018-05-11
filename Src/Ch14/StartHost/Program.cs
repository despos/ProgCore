//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   StartHost
//

using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Ch14.StartHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var host = WebHost.Start(
                app => app.Response.WriteAsync("<h1>Programming ASP.NET Core</h1>")))
            {
                // Wait for the host to end
                Console.WriteLine("Courtesy of 'Programming ASP.NET Core'\n====");
                Console.WriteLine("Use Ctrl-C to shutdown the host...");
                host.WaitForShutdown();
            }

            //WebHost.CreateDefaultBuilder(args)
            //    .UseKestrel(options =>
            //     {
            //         options.Limits.MaxConcurrentConnections = 100;
            //         options.Limits.MaxConcurrentUpgradedConnections = 100;
            //         options.Limits.MaxRequestBodySize = 10 * 1024;
            //         options.Limits.MinRequestBodyDataRate =
            //             new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            //         options.Limits.MinResponseDataRate =
            //             new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            //         options.Listen(IPAddress.Loopback, 5000);
            //         options.Listen(IPAddress.Loopback, 5001, listenOptions =>
            //         {
            //             listenOptions.UseHttps("testCert.pfx", "testPassword");
            //         });
            //     });
        }
    }
}
