//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch15 - Deploying an ASP.NET Core Application
//   SimplePage
//

using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ch15.SimplePage.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; private set; } = String.Empty;

        public void OnGet()
        {
            Message += DateTime.Now.ToString("HH:mm");
        }
    }
}
