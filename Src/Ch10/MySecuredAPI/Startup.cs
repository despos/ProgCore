//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   MySecuredApi
//

using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ch10.MySecuredAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization(options =>
                {
                    options.AddPolicy("internal-only-policy", builder =>
                    {
                        // This requires defining SCOPES with matching names
                        // in the IdSrv client API resource. The scope MUST  be
                        // communicated to the caller app.
                        builder.RequireScope("FULL");

                        // In this case, the claim is set to the client 
                        // and MUST NOT be communicated to the caller app.
                        //builder.RequireClaim("client_scope", "internal");
                    });
                })
                .AddJsonFormatters();


            // SECURE THE API with IDENTITY SERVER
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(x =>
                {
                    x.Authority = "http://localhost:6000";
                    x.ApiName = "weather-API";
                    x.RequireHttpsMetadata = false;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
