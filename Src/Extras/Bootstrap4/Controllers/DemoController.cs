//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   BS4
//

using System;
using Bs4.Backend;
using Bs4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bs4.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Media()
        {
            return View(ViewModelBase.Default("MEDIA"));
        }

        public IActionResult Modal()
        {
            return View(ViewModelBase.Default("MODAL DIALOGS"));
        }

        public IActionResult Card()
        {
            return View(ViewModelBase.Default("CARDS"));
        }

        public IActionResult DataTable()
        {
            return View(ViewModelBase.Default("TABLE"));
        }

        public IActionResult File()
        {
            return View(ViewModelBase.Default("FILE"));
        }

        public IActionResult Form1()
        {
            return View(ViewModelBase.Default("FORM1"));
        }

        [HttpGet]
        public IActionResult Form2()
        {
            return View(ViewModelBase.Default("FORM2"));
        }

        [HttpPost]
        public IActionResult Form2(string username, string password)
        {
            var success = DateTime.Now.Second % 2 >0;
            return Content(success ? "OK" : "Fail");
        }

        [HttpGet]
        public IActionResult Form3()
        {
            return View(ViewModelBase.Default("FORM3"));
        }

        [HttpPost]
        public IActionResult Form3(string username, string password)
        {
            var success = DateTime.Now.Second % 2 > 0;
            return Content(success ? "OK" : "Fail");
        }
    }
}
