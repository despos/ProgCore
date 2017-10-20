//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   BootstrapTagHelpers
//

using Ch06.BootstrapTagHelpers.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ch06.BootstrapTagHelpers.Controllers
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
    }
}