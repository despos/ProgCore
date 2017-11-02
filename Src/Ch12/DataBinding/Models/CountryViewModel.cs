//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   DataBinding
//

using System.Collections.Generic;

namespace Ch12.DataBinding.Models
{
    public class CountryViewModel : ViewModelBase
    {
        public CountryViewModel(IList<string> codes)
        {
            CountryCodes = codes;
        }

        public IList<string> CountryCodes { get; set; }
    }
}