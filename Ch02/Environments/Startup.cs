//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito 
//   
//   Ch02 - The First ASP.NET Core Project 
//   Environments
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ch02.Environments
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory factory)
        {
            // Use them if required
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/app/error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }


            app.Run(async (context) =>
            {
                await context.Response
                    .WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!" +
                                "<hr>" +
                                "CONFIGURE<br>" +
                                //"TYPE=StartupDevelopment<br>" + 
                                "ENVIRONMENT=" + env.EnvironmentName);
            });
        }

        // (DEVELOPMENT mode)
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                await context.Response
                    .WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!" +
                                "<hr>" +
                                //"TYPE=StartupDevelopment<br>" + 
                                "ENVIRONMENT=" + env.EnvironmentName);
            });
        }
        // (PRODUCTION mode)
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                await context.Response
                    .WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!" +
                                "<hr>" +
                                "TYPE=StartupProduction<br>" +
                                "ENVIRONMENT=" + env.EnvironmentName);
            });
        }
        // (WHATEVER mode)
        public void ConfigureWhatever(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                await context.Response
                    .WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!" +
                                "<hr>" +
                                "TYPE=StartupWhatever<br>" +
                                "ENVIRONMENT=" + env.EnvironmentName);
            });
        }
    }
}
