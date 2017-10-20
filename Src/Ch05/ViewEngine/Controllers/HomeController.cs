//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   ViewEngine
//

using Ch05.ViewEngine.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Ch05.ViewEngine.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Url"] = Request.GetDisplayUrl();

            var rudy = new Dog {Name = "Rudy"};
            ViewBag.MyDogName = rudy;
            ViewBag.Url = Request.GetDisplayUrl();

            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}