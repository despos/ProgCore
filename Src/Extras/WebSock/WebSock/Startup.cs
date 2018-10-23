using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebSock.Common;

namespace WebSock
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();

            // Only config purposes
            app.UseWebSockets();

            // Keep track of sockets and broadcast messages (implements chat logic here)
            app.UseMiddleware<ChatWebSocketMiddleware>();

            app.UseMvcWithDefaultRoute();
        }
    }
}
