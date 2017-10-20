//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   JustViews
//

using Ch05.JustViews.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ch05.JustViews
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            builder.AddViews();
            builder.AddRazorViewEngine();

            services.AddSingleton<IHomeService, HomeService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
