//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.6.0)
//


using System.Linq;
using CountryFinder.Server.Backend.Persistence;
using CountryFinder.Server.Common;
using CountryFinder.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CountryFinder.Server.Controllers
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


        public JsonResult Countries2(
            [Bind(Prefix = "id")] string filter = "")
        {
            var all = new CountryRepository().All();
            var list = (from country in all
                let match =
                    $"{country.CountryCode} {country.CountryName} {country.ContinentName} {country.CurrencyCode}"
                        .ToLower()
                where match.Contains(filter.ToLower())
                select country).ToList();
                //select new TypeAheadItem()
                //{
                //    Value = country.CountryCode,
                //    DisplayText = country.CountryName,
                //    MenuText = $"{country.CountryName} <b>{country.ContinentName}</b><span class='pull-right'>{country.Capital}</span>"
                //}).ToList();

            return Json(list);
        }
    }
}