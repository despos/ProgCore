//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   Blazor - Country Finder (0.6.0)
//

using System;

namespace CountryFinder.Shared.Model
{
    public partial struct Country
    {
        private const string Template = "<div class='panel panel-primary' style='display: inline-block'>" +
                                        "<div class='panel-heading'>" +
                                        "<h3 class='panel-title'>{0} ({1})</h3>" +
                                        "</div>" +
                                        "<div class='panel-body'>" +
                                        "<img src='{6}' />" +
                                        "<span class='pull-right text-muted'>{2}</span>" +
                                        "<dl class='dl-horizontal'><dt>Capital</dt><dd>{3}</dd></dl>" +
                                        "<dl class='dl-horizontal'><dt>Population</dt><dd>{4}</dd></dl>" +
                                        "<dl class='dl-horizontal'><dt>Currency</dt><dd>{5}</dd></dl>" +
                                        "</div></div>";
       
        public string ToPanel()
        {
            return String.Format(Template,
                CountryName,
                CountryCode,
                ContinentName,
                Capital,
                Population,
                CurrencyCode,
                "/content/images/flags/" + CountryCode + ".png'");
        }
    }
}
