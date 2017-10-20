//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch11 - Posting Data from Client-side
//   SimpleForms
//

using Ch11.SimpleForms.Models;

namespace Ch11.SimpleForms.Application
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
