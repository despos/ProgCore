//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//  

using Ch07.Config.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ch07.Config.Controllers
{
    public class ConfigController : Controller
    {
        private readonly GeneralSettings _settings;

        public ConfigController(IOptionsSnapshot<GeneralSettings> settings)
        {
            _settings = settings.Value;
        }
        public IActionResult Index()
        {
            ViewData["PageSize"] = _settings.Paging.PageSize;
            return View();
        }
    }
}