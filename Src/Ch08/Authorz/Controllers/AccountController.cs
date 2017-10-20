//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Ch08.Authorz.Common;
using Ch08.Authorz.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ch08.Authorz.Controllers
{
    public class AccountController : MyControllerBase
    {
        public AccountController(IOptions<GlobalConfig> config)
        {
            Configuration = config.Value;
        }

        [HttpGet]
        public IActionResult Login(LoginViewModel input)
        {
            if (input == null)
                input = new LoginViewModel();

            var td = TempData["Login-Error"] as string;
            if (td != null)
            {
                input.ErrorMessage = td;
            }

            return View(input);
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> TryLogIn(LoginViewModel input)
        {
            // Validate credentials
            if (!ValidateCredentials(input.UserName, input.Password))
            {
                TempData["Login-Error"] = "Invalid credentials";
                return RedirectToAction("login", "account");
            }

            var actualRole = (input.UserName == "dino" ? "Admin" : "Guest");

            // Create the authentication cookie
            var claims = new[] {
                new Claim(ClaimTypes.Name, input.UserName),
                new Claim(ClaimTypes.Role, actualRole) };

            if (input.UserName == "leo")
            {
                claims = new[] {
                new Claim(ClaimTypes.Name, input.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("Hair", "Brown") };
            }

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.Name,
                ClaimTypes.Role);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return Redirect(input.ReturnUrl ?? "/");
        }

        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Forbidden(string returnUrl)
        {
            var model = new ViewModelBase(Configuration.Title) {ErrorMessage = $"from {returnUrl}"};
            return View(model);
        }



        private bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return false;

            return username.Equals(password, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
