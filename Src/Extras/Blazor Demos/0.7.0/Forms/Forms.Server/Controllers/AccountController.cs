//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   BLAZOR demos
// 

using Forms.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Server.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserViewModel input)
        {
            return Json(CommandResponse.Ok.AddMessage("Done"));
        }
    }
}