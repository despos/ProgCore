//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   DataBinding
//

namespace Ch12.DataBinding.Backend.Countries
{
    public class Country
    {
        public string StatusMsg { get; set; }
        public CountryDetails Results { get; set; }
        public int StatusCode { get; set; }
    }
}