//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using Ch09.EfCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ch09.EfCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _service;
        public HomeController(HomeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var model = _service.GetHomeViewModel();
            return View(model);
        }
    }
}
