//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Core;
using Microsoft.Extensions.DependencyInjection;
using SignalFriend.Application;

namespace SignalFriend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddMvc();
            services.AddSignalR();
            services.AddSingleton(typeof(IUserIdProvider), typeof(MyUserIdProvider));

            // Add classic COOKIE scheme
            services.AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.Cookie.Name = "YourAppCookieName";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = new PathString("/Account/Denied");
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            // Enable security
            app.UseAuthentication();

            // Add MVC
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            // SignalR (must go AFTER authentication)
            app.UseSignalR(routes =>
            {
                routes.MapHub<FriendHub>("/friendDemo");
            });
        }
    }
}
