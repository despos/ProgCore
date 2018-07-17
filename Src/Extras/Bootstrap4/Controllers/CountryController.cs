///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using Bs4.Application;
using Microsoft.AspNetCore.Mvc;

namespace Bs4.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryService _countryService = new CountryService();
        

        public ActionResult List(
            [Bind(Prefix = "p")] int pageIndex = 1,
            [Bind(Prefix = "q")] string filter = "")
        {
            var model = _countryService.GetSliceOf(pageIndex, filter);
            var result = PartialView("pv_country_grid", model);
            return result;
        }
    }
}