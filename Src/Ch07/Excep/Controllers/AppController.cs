//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Except
// 

using System.Net;
using Ch07.Except.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Ch07.Except.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Error([Bind(Prefix = "id")] int statusCode = 0)
        {
            // Switch to the appropriate page
            //switch (statusCode)
            //{
            //    case 404:
            //        return Redirect(...);
            //        ...
            //}

            var model = new ErrorViewModel();

            // Retrieve error information in case of internal errors
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (error == null)
                return View(model);

            // IMPORTANT
            // Set the status code to 200 if you want to see the page. Otherwise,
            // the current status code (likely, 500) will be sent with the correct HTML
            // of the view invoked below.
            Response.StatusCode = 200;
            
            // Use the information stored in the detected exception object.
            model.Error = error.Error;
            return View(model);
        }
    }
}