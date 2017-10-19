//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch03 - Bootstrapping ASP.NET MVC 
//   RouteEx
//

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ch03.RouteEx.Common
{
    public class YourRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, 
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}