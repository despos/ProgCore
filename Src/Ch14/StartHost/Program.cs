//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   StartHost
//

using System;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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
        }
    }
}
