//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch13 - Building Device-friendly Views
//   RoutingViews
//


using Ch13.RoutingViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch13.RoutingViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = ViewModelBase.Default();
            return View(model);
        }
    }
}
