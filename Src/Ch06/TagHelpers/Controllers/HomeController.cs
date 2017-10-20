//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   TagHelpers
//

using Ch06.TagHelpers.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ch06.TagHelpers.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController(HomeService service)
        {
            _homeService = service;
        }

        public IActionResult Index()
        {
            var model = _homeService.GetHomeViewModel();
            return View(model);
        }

        public IActionResult Room()
        {
            var model = _homeService.GetRoomViewModel();
            return View(model);
        }
    }
}