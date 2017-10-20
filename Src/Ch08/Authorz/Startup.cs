//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using System;
using Ch08.Authorz.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ch08.Authorz
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("MyAppSettings.json");
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add option services  
            services.AddOptions();
            services.Configure<GlobalConfig>(Configuration.GetSection("Globals"));

            // Add framework services
            services.AddMvc();
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.Cookie.Name = "YourAppCookieName";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = new PathString("/Account/Denied");
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("MustBeRegisteredUser", policy =>
                {
                    policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
                config.AddPolicy("MustBeAdministrator", policy =>
                {
                    policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Admin");
                });
                config.AddPolicy("MustBeAdministratorWithBlondHair", policy =>
                {
                    policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Admin");
                    policy.RequireClaim("Hair", "Blond", "Brown");
                });
                //config.AddPolicy("GuestWithSpecialInitials", builder =>
                //{
                //    builder.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
                //    builder.RequireAuthenticatedUser();
                //    builder.AddRequirements(new InitialsRequirement("di"));
                //});
            });
            //services.AddSingleton<IAuthorizationHandler, InitialsAuthorizationHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
