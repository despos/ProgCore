//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch03 - Bootstrapping ASP.NET MVC 
//   Routes
//

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ch03.RoutesEx.Implementation
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var catchall = RouteData.DataTokens["reason"] ?? "";

            var text = string.Format("{0}.{1} {2}", controller, action, catchall);
            var ar = new ContentResult { Content = text };
            return ar;
        }

        [Route("demo/{code}")]
        public IActionResult Read(
            Container container, 
            int number, 
            [FromQuery] int code, 
            string headeracceptlanguage, 
            [FromHeader] string language)
        {
            var lang = Request.Headers["Accept-Language"];
            return new ContentResult { Content = container.Number.ToString() };
        }
    }

    public class Container
    {
        [BindNever]
        public int Number { get; set; }

        public int Code { get; set; }
    }
}
