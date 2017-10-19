//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   Environments
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Ch02.Environments
{
    public class StartupWhatever
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                await context.Response
                .WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!" +
                    "<hr>" +
                    "TYPE=StartupWhatever<br>" +
                    "ENVIRONMENT=" + env.EnvironmentName);
            });
        }
    }
}
