//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Routes
//

using System;
using Microsoft.AspNetCore.Mvc;

namespace Routes.Implementation
{
    public class DateController : Controller 
    {
        public IActionResult Day(int offset)
        {
            var day = DateTime
                .Now
                .Date
                .AddDays(150 + offset)
                .ToString("ddd, d MMM yyyy");
            //var t = String.Format("{0}", day);
            return new ContentResult { Content = $"{day}" };
        }
    }
}
