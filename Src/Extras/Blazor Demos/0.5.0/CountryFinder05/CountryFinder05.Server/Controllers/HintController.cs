//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//


using System.Linq;
using CountryFinder05.Server.Backend.Persistence;
using CountryFinder05.Server.Common;
using CountryFinder05.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CountryFinder05.Server.Controllers
{
    public class HintController : Controller
    {       
        public JsonResult Countries(string filter = "")
        {
            var all = new CountryRepository().All();
            var list = (from country in all
                let match =
                    $"{country.CountryCode} {country.CountryName} {country.ContinentName} {country.CurrencyCode}".ToLower()
                where match.Contains(filter.ToLower())
                select new AutoCompleteItem()
                {
                    id = country.CountryCode,
                    value = country.CountryName
                }).ToList();

            return Json(list);
        }

        public JsonResult Countries1(
            [Bind(Prefix = "id")] string filter = "")
        {
            var all = new CountryRepository().All();
            var list = (from country in all
                let match =
                    $"{country.CountryCode} {country.CountryName} {country.ContinentName} {country.CurrencyCode}".ToLower()
                where match.Contains(filter.ToLower())
                select new TypeAheadItem()
                {
                    Value = country.CountryCode,
                    DisplayText = country.CountryName,
                    MenuText = $"{country.CountryName} <b>{country.ContinentName}</b><span class='pull-right'>{country.Capital}</span>"
                }).ToList();

            return Json(list);
        }
    }
}