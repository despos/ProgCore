//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//


using CountryFinder05.Server.Application;
using Microsoft.AspNetCore.Mvc;

namespace CountryFinder05.Server.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryService _service = new CountryService();
        
        public ActionResult Details(
            [Bind(Prefix = "id")] string code)
        {
            return Json(_service.GetCountryViewModel(code));
        }

        public ActionResult Search(
            [Bind(Prefix = "id")] string filter)
        {
            return Json(_service.GetCountryListViewModel(filter));
        }
    }
}