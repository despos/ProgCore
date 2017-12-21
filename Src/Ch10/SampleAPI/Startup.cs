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
            var builder = services.AddMvcCore();
            builder.AddJsonFormatters();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Map("/api/file", DownloadFile);

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
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
