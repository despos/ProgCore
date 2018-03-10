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
using SignalR1.Application;
using SignalR1.Backend;
using SignalR1.Models;

namespace SignalR1.Controllers
{
    public class DemoController : Controller
    {
        private readonly CustomerRepository _repository;
        private readonly IHubContext<UpdaterHub> _updaterHubContext;

        public DemoController(
            CustomerRepository repository, 
            IHubContext<UpdaterHub> hubContext)
        {
            _repository = repository;
            _updaterHubContext = hubContext;
        }

        public IActionResult Updater()
        {
            var customers = _repository.FindAll();
            var model = new CustomersViewModel(customers) {Title = "UPDATER"};
            return View(model);
        }

        public IActionResult Clock()
        {
            var model = ViewModelBase.Default("SMART CLOCK");
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
            _updaterHubContext.Clients.All.SendAsync("refreshUI");
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
