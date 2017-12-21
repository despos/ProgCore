//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Ch10.SampleApi.Application;
using Ch10.SampleApi.Application.Formatters;
using Ch10.SampleApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace Ch10.SampleApi.Controllers
{   
    public class ApiController : Controller
    {
        [HttpGet]
        public IActionResult Today(int o = 0)
        {
            return Content(
                DateTime.Today.AddDays(o).ToString("d MMM yyyy"), 
                "text/plain");
        }

        public IActionResult Download(int id)
        {
            var document = string.Format("sample-{0}.pdf", id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(document);
            var result = File(fileBytes, "application/pdf", document);

            return result;
        }

        public IActionResult Echo([Bind(Prefix = "n")] int number)
        {
            return Json(new {data = 2 * number});
        }

        public IActionResult Obj([Bind(Prefix = "n")] int number)
        {
            var dto = new Dto
            {
                MoreDetails = {Today = DateTime.Today.AddDays(number).ToString("d MMM yyyy")},
                ValueToStore = number
            };
            return Json(dto);
        }

        public IActionResult Weather(int days = 3, string format = "json")
        {
            // Consider using MediaTypeNames constants to avoid magic strings like "json" or "xml".

            var q = new WeatherService().GetForecasts("721943", "c", days);
            if (format == "xml")
                return Content(
                    ForecastsXmlFormatter.Serialize(q), 
                    "text/xml");
            return Json(q);
        }

        public async Task<IActionResult> AsyncWeather(int days = 3, string format = "json")
        {
            // Consider using MediaTypeNames constants to avoid magic strings like "json" or "xml".

            var q = await new WeatherService()
                .GetForecastsAsync("721943", "c", days);
            if (format == "xml")
                return Content(
                    ForecastsXmlFormatter.Serialize(q),
                    "text/xml");
            return Json(q);
        }

        public async Task<IActionResult> Forecasts(int days = 3)
        {
            var q = await new WeatherService()
                .GetForecastsAsync("721943", "c", days);
            return Json(q.ForecastMax);
        }
    }
}