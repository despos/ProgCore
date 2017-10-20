//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch11 - Posting Data from Client-side
//   SimpleForms
//

using System;
using System.IO;
using Ch11.SimpleForms.Application;
using Ch11.SimpleForms.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ch11.SimpleForms.Controllers
{
    public class DemoController : Controller
    {
        private readonly HomeService _service;
        private readonly IHostingEnvironment _env;
        public DemoController(HomeService service, IHostingEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public IActionResult Multiple(string input, Options option)
        {
            var model = _service.GetHomeViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult UploadForm()
        {
            var model = _service.GetHomeViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadForm(FormInputModel input, IFormFile picture)
        {
            if (picture.Length > 0)
            {
                var fileName = Path.GetFileName(picture.FileName);
                var filePath = Path.Combine(_env.ContentRootPath, "Uploads", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }
            }

            // Get the connection string from the Azure portal
            //var storageAccount = CloudStorageAccount.Parse("connection string");
            //var blobClient = storageAccount.CreateCloudBlobClient();
            //var container = blobClient.GetContainerReference("my-container");
            //container.CreateIfNotExistsAsync();
            //var blockBlob = container.GetBlockBlobReference("my-blob");
            //using (var stream = new MemoryStream())
            //{
            //    picture.CopyTo(stream);
            //    blockBlob.UploadFromStreamAsync(stream);
            //}

            // Now return
            var success = DateTime.Now.Second % 2;
            if (success > 0)
                return Json(CommandResponse.Ok.AddMessage("Operation completed successfully"));
            return Json(CommandResponse.Fail.AddMessage("Couldn't complete the operation"));
        }
    }
}
