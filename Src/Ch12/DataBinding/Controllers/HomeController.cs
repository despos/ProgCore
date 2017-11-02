//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   DataBinding
//

using Ch12.DataBinding.Backend.Countries;
using Ch12.DataBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch12.DataBinding.Controllers
{
    public class HomeController : Controller
    {
        private readonly CountryRepository _repository;

        public HomeController(CountryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var countries = _repository.All();
            var model = new CountryViewModel(countries);
            return View(model);
        }

        public IActionResult Ko()
        {
            var countries = _repository.All();
            var model = new CountryViewModel(countries);
            return View(model);
        }

        public IActionResult Countries()
        {
            var countries = _repository.All();
            var model = new CountryViewModel(countries);
            return Json(model);
        }

        public string More(string id)
        {
            var x = _repository.Info(id);
            return x;
        }
    }
}
