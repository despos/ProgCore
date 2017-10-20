//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   BootstrapTagHelpers
//

using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ch06.BootstrapTagHelpers.Common
{
    [HtmlTargetElement("modal")]
    public class ModalTagHelper : TagHelper
    {
        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            var autoClose = false;
            if (output.Attributes.ContainsName("autoclose"))
                Boolean.TryParse(output.Attributes["autoclose"].Value.ToString(), out autoClose);


            // Create the context for child elements
            var modalContext = new ModalContext
            {
                Id = output.Attributes["id"].Value.ToString(),
                AutoClose = autoClose
            };
            context.Items[typeof(ModalContext)] = modalContext;

            // Replace <modal> with <div> 
            output.TagName = "div";
            output.Attributes.Remove(context.AllAttributes["id"]);
            output.Attributes.Remove(context.AllAttributes["autoclose"]);
        }
    }
}

