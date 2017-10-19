//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   MiniWeb
//

namespace Ch02.MiniWeb.Persistence.Model
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
    }
}