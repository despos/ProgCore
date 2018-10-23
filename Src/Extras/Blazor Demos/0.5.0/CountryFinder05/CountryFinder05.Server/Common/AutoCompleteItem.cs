//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//

namespace CountryFinder05.Server.Common
{
    public class AutoCompleteItem
    {
        // Display text for the drop-down list (contains HTML styles)
        public string label { get; set; }

        // Unique ID of the returned item
        public string id { get; set; }

        // Value to copy in the textbox
        public string value { get; set; }
    }
}