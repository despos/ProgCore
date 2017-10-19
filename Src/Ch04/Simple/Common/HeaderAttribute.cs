//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using Microsoft.AspNetCore.Mvc.Filters;

namespace Ch04.Simple.Common
{
    public class HeaderAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!string.IsNullOrEmpty(Name) && 
                !string.IsNullOrEmpty(Value))
                filterContext
                    .HttpContext
                    .Response
                    .Headers
                    .Add(Name, Value);
        }
    }
}
