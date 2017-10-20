//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   ViewEngine
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Ch05.ViewEngine.Common
{
    public class MultiTenantViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var tenant = context.ActionContext.HttpContext.Request.GetDisplayUrl();
            context.Values["tenant"] = "contoso";  //tenant;
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (!context.Values.ContainsKey("tenant") || 
                string.IsNullOrWhiteSpace(context.Values["tenant"]))
                return viewLocations;

            var overriddenViewNames = viewLocations
                .Select(f => f.Replace("/Views/", "/Views/" + context.Values["tenant"] + "/"))
                .Concat(viewLocations)
                .ToList();
            return overriddenViewNames;
        }
    }
}