//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch11 - Posting Data from Client-side
//   LargeForms
//

using System;
using Ch11.LargeForms.Models;
using Forms.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Ch11.LargeForms.Controllers
{
    public class DemoController : Controller
    {
        private readonly HomeService _service;
        private readonly IHostingEnvironment _env;
        public DemoController(HomeService service, IHostingEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public IActionResult Multiple(string input, Options option)
        {
            var model = _service.GetHomeViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Large()
        {
            var model = _service.GetHomeViewModel();
            return View("largeform", model);
        }

        [HttpPost]
        public IActionResult SaveForm(LargeFormInputModel input)
        {
            var outcome = (DateTime.Now.Second % 2)>0;
            if (outcome)
                return Json(CommandResponse.Ok.AddMessage("Operation completed successfully"));
            return Json(CommandResponse.Fail.AddMessage("Couldn't complete the operation"));
        }
    }
}
