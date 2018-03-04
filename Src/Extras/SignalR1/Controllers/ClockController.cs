//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito  
//   
//   EXTRAS 
//   SignalR - 1
//

using Microsoft.AspNetCore.Mvc;
using SignalR1.Application;

namespace SignalR1.Controllers
{
    public class ClockController : Controller
    {
        private readonly ClockService _clockService;

        public ClockController(ClockService service)
        {
            _clockService = service;
        }

        public void Tick(/*[Bind(Prefix="id")] string connId*/)
        {
            _clockService.Tick();
        }
    }
}