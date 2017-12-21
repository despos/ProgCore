//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ch04.Simple.AllControllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string controller)
        {
            return View();
        }
        
        public async Task<IActionResult> Async()
        {
            var t1 = Thread.CurrentThread.ManagedThreadId.ToString();
            var client = new HttpClient();
            var before = DateTime.Now;

            await client.GetStringAsync("http://youbiquitous.net");

            var after = DateTime.Now;
            var t2 = Thread.CurrentThread.ManagedThreadId.ToString();
            return Content(string.Concat("FIRST THREAD=", t1, " / SECOND THREAD=", t2));
        }
    }
}
