//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   BootstrapTagHelpers
//

using Ch06.BootstrapTagHelpers.Models;
using Ch06.BsTags.Application;

namespace Ch06.BootstrapTagHelpers.Application
{
    public class HomeService : ApplicationServiceBase
    {
        public HomeViewModel GetHomeViewModel()
        {
            return new HomeViewModel("");
        }
    }
}