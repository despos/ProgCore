//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SignalR1.Application;
using SignalR1.Backend;

// Microsoft.AspNetCore.SignalR
// Microsoft.AspNetCore.SignalR.Client

namespace SignalR1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<CustomerRepository>();
            services.AddSingleton<ClockService>();

            // SignalR
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            // SignalR
            app.UseSignalR(routes =>
            {
                routes.MapHub<UpdaterHub>("/updaterDemo");
                routes.MapHub<ProgressHub>("/progressDemo");
                routes.MapHub<ClockHub>("/clockDemo");
            });

            app.UseMvcWithDefaultRoute();

        }
    }
}
