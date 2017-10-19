//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch03 - Bootstrapping ASP.NET MVC 
//   RoutesEx
//

using Ch03.RouteEx.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace Ch03.RoutesEx
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            builder.AddViews();
            builder.AddRazorViewEngine();

            // DEMO:
            services.Configure<RouteOptions>(options =>
                    options.ConstraintMap.Add("your", typeof(YourRouteConstraint)));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "catch-all",
                    template: "{*url}",
                    defaults: new { controller = "home", action = "index" },
                    constraints: new { },
                    dataTokens: new { reason = "catch-all" });
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
