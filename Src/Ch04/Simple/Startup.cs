//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ch04.Simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            builder.AddViews();
            builder.AddRazorViewEngine();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new CultureAttribute());
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("...");

            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes => routes.MapRoute(
            //    name: "default",
            //    template: "{controller}/{action}/{id?}",
            //    defaults: new { controller = "Home", action = "Index" }
            //));

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Invalid URL");
            });
        }
    }
}
