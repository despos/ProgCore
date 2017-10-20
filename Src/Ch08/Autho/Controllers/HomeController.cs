//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Autho
// 

using Ch08.Autho.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch08.Autho.Controllers
{
    public class HomeController : Controller
    {        
        // ACTIONS
        public IActionResult Index()
        {
            var model = new IndexViewModel("");
            return View(model);
        }
    }
}
