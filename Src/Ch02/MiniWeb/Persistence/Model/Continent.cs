//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch02 - The First ASP.NET Core Project 
//   MiniWeb
//

using System.ComponentModel;

namespace Ch02.MiniWeb.Persistence.Model
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