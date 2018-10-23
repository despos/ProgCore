//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.6.0)
// 

namespace CountryFinder.Server.Common
{
    public static class MiscExtensions
    {
        /// <summary>
        /// Parse a given string to a number and format as a number
        /// </summary>
        /// <param name="theString">String to parse</param>
        /// <param name="defaultFormat">Default numeric format</param>
        /// <param name="defaultText">Text to return if not a number</param>
        /// <returns>Modified string</returns>
        public static string ToIntFormat(this string theString, string defaultFormat = "{0:n0}", string defaultText = "")
        {
            decimal number;
            var success = decimal.TryParse(theString, out number);
            if (!success)
                return theString;

            return string.Format(defaultFormat, number);
        }
    }
}