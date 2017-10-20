//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch08 - Securing the Application
//   Authorz
// 

using Ch08.Authorz.Common;
using Microsoft.AspNetCore.Mvc;

namespace Ch08.Authorz.Controllers
{
    public class MyControllerBase : Controller
    {
        protected GlobalConfig Configuration { get; set; }
    }
}
