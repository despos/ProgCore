//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch06 - The Razor Syntax 
//   TagHelpers
//

using Ch06.TagHelpers.Models;

namespace Ch06.TagHelpers.Application
{
    public class HomeService : ApplicationServiceBase
    {
        public HomeViewModel GetHomeViewModel()
        {
            return new HomeViewModel("Ch06");
        }

        public RoomViewModel GetRoomViewModel()
        {
            var model = new RoomViewModel("Ch06")
            {
                RoomTypes = new[] {"SINGLE", "DOUBLE", "TWIN"},
                CurrentRoomType = RoomCategories.Single
            };
            return model;
        }
    }
}