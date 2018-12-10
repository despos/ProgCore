//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   BLAZOR demos
// 

using Forms.Server.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Server.Controllers
{
    //[Authorize]
    public class WeatherController : Controller
    {
        [AllowAnonymous]
        public IActionResult Now()
        {
            var wf = new WeatherService().Now("721943");
            return Json(wf); 
        }

        public IActionResult Forecasts()
        {
            var q = new WeatherService().GetForecasts("721943");
            return Json(q);
        }
    }
}