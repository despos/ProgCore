//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SignalFriend.Models;

namespace SignalFriend.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(LoginViewModel input)
        {
            if (input == null)
                input = new LoginViewModel();

            if (TempData["Login-Error"] is string td)
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

            var actualRole = "Guest";

            // Create the authentication cookie
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, input.UserName),
                new Claim(ClaimTypes.Role, actualRole)
            };
            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.Name,
                ClaimTypes.Role);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
            return Redirect(input.ReturnUrl ?? "~/");
        }

        public async Task<IActionResult> Logout()
        {
           await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
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
