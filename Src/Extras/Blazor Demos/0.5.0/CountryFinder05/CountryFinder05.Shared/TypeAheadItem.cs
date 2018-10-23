//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.5.0)
//

namespace CountryFinder05.Shared
{
    public class TypeAheadItem
    {
        // Display text for the drop-down list (may contains HTML styles)
        public string MenuText { get; set; }

        // Unique ID of the returned item
        public string Value { get; set; }

        // Value to copy in the textbox
        public string DisplayText { get; set; }
    }
}