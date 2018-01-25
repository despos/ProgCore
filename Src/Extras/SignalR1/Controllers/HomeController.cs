//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Microsoft.AspNetCore.Mvc;
using SignalR1.Backend;
using SignalR1.Models;

namespace SignalR1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerRepository _repository;

        public HomeController(CustomerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var customers = _repository.FindAll();
            var model = new CustomersViewModel(customers);
            return View(model);
        }
    }
}
