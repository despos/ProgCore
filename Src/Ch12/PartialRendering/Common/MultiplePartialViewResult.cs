//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   PartialRendering
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.DependencyInjection;


namespace Ch12.PartialRendering.Common
{
    public class MultiplePartialViewResult : ActionResult
    {
        public const string ChunkSeparator = "---|||---";

        public IList<PartialViewResult> PartialViewResults { get; }

        public MultiplePartialViewResult(params PartialViewResult[] results)
        {
            if (PartialViewResults == null)
                PartialViewResults = new List<PartialViewResult>();
            foreach (var r in results)
                PartialViewResults.Add(r);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var services = context.HttpContext.RequestServices;
            var executor = services.GetRequiredService<PartialViewResultExecutor>();

            var total = PartialViewResults.Count;
            var writer = new StringWriter();
            for (var index = 0; index < total; index++)
            {
                var pv = PartialViewResults[index];
                var view = executor.FindView(context, pv).View;
                var viewContext = new ViewContext(context,
                    view,
                    pv.ViewData, 
                    pv.TempData,
                    writer, 
                    new HtmlHelperOptions());
                await view.RenderAsync(viewContext);

                if (index < total - 1)
                    await writer.WriteAsync(ChunkSeparator);
            }
            
            await context.HttpContext.Response.WriteAsync(writer.ToString());
        }
    }
}