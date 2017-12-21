//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using Ch09.EfCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace Ch09.EfCore.Controllers
{
    public class RecordController : Controller
    {
        private readonly RecordService _service;
        public RecordController(RecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult New()
        {
            var model = _service.GetNewRecordViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult New(string firstname, string lastname)
        {
            _service.SaveRecord(firstname, lastname);
            return RedirectToAction("index", "home");
        }
    }
}
