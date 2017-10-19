//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   Environments
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Ch02.Environments
{
    public class GlobalAsax
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("GLOBALASAX<br>");
                await context.Response.WriteAsync("Courtesy of <b>Programming ASP.NET Core</b>!");
            });
        }
    }
}
