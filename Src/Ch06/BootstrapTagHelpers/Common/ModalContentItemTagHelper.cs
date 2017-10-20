//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   BootstrapTagHelpers
//

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ch06.BootstrapTagHelpers.Common
{
    [HtmlTargetElement("mheader", ParentTag = "content")]
    [HtmlTargetElement("mfooter", ParentTag = "content")]
    [HtmlTargetElement("mbody", ParentTag = "content")]
    public class ModalContentItemTagHelper : TagHelper
    {
        public override async Task ProcessAsync(
            TagHelperContext context, TagHelperOutput output)
        {
            var modalContext = context.Items[typeof(ModalContext)] as ModalContext;
            if (modalContext == null)
                throw new ArgumentException();

            // Evaluate the Razor content of the element's body 
            var body = (await output.GetChildContentAsync()).GetContent();
            body = body.Trim();

            // Prepare output
            var originalTagName = output.TagName;
            var className = GetBootstrapClassFromTagName(originalTagName);
            output.TagName = "div";
            output.Attributes.SetAttribute("class", className);

            // Support AUTO-CLOSE in header and footer
            if (modalContext.AutoClose)
            {
                if (string.Equals(originalTagName, ModalContext.HeaderTag, StringComparison.InvariantCultureIgnoreCase))
                {
                    var button = "<button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>";
                    output.Content.AppendHtml(button);
                    output.Content.AppendHtml(body);
                }
                if (string.Equals(originalTagName, ModalContext.FooterTag, StringComparison.InvariantCultureIgnoreCase))
                {
                    var button = "<button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\">OK</button>";
                    output.Content.AppendHtml(body);
                    output.Content.AppendHtml(button);
                }
            }
        }

        private static string GetBootstrapClassFromTagName(string tagName)
        {
            if (string.Equals(tagName, ModalContext.HeaderTag, StringComparison.InvariantCultureIgnoreCase))
                return "modal-header";
            if (string.Equals(tagName, ModalContext.FooterTag, StringComparison.InvariantCultureIgnoreCase))
                return "modal-footer";
            if (string.Equals(tagName, ModalContext.BodyTag, StringComparison.InvariantCultureIgnoreCase))
                return "modal-body";
            return "";
        }
    }
}

