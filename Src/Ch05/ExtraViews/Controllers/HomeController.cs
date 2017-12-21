//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   JustViews
//

using Ch05.JustViews.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ch05.JustViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService service)
        {
            _homeService = service;
        }

        public IActionResult Index()
        {
            var model = _homeService.GetHomeViewModel();
            ViewData["Color"] = "orange";
            ViewBag.Color = "cyan";
            return View(model);
        }
    }
}