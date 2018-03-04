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
    [Route("goto")]
    public class TourController : Controller
    {
        [Route("[controller]/[action]")]
        [ActionName("ny")]
        public IActionResult NewYork()
        {
            var action = RouteData.Values["action"].ToString();
            return Ok(action);
        }

        public IActionResult Chicago()
        {
            var action = RouteData.Values["action"].ToString();
            return Ok(action);
        }

        [NonAction]
        public IActionResult Orlando()
        {
            var action = RouteData.Values["action"].ToString();
            return Ok(action);
        }

        [Route("nyc")]
        public IActionResult NewYorkCity()
        {
            var action = RouteData.Values["action"].ToString();
            return Ok(action);
        }

        [Route("/ny")]
        public IActionResult BigApple()
        {
            var action = RouteData.Values["action"].ToString();
            return Ok(action);
        }
    }
}
