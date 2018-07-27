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

        //public ActionResult Find([Bind(Prefix = "id")] string code)
        //{
        //    return Json(_service.GetCountryViewModelForEdit(code));
        //}


        //public ActionResult More(string view, int from, int howMany = 10)
        //{
        //    var model = _service.GetCountryListViewModel();
        //    return PartialView(view, model.Countries.Skip(from).Take(howMany).ToList());
        //}

        //public ActionResult Page(
        //    [Bind(Prefix = "p")] int pageIndex = 1,
        //    [Bind(Prefix = "s")] int pageSize = 10)
        //{
        //    var model = _service.GetPagedCountryListViewModel(pageIndex, pageSize);

        //    var result = new MultipleActionResult(
        //        PartialView("pv_country_grid", model),
        //        PartialView("pv_country_grid_pager", model));
        //    return result;
        //}

        //public ActionResult List(
        //    [Bind(Prefix = "p")] int pageIndex = 1,
        //    [Bind(Prefix = "s")] int pageSize = 10)
        //{
        //    var model = _service.GetCountryListViewModelInPages(pageIndex, pageSize);

        //    //var result = new MultipleActionResult(
        //    //    PartialView("pv_country_grid", model),
        //    //    PartialView("pv_country_grid_pager", model));
        //    var result = PartialView("pv_country_grid", model.CountriesInPage);
        //    return result;
        //}
    }
}