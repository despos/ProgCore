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
    [Route("go/to/[action]")]
    public class VipTourController : Controller
    {
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

        [Route("for/{days}/days")]
        public IActionResult SanFrancisco(int days)
        {
            var action = string.Format("In {0} for {1} days", 
                RouteData.Values["action"].ToString(),
                days);
            return Ok(action);
        }
    }
}
