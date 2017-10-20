//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   MySecuredApi
//

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Application;
using MyAPI.Application.Formatters;

namespace Ch10.MySecuredAPI.Controllers
{   
    [Authorize]
    public class WeatherController : Controller
    {
        public IActionResult Now()
        {
            var user = HttpContext.User;
            var temp = new WeatherService().Now("721943", "c");
            return Content(temp, "text/plain");
        }

        [Authorize(Policy = "internal-only-policy")]
        public IActionResult Forecasts(int days = 3, string format = "json")
        {
            var user = HttpContext.User;
            var q = new WeatherService().GetForecasts("721943", "c");
            if (format == "xml")
                return Content(ForecastsXmlFormatter.Serialize(q), "text/xml");
            return Json(q);
        }
    }
}