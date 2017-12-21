//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Poco
//

using System;
using Ch04.Poco.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Ch04.Poco
{
    [Controller]
    public class Home 
    {
        [ActionContext]
        public ActionContext Context { get; set; }

        public IActionResult Today()
        {
            var obj = new ContentResult 
            {
                Content = DateTime.Now.ToString("ddd, d MMM")
            };
            return obj;
        }

        public IActionResult Html()
        {
            return new ContentResult()
            {
                Content = "<h1>Hello</h1>",
                ContentType = "text/html",
                StatusCode = 200
            };
        }

        public IActionResult Index(
            [FromServices] IModelMetadataProvider provider)
        {
            var viewdata = new ViewDataDictionary<MyClass>(provider, new ModelStateDictionary());
            viewdata.Model = new MyClass() { Title = "Hi there!" };
            return new ViewResult() { ViewData = viewdata, ViewName = "index" };
        }

        public IActionResult Simple()
        {
            return new ViewResult() { ViewName = "simple" };
        }

        public IActionResult Http([FromQuery] int p = 0)
        {
            var controller = Context.RouteData.Values["controller"];
            return new ContentResult() { Content = p.ToString() };
        }       
    }
}
