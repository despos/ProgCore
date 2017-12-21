//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   MiniWeb
//

using System;
using System.Linq;
using Ch02.MiniWeb.Persistence;
using Ch02.MiniWeb.Persistence.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Ch02.MiniWeb
{
    public class Startup
    {
        // Use this method to add services to the ASP.NET system container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Pass your own instance
            services.AddSingleton<ICountryRepository>(new CountryRepository());

            // Or, in alternative, let the system create one
            //services.AddSingleton<ICountryRepository, CountryRepository>();
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env/*, ICountryRepository country*/, 
            IServiceProvider provider)
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

            // Try this code to see that without app.Map the same output is served for each URL
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
