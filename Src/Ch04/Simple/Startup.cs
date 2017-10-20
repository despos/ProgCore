//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using Microsoft.AspNetCore.Builder;
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

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hi everybody!");
            });
        }
    }
}
