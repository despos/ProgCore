///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Collections.Generic;
using System.Linq;
using Bs4.Backend;
using Bs4.Common;
using Expoware.Youbiquitous.Core.Extensions;

namespace Bs4.Application
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();
        private Paginator<Country> _countryPaginator;

        public SlicedList<Country> GetSliceOf(int pageIndex, string filterToApply = "")
        {
            string FilterSource(Country country) => string
                .Format("{0} {1}", country.CountryName, country.ContinentName);

            _countryPaginator = new Paginator<Country>(_countryRepository.All().ToList(), filterToApply);
            _countryPaginator.InstallFilterSource(FilterSource);

            return _countryPaginator.Take(pageIndex);
        }
    }
}