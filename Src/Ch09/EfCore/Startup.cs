//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using System;
using System.IO;
using Ch09.EfCore.Application;
using Ch09.EfCore.Backend.Persistence;
using Ch09.EfCore.Backend.Persistence.DomainServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Ch09.EfCore
{
    public class Startup
    { 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<HomeService>();
            services.AddSingleton<RecordService>();
            services.AddSingleton<RecordRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var dbPath = Path.Combine(env.ContentRootPath, "App_Data", "ProgCoreEf.mdf");

            YourDatabase.ConnectionString = !env.IsDevelopment()
                ? "production"
                :  String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Initial Catalog=ProgCore_Ef;Integrated Security=True", dbPath);
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();

            var db = new YourDatabase();
            db.Database.EnsureCreated();
            //db.EnsureSeedData();
        }
    }
}
