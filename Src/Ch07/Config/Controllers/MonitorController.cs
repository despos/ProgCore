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

/*
 * IOptionsMonitor is NOT really useful unless you're using
 * SignalR to refresh the UI or some internal parameters.
 * IOptionsSnapshot is all you need to reload strongly-typed
 * config on next request.
 * IPostConfigureOptions for making further changes once config
 * is done.
 * 
 * services.PostConfigure<MyOptions>(myOptions =>
 * {
 *   myOptions.Option1 = "post_configured_option1_value";
 * });
 * 
 */

namespace Ch07.Config.Controllers
{
    public class MonitorController : Controller
    {
        private readonly GeneralSettings _settings = new GeneralSettings();

        public MonitorController(IOptionsMonitor<GeneralSettings> monitor)
        {
            monitor.OnChange(currentSettings => 
                _settings.Paging.PageSize = 100+currentSettings.Paging.PageSize);
        }
        public IActionResult Index()
        {
            ViewData["PageSize"] = _settings.Paging.PageSize;
            return View();
        }
    }
}