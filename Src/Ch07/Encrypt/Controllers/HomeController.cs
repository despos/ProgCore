//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch07 - Design Considerations
//   Encrypt
//   

using Ch07.Encrypt.Backend;
using Microsoft.AspNetCore.Mvc;

namespace Ch07.Encrypt.Controllers
{
    public class HomeController : Controller
    {
        private Repository _repo;
        public HomeController(Repository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            // INIT FOR DEMO PURPOSES
            //var demo = new Customer
            //{
            //    Name = "Contoso",
            //    City = "London",
            //    Country = "UK"
            //};
            //_repo.Save(demo);


            var customer = _repo.Load();
            var model = new IndexViewModel();
            model.TheCustomer = customer;
            return View(model);
        }

        public IActionResult Save()
        {
            var customer = _repo.Load();
            _repo.Save(customer);
            return RedirectToAction("index");
        }
    }
}