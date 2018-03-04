//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Config
//  

using Ch07.Config.Application;
using Ch07.Config.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ch07.Config.Controllers
{
    public class RandomController : Controller
    {
        private readonly IRandomCustomerService _service;

        public RandomController(IRandomCustomerService service)
        {
            _service = service;
        }
    }
}