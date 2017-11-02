//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   DataBinding
//

using System;
using System.Collections.Generic;
using System.Net;

namespace Ch12.DataBinding.Backend.Countries
{
    public class CountryRepository
    {
        // http://www.geognos.com/api/en/countries/info/FR.json 
        public IList<string> All()
        {
            return new[] {"FR", "IT", "CA", "US", "ES", "RU"};
        }

        public string Info(string id)
        {
            var url = String.Format("http://www.geognos.com/api/en/countries/info/{0}.json", id);
            try
            {
                var markup = new WebClient().DownloadString(url);
                return markup;
            }
            catch (Exception ex)
            {
                var x = ex;
                var y = x;
                return
                    "{\"StatusMsg\": \"OK\", \"Results\": {\"Name\": \"France\", \"Capital\": {\"DLST\": 1.0, \"TD\": 1.0, \"Flg\": 2, \"Name\": \"Paris\", \"GeoPt\": [48.52, 2.2]}, \"GeoRectangle\": {\"West\": -5.14222288132, \"East\": 9.56155776978, \"North\": 51.0928115845, \"South\": 41.3715744019}, \"SeqID\": 74, \"GeoPt\": [46.0, 2.0], \"TelPref\": \"33\", \"CountryCodes\": {\"tld\": \"fr\", \"iso3\": \"FRA\", \"iso2\": \"FR\", \"fips\": \"FR\", \"isoN\": 250}, \"CountryInfo\": \"http://www.geognos.com/geo/en/cc/fr.html\"}, \"StatusCode\": 200}";
            }
        }
    }
}