//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   AdoNet
// 

using System;
using System.IO;
using Ch09.AdoNet.Application;
using Ch09.AdoNet.Common;
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

            ConnectionStrings.ProgCore = !env.IsDevelopment()
                ? "production"
                :  String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Initial Catalog=progcore;Integrated Security=True", dbPath);

            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
