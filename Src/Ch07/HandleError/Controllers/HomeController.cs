//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Except
//

using System;
using Microsoft.AspNetCore.Mvc;

namespace HandleError.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Throw()
        {
            throw new ArgumentException("Deliberately thrown exception");
        }
    }
}