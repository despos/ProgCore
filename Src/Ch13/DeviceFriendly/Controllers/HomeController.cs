//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch13 - Building Device-friendly Views
//   DeviceFriendly
//


using Ch13.DeviceFriendly.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch13.DeviceFriendly.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = ViewModelBase.Default();
            return View(model);
        }

        public IActionResult Pic()
        {
            var model = ViewModelBase.Default();
            return View(model);
        }
    }
}
