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
    [HtmlTargetElement("toggle", ParentTag = "modal")]
    public class ToggleTagHelper : TagHelper
    {
        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            // Replace <toggle> with <button> 
            output.TagName = "button";
            var modalContext = context.Items[typeof(ModalContext)] as ModalContext;
            if (modalContext == null)
                throw new ArgumentException();
           
            // Prepare output
            output.Attributes.SetAttribute("data-toggle", "modal");
            output.Attributes.SetAttribute("data-target", "#" + modalContext.Id);
        }
    }
}

