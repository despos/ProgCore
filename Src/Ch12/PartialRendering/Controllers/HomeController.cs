//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   PartialRendering
//

using Ch12.PartialRendering.Application;
using Ch12.PartialRendering.Backend;
using Ch12.PartialRendering.Common;
using Ch12.PartialRendering.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch12.PartialRendering.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerRepository _repository;

        public HomeController(CustomerRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var customers = _repository.FindAll();
            var model = new IndexViewModel(customers);
            return View(model);
        }

        [AjaxOnly]
        [RequireReferrer("/home/index", "/")]
        [HttpPost]
        [ActionName("d")]
        public ActionResult DeleteCustomer(int id)
        {
            _repository.Delete(id);
            var customers = _repository.FindAll();

            // Return 
            var model = new IndexViewModel(customers);
            var result = new MultiplePartialViewResult(
                PartialView(U.PartialViews.ListOfCustomers, model),
                PartialView(U.PartialViews.OnBehalfOfCustomers, model));
            return result;
        }
    }
}
