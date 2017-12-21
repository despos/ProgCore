//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   UserSecrets
//   

using Ch07.UserSecrets.Application;
using Ch07.UserSecrets.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ch07.UserSecrets.Controllers
{
    public class HomeController : Controller
    {
        protected MyAppSecretConfig Secrets;

        public HomeController(IOptions<MyAppSecretConfig> config, IMiscService misc)
        {
            Secrets = config.Value;
        }

        public IActionResult Index()
        {
            ViewData["config"] = Secrets;
            return View();
        }
    }
}