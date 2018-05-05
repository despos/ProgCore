//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

using Microsoft.AspNetCore.Mvc;
using SignalFriend.Models;

namespace SignalFriend.Controllers
{
    public class HomeController : Controller
    {        
        // ACTIONS
        public IActionResult Index()
        {
            var model = new IndexViewModel("") {CurrentUser = HttpContext.User.Identity.Name};
            return View(model);
        }
    }
}
