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
    [HtmlTargetElement("content", ParentTag = "modal")]
    public class ModalContentTagHelper : TagHelper
    {
        public override async Task ProcessAsync(
            TagHelperContext context, TagHelperOutput output)
        {
            // Evaluate the Razor content of the element's body 
            var body = (await output.GetChildContentAsync()).GetContent();
            body = body.Trim();

            // Replace <toggle> with <button> 
            output.TagName = "div";
            var modalContext = context.Items[typeof(ModalContext)] as ModalContext;
            if (modalContext == null)
                throw new ArgumentException();
           
            // Prepare output
            output.Attributes.SetAttribute("class", "modal");
            output.Attributes.SetAttribute("id", modalContext.Id);
            output.Content.AppendHtml("<div class='modal-dialog'><div class='modal-content'>");
            output.Content.AppendHtml(body);
            output.Content.AppendHtml("</div></div>");
        }
    }
}

