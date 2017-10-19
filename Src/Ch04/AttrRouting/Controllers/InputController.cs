//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   AttrRouting
//

using Microsoft.AspNetCore.Mvc;

namespace Ch04.AttrRouting.Controllers
{
    public class InputController : Controller
    {
        public IActionResult Echo()
        {
            var data = Request.Query["today"];  
            return Ok(data);
        }

        public IActionResult Go()
        {
            // Capture data in a manual way from the URL template
            var city = RouteData.Values["city"];
            var days = RouteData.Values["days"];
            return Ok(string.Format("In {0} for {1} days", city, days));
        }
    }
}
