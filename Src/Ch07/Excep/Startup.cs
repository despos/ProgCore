//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Except
//    

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ch07.Except
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/App/Error/{0}");
            }
            else
            {
                app.UseExceptionHandler("/App/Error");
                app.UseStatusCodePagesWithReExecute("/App/Error/{0}");
            }

            // Add logging providers
            loggerFactory.AddConsole();
            env.EnvironmentName = EnvironmentName.Production;

            app.UseMvcWithDefaultRoute();
        }
    }
}
