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
    [HtmlTargetElement("email")]
    public class MyEmailTagHelper : TagHelper
    {
        public override async Task ProcessAsync(
            TagHelperContext context, TagHelperOutput output)
        {
            // Evaluate the Razor content of the email's element body 
            var body = (await output.GetChildContentAsync()).GetContent();
            body = body.Trim();

            // Replace <email> with <a> 
            output.TagName = "a";

            // Prepare mailto URL
            var to = context.AllAttributes["to"].Value.ToString();
            var subject = context.AllAttributes["subject"].Value.ToString();
            var mailto = "mailto:" + to;
            if (!string.IsNullOrWhiteSpace(subject))
                mailto = string.Format("{0}&subject={1}&body={2}", mailto, subject, body);

            // Prepare output
            output.Attributes.Remove(context.AllAttributes["to"]);
            output.Attributes.Remove(context.AllAttributes["subject"]);
            output.Attributes.SetAttribute("href", mailto);
            output.Content.Clear();
            output.Content.AppendFormat("Email {0}", to);
        }
    }
}

