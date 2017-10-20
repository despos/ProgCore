//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Securing the Application
//   EfCore
// 

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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
