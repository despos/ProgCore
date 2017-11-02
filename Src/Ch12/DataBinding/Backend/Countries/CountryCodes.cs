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

    public class GeoRectangle
    {
        public double West { get; set; }
        public double East { get; set; }
        public double North { get; set; }
        public double South { get; set; }
    }

    public class CountryCodes
    {
        public string tld { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string fips { get; set; }
        public int isoN { get; set; }
    }   
}