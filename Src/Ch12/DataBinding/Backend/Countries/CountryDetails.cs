//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   DataBinding
//

using System.Collections.Generic;

namespace Ch12.DataBinding.Backend.Countries
{
    public class CountryDetails
    {
        public string Name { get; set; }
        public Capital Capital { get; set; }
        public GeoRectangle GeoRectangle { get; set; }
        public int SeqID { get; set; }
        public List<double> GeoPt { get; set; }
        public string TelPref { get; set; }
        public CountryCodes CountryCodes { get; set; }
        public string CountryInfo { get; set; }
    }
}