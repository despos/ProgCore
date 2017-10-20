//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   AdoNet
// 

using Ch09.AdoNet.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ch09.AdoNet.Controllers
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
