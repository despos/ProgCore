//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch12 - Client-side data binding
//   PartialRendering
//

using Ch12.PartialRendering.Models;

namespace Ch12.PartialRendering.Application
{
    public class HomeService
    {
        public HomeViewModel GetHomeViewModel()
        {
            var model = new HomeViewModel();
            return model;
        }
    }
}
