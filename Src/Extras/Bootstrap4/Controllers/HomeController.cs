//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Bs4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bs4.Controllers
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
