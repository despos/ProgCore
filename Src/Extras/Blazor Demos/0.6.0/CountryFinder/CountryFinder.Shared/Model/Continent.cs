//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.6.0)
//

using System.ComponentModel;

namespace CountryFinder.Shared.Model
{
    public enum Continent
    {
        Unknown = 0,
        Europe = 1,
        Asia = 2,
        [Description("North America")]
        NorthAmerica = 3,
        [Description("South America")]
        SouthAmerica = 4,
        Africa = 5,
        Oceania = 6,
        Antarctica = 7
    }
}