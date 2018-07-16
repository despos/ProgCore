///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

namespace Bs4.Backend
{
    // Declared STRUCT to avoid memrefs overlapping in LINQ

    public partial struct Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public string Population { get; set; }
        public string Capital { get; set; }
        public string ContinentName { get; set; }
        public string Continent { get; set; }
        public string AreaInSqKm { get; set; }
        public string Languages { get; set; }
        public string GeonameId { get; set; }

        public string PopulationFormatted()
        {
            double people = 0;
            var outcome = double.TryParse(Population, out people);
            return outcome 
                ? string.Format("{0:n0}", people) 
                : Population;
        }

        public string AreaFormatted()
        {
            double area = 0;
            var outcome = double.TryParse(AreaInSqKm, out area);
            return outcome
                ? string.Format("{0:n0}", area)
                : AreaInSqKm;
        }
    }
}