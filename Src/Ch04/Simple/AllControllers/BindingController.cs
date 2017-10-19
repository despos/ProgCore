//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using System.Collections.Generic;
using System.Text;
using Ch04.Simple.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch04.Simple.AllControllers
{
    public class BindingController : Controller
    {
        [Route("moveto/{city}")]
        public IActionResult Visit(
            [FromQuery] string city)
        {
            return Ok(city);
        }

        public IActionResult Repeat(string text, int number)
        {
            var builder = new StringBuilder();
            for(var i=0; i<number; i++)
            {
                builder.AppendFormat("{0}, ", text);
            }
            return Ok(builder.ToString());
        }

        public IActionResult Repeat1(RepeatText input)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < input.Number; i++)
            {
                builder.AppendFormat("{0}, ", input.Text);
            }
            return Ok(builder.ToString());
        }

        public IActionResult Email(
            [Bind(Prefix="email")] IList<string> emails)
        {
            return View();
        }
    }
}
