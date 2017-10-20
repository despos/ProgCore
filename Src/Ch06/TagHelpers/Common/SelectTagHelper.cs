//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   TagHelpers
//

using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ch06.TagHelpers.Common
{
    [HtmlTargetElement("select")]
    public class SelectTagHelper : TagHelper
    {
        [HtmlAttributeName("sk-notspecified-text")]
        public string NotSpecifiedText { get; set; }

        [HtmlAttributeName("sk-notspecified-value")]
        public string NotSpecifiedValue { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrWhiteSpace(NotSpecifiedText))
                NotSpecifiedText = "---";
            if (string.IsNullOrWhiteSpace(NotSpecifiedValue))
                NotSpecifiedValue = "";

            output.Content.AppendHtml("<option>" + NotSpecifiedText + "</option>");
            var childContent = (await output.GetChildContentAsync()).GetContent();
            output.Content.AppendHtml(childContent);
        }
    }
}
