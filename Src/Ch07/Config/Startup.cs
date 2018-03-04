//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//   

using System.Collections.Generic;
using Ch07.Config.Application;
using Ch07.Config.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ch07.Config
{
    public class Startup
    {
        //public IConfiguration Config { get; set; }
        //public Startup(IConfiguration config)
        //{
        //    // Auto-configuration (appsettings.json and env variables)
        //    Config = config;
        //}

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var dom = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("MyAppSettings.json", optional: true, reloadOnChange: true)
                .AddInMemoryCollection(new Dictionary<string, string> {{"Timezone", "+1"}})
                .AddEnvironmentVariables()
                .Build();

            // Save the configuration root object to a startup member for further references
            Configuration = dom;
            var x0 = Configuration.GetValue<string>("ApplicationTitle");
            var x1 = Configuration.GetValue<int>("Timezone");
            var x2 = Configuration.GetValue<int>("GeneralSettings:Paging:PageSize");
            var x3 = Configuration.GetSection("GeneralSettings").GetValue<int>("Paging:PageSize");
            var x4 = Configuration["GeneralSettings:Paging:PageSize"];
            var tz = x1;
            //Configuration.Reload();
            var x5 = Configuration["GeneralSettings:Paging:PageSize"];
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();

            // Place your logic here to decide how to resolve ICustomerService
            //services.AddTransient<IRandomCustomerService, RandomCustomerService>();
            services.AddTransient<IRandomCustomerService>(provider =>
            {
                if (true)
                    return new RandomCustomerService();
            });

            services.AddSingleton(Configuration);
            services.Configure<GeneralSettings>(Configuration.GetSection("GeneralSettings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
