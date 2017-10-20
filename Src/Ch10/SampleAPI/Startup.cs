//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ch10.SampleApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Map("/api/file", DownloadFile);
        }

        private static void DownloadFile(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var id = context.Request.Query["id"];
                var document = string.Format("sample-{0}.pdf", id);
                await context.Response.SendFileAsync(document);
            });
        }

    }
}
