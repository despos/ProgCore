//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch14 - The ASP.NET Core Runtime Environment
//   Builder
//

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Ch14.Builder
{
    public class Startup  
    {
        IConfiguration _configuration; 

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true);
            if (env.IsDevelopment())
            {
                builder.AddJsonFile("appsettings.development.json", true);
            }
            builder.AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IApplicationLifetime life)
        {
            // Configures a graceful shutdown of the application
            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);
            life.ApplicationStopped.Register(OnStopped);

            // Runtime configuration
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
        }

        #region Application Lifetime Events
        private static void OnStarted()
        {
            // Perform post-startup activities here
            Console.WriteLine("Started\n=====");
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        private static void OnStopping()
        {
            // Perform on-stopping activities here
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("=====\nStopping\n=====\n");
        }

        private static void OnStopped()
        {
            // Perform post-stopped activities here
            var defaultForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Stopped.");
            Console.ForegroundColor = defaultForeColor;
            Console.WriteLine("Press any key.");
            Console.ReadLine();
        }

        #endregion
    }
}
