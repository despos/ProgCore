//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Microsoft.AspNetCore.Mvc;
using SignalR1.Models;

namespace SignalR1.Controllers
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
