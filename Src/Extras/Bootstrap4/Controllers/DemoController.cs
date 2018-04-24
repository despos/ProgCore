//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   BS4
//

using Bs4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bs4.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Media()
        {
            return View(ViewModelBase.Default("MEDIA"));
        }
    }
}
