///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Linq;
using Bs4.Backend;
using Bs4.Common;

namespace Bs4.Application
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();
        private Paginator<Country> _countryPaginator; 


        public SegmentedList<Country> GetSegment(int pageIndex)
        {
            if (_countryPaginator == null)
                _countryPaginator = new Paginator<Country>(_countryRepository.All().ToList());

            return _countryPaginator.Take(pageIndex);
        }
    }
}