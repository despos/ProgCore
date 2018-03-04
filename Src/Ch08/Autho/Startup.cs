//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Autho
// 

using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace Ch08.Autho
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddMvc();

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
                })
                .AddTwitter(options =>
                {
                    options.SignInScheme = "TEMP";
                    options.ConsumerKey = "5XXqhC026jyD8QwKHRhbNFaWB";
                    options.ConsumerSecret = "1t8YNcjUAciR145zVG6JElVT215zonXXQlPwSiIz4cLXc69juC";
                })
                .AddGoogle(options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.ClientId = "498793679986-om97un6t1gukkmd62amd3r58qa8499ha.apps.googleusercontent.com";
                    options.ClientSecret = "UmA0KTBtGLpJRHd0I6B5LFCH";
                })
                .AddCookie("TEMP"); // required!
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            // Enable security
            app.UseAuthentication();

            // Add MVC
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
