//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Autho
// 

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ch08.Autho.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Mvc;

namespace Ch08.Autho.Controllers
{
    public class AccountController : Controller
    {
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
            var claims = new[]
            {
                new Claim("DogName", input.UserName),
                new Claim(ClaimTypes.Role, actualRole),
                new Claim("Picture", ""),
            };
            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                "DogName",
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

        [HttpGet]
        public IActionResult Forbidden(string returnUrl)
        {
            var model = new ViewModelBase("");
            model.ErrorMessage = $"from {returnUrl}";
            return View(model);
        }

        //public async Task G()
        //{
        //    var props = new AuthenticationProperties
        //    {
        //        RedirectUri = "/" // where to go after authenticating
        //    };
        //    await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, props);
        //}

        public async Task T()
        {
            var props = new AuthenticationProperties
            {
                 RedirectUri = Url.Action("External", "Account")

            };
            await HttpContext.ChallengeAsync(TwitterDefaults.AuthenticationScheme, props);
        }

        public async Task<IActionResult> External()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("TEMP");
            var principal = authenticateResult.Principal;
            var newClaims = principal.Claims.Append(new Claim("Foo", "Foo"));
            var newIdentity = new ClaimsIdentity(newClaims, authenticateResult.Ticket.AuthenticationScheme);
            var newPrincipal = new ClaimsPrincipal(newIdentity);

            // Do something with the principal
            // (ie, create a new principal with additional information) 
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, newPrincipal);
            await HttpContext.SignOutAsync("TEMP");
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
