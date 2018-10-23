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
using WebSock.Models;

namespace WebSock.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = "New user";
            var model = new ViewModelBase() {UserName = user};
            return View(model);
        }

        [HttpGet]
        public IActionResult Chatroom(string u)
        {
            var model = new ViewModelBase() { UserName = u };
            return View(model);
        }


        [HttpPost]
        public IActionResult Login(string username)
        {
            return RedirectToAction("chatroom", new {u= username });
        }
    }
}