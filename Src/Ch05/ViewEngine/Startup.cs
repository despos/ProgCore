//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   ViewEngine
//

using Ch05.ViewEngine.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.DependencyInjection;

namespace Ch05.ViewEngine
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddRazorOptions(options =>
                {
                    // {0} - Action Name
                    // {1} - Controller Name
                    // {2} - Area Name
                    options.ViewLocationFormats.Clear();
                    options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/Shared/Layouts/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Views/Shared/PartialViews/{0}.cshtml");
                    options.ViewLocationExpanders.Add(new MultiTenantViewLocationExpander());
                });

            // To spy C# hidden code generated for Razor views
            services.AddSingleton<RazorTemplateEngine, SpyTemplateEngine>();


            //services.AddMvc().AddViewOptions(options =>
            //{
            //    options.ViewEngines.Clear();
            //    options.ViewEngines.Add(typeof(MyRazorViewEngine));
            // });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvcWithDefaultRoute();
        }
    }
}
