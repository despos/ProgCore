//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//

using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CountryFinder05.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            // Technically you should be able to change "app" with something else 
            // renaming the <app> injection point in index.html as well. But as of now (0.5.0)
            // it compiles but won't actually work as expected.
            
            app.AddComponent<MyApp>("app");
        }
    }
}
