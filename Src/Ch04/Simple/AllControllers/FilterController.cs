//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ch04.Simple.AllControllers
{
    public class FilterController : Controller
    {
        protected DateTime StartTime;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.ActionDescriptor.RouteValues["action"];
            if (string.Equals(action, "index", StringComparison.CurrentCultureIgnoreCase))
            {
                StartTime = DateTime.Now;
            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var action = filterContext.ActionDescriptor.RouteValues["action"];
            if (string.Equals(action, "index", StringComparison.CurrentCultureIgnoreCase))
            {
                var timeSpan = DateTime.Now - StartTime;
                filterContext.HttpContext.Response.Headers.Add(
                        "duration", timeSpan.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
            }

            base.OnActionExecuted(filterContext);
        }
        
        public IActionResult Index()
        {
            var output = Content("Just processed Filter.Index");
            return output;
        }

        public IActionResult Google()
        {
            return Redirect("http://www.google.com");
        }

        public IActionResult GoRepeat()
        {
            var result = RedirectToAction(
                "repeat",
                "binding",
                new {text = "Dino", number = 4});
            return result;
        }
    }
}
