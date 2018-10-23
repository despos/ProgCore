//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.6.0)
//


using System.Collections.Generic;
using System.Linq;
using CountryFinder.Server.Backend.Persistence;
using CountryFinder.Server.Common;
using CountryFinder.Shared.Model;

namespace CountryFinder.Server.Application
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();

        public Country GetCountryViewModel(string code)
        {
            var country = _countryRepository.Find(code);
            country.Population = country.Population.ToIntFormat();
            country.AreaInSqKm = country.AreaInSqKm.ToIntFormat();
            return country;
        }

        public IList<Country> GetCountryListViewModel(string filter = "")
        {
            var all = new CountryRepository().All();
            if (string.IsNullOrWhiteSpace(filter))
                return all.ToList();

            var list = (from country in all
                let match = string.Format("{0} {1} {2} {3}",
                        country.CountryCode,
                        country.CountryName,
                        country.ContinentName,
                        country.CurrencyCode)
                    .ToLower()
                where match.Contains(filter.ToLower())
                select country);
            return list.ToList();
        }
    }
}