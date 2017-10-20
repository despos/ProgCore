//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch05 - ASP.NET MVC Views
//   JustViews
//

using Ch05.JustViews.Models;

namespace Ch05.JustViews.Application
{
    public class HomeService : ApplicationServiceBase, IHomeService
    {
        public HomeViewModel GetHomeViewModel()
        {
            return new HomeViewModel("Page title");
        }
    }
}