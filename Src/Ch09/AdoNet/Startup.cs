//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Securing the Application
//   AdoNet
// 

using System;
using System.IO;
using Ch09.AdoNet.Application;
using Ch09.AdoNet.Backend.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Ch09.AdoNet
{
    public class Startup
    { 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<HomeService>();
            services.AddTransient<SomeRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Local path to the DB (ignore if using SQL Server)
            var dbPath = Path.Combine(env.ContentRootPath, "App_Data", "ProgCore.mdf");

            YourDatabase.ConnectionString = !env.IsDevelopment()
                ? "production"
                :  String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Initial Catalog=progcore;Integrated Security=True", dbPath);

            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
