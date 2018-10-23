//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalAzure.Application;
using SignalAzure.Models;

namespace SignalAzure.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<UserCountHub> _userCountContext;

        public HomeController(IHubContext<UserCountHub> userCountContext)
        {
            _userCountContext = userCountContext;
        }

        public IActionResult Index()
        {
            return View(ViewModelBase.Default());
        }
    }
}