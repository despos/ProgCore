//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   MiniWeb
//

using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MiniWeb.Persistence;
using MiniWeb.Persistence.Abstractions;
using Newtonsoft.Json;

namespace MiniWeb
{
    public class Startup
    {
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository>(new CountryRepository());
         //   services.AddSingleton<ICountryRepository, CountryRepository>();
        }

        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env/*, ICountryRepository country*/, IServiceProvider provider)
        {
            app.Map("/country", countryApp =>
            {
                countryApp.Run(async (context) =>
                {
                    var country = provider.GetService<ICountryRepository>();
                    var query = context.Request.Query["q"];
                    var list = country.AllBy(query).ToList();
                    var json = JsonConvert.SerializeObject(list);

                    await context.Response.WriteAsync(json);
                });
            });

            // Work as a catch-all
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Invalid call");
            });

            //app.Run(async (context) =>
            //{
            //    var country = provider.GetService<ICountryRepository>();
            //    var query = context.Request.Query["q"];
            //    var list = country.AllBy(query).ToList();
            //    var json = JsonConvert.SerializeObject(list);

            //    await context.Response.WriteAsync(json);
            //});
        }
    }
}
