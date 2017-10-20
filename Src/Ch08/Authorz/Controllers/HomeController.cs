//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using Ch08.Authorz.Common;
using Ch08.Authorz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ch08.Authorz.Controllers
{
    public class HomeController : MyControllerBase
    {        
        private ILogger Logger { get; set; }

        public HomeController(IOptions<GlobalConfig> config)
        {
            Configuration = config.Value;
        }


        // ACTIONS
        public IActionResult Index()
        {
            var model = new IndexViewModel(Configuration.Title);
            return View(model);
        }
    }
}
