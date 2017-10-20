//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   ViewEngine
//  

using Microsoft.AspNetCore.Mvc.Razor.Extensions;
using Microsoft.AspNetCore.Razor.Language;

namespace Ch05.ViewEngine.Common
{
    public class SpyTemplateEngine : MvcRazorTemplateEngine
    {
        public SpyTemplateEngine(RazorEngine engine, RazorProject project)
            : base(engine, project)
        {
        }

        public override RazorCSharpDocument GenerateCode(RazorCodeDocument codeDocument)
        {
            var csharpDocument = base.GenerateCode(codeDocument);
            var generatedCode = csharpDocument.GeneratedCode;

            // Look at generatedCode

            return csharpDocument;
        }
    }

}