//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   UserSecrets
// 

using Ch07.UserSecrets.Application;
using Ch07.UserSecrets.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//-("this-is-mine-8084c8e7-0000-0000-b266-b33f42dd88c0")]
namespace Ch07.UserSecrets
{
    public class Startup
    {
        public IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("MyAppSettings.json", optional: true);
            if (env.IsDevelopment())
                builder.AddUserSecrets<MyAppSecretConfig>();
            if (env.IsProduction())
                builder.AddEnvironmentVariables();

            var dom = builder.Build();

            // Save the configuration root object to a startup member for further references
            Configuration = dom;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            //services.Configure<MyAppSecretConfig>(options => Configuration.Bind(options));
            services.Configure<MyAppSecretConfig>(Configuration);
            services.AddSingleton<IMiscService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
