//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Bs4.Models;
using Microsoft.AspNetCore.Mvc;
using SignalR1.Backend;
using SignalR1.Models;

namespace Bs4.Controllers
{
    public class DemoController : Controller
    {
        private readonly CustomerRepository _repository;

        public DemoController(CustomerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Updater()
        {
            var customers = _repository.FindAll();
            var model = new CustomersViewModel(customers) {Title = "UPDATER"};
            return View(model);
        }

        public IActionResult Progress()
        {
            var model = ViewModelBase.Default("REMOTE TASK");
            return View(model);
        }

        [HttpPost]
        [ActionName("d")]
        public IActionResult DeleteCustomer(int id)
        {
            _repository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult List()
        {
            var customers = _repository.FindAll();
            var model = new CustomersViewModel(customers);
            return PartialView("pv_ListOfCustomers", model);
        }
    }
}
