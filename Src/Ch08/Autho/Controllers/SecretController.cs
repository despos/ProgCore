//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Autho
// 

using Ch08.Autho.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ch08.Autho.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {        
        // ACTIONS
        public IActionResult Index()
        {
            var model = new IndexViewModel("");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin1()
        {
            var model = new IndexViewModel("");
            return View(model);
        }

        public IActionResult Guest1()
        {
            var model = new IndexViewModel("");
            return View(model);
        }
    }
}
