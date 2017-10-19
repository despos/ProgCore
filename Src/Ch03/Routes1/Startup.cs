//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Routes
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace Routes
{
    public class Startup
    {
        // This method gets called by the runtime. 
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // DEMO:
            //services.AddMvc(options =>
            //{
            //    options.ModelBinderProviders.Add(new SmartDateBinderProvider());
            //    options.SslPort = 344;
            //});

            // Bare metal initialization of the ASP.NET MVC service
            var builder = services.AddMvcCore();
            builder.AddViews();
            builder.AddRazorViewEngine();

            // Add this only if your controllers return JSON strings
            builder.AddJsonFormatters();

            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // DEMO:
            //services.Configure<RouteOptions>(options =>
            //        options.ConstraintMap.Add("your", typeof(YourRouteConstraint)));

        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "route-today",
                    template: "today/{offset}",
                    defaults: new { controller = "date", action = "day", offset = 0 },
                    constraints: new { offset = new IntRouteConstraint() });
                routes.MapRoute(name: "route-yesterday",
                    template: "yesterday",
                    defaults: new { controller = "date", action = "day", offset = -1 });
                routes.MapRoute(name: "route-tomorrow",
                    template: "tomorrow",
                    defaults: new { controller = "date", action = "day", offset = 1 });
                routes.MapRoute(name: "route-day",
                    template: "date/day/{offset:int}",
                    defaults: new { controller = "date", action = "day", offset = 0 });
            });
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "catch-all",
            //        template: "{*url}",
            //        defaults: new { controller = "home", action = "index" },
            //        constraints: new { },
            //        dataTokens: new { reason = "catch-all" });
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "I'd rather say there are no configured routes here.");
            });
        }
    }
}
