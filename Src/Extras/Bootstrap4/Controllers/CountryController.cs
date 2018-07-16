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
            [Bind(Prefix = "p")] int pageIndex = 1)
        {
            var model = _countryService.GetSegment(pageIndex);

            //var result = new MultipleActionResult(
            //    PartialView("pv_country_grid", model),
            //    PartialView("pv_country_grid_pager", model));
            var result = PartialView("pv_country_grid", model);
            return result;
        }
    }
}