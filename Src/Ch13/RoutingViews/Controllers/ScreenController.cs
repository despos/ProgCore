//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch13 - Building Device-friendly Views
//   RoutingViews
//

using Microsoft.AspNetCore.Mvc;

namespace Ch13.RoutingViews.Controllers
{
    public class ScreenController : Controller
    {
        public IActionResult Default()
        {
            return PartialView();
        }
        public IActionResult Tablet()
        {
            return PartialView();
        }
        public IActionResult Smartphone()
        {
            return PartialView();
        }
	}
}