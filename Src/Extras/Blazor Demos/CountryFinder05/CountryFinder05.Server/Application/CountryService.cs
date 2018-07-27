//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//


using System.Collections.Generic;
using System.Linq;
using CountryFinder05.Server.Backend.Persistence;
using CountryFinder05.Server.Common;
using CountryFinder05.Shared.Model;

namespace CountryFinder05.Server.Application
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

        //public Country GetCountryViewModelForEdit(string code)
        //{
        //    var country = _countryRepository.Find(code);
        //    return country;
        //}

        //public CountryListViewModel GetCountryListViewModel()
        //{
        //    var all = _countryRepository.All().ToList();
        //    var model = new CountryListViewModel
        //    {
        //        Countries = all,
        //        Header = new HeaderViewModel(all.Count())
        //    };
        //    return model;
        //}

        //public PagedCountryListViewModel GetPagedCountryListViewModel(int pageIndex, int pageSize)
        //{
        //    var all = _countryRepository.All().ToList();
        //    var model = new PagedCountryListViewModel
        //    {
        //        Header = new HeaderViewModel(all.Count),
        //        CountriesInPage = new PagedList<Country>(all, pageIndex, pageSize)
        //    };
        //    return model;
        //}

        //public PagedCountryListViewModel GetCountryListViewModelInPages(int pageIndex, int pageSize)
        //{
        //    var all = _countryRepository.All().ToList();
        //    var model = new PagedCountryListViewModel
        //    {
        //        Header = new HeaderViewModel(all.Count),
        //        CountriesInPage = new PagedList<Country>(all, pageIndex, pageSize)
        //    };
        //    return model;
        //}
    }
}