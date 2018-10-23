//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.6.0)
//

namespace CountryFinder.Shared
{
    public class FooterSettings
    {
        public FooterSettings(int count)
        {
            TotalItems = count;
        }

        public int TotalItems { get; set; }
    }
}