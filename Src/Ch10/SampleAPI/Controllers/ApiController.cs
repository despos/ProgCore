//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using System;
using Ch10.SampleApi.Application;
using Ch10.SampleApi.Application.Formatters;
using Microsoft.AspNetCore.Mvc;

namespace Ch10.SampleApi.Controllers
{   
    public class ApiController : Controller
    {
        [HttpGet]
        public IActionResult Today(int o = 0)
        {
            return Content(DateTime.Today.AddDays(o).ToString("d MMM yyyy"), "text/plain");
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

        public IActionResult Weather(int days = 3, string format = "json")
        {
            var q = new WeatherService().GetForecasts("721943", "c");
            if (format == "xml")
                return Content(ForecastsXmlFormatter.Serialize(q), "text/xml");
            return Json(q);
        }
    }
}