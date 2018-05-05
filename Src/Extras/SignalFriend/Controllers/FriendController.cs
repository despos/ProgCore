//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalFriend.Application;
using SignalFriend.Backend;

namespace SignalFriend.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private readonly IHubContext<FriendHub> _friendHubContext;

        public FriendController(IHubContext<FriendHub> friendHubContext)
        {
            _friendHubContext = friendHubContext;
        }

        public IActionResult Index()
        {
            var model = BackendService.GetUserModel(User.Identity.Name);  
            return View(model);
        }

        [HttpPost]
        public IActionResult Remove(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) 
                return RedirectToAction("index", "friend");
            
            var currentUser = User.Identity.Name;
            UserRepository.RemoveFriend(id, currentUser);

            // Refresh my UI
            _friendHubContext.Clients.User(currentUser).SendAsync("refreshUI");

            // Notify the removed user (if connected)
            _friendHubContext.Clients.User(id).SendAsync("removed", currentUser);

            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Add(string friend)
        {
            if (string.IsNullOrWhiteSpace(friend)) 
                return RedirectToAction("index", "friend");
            
            var currentUser = User.Identity.Name;
            UserRepository.AddFriend(currentUser, friend);

            // Refresh my UI
            _friendHubContext.Clients.User(currentUser).SendAsync("refreshUI");

            // Notify the added user (if connected)
            _friendHubContext.Clients.User(friend).SendAsync("added", currentUser);

            return new EmptyResult();
        }

        [HttpGet]
        public IActionResult List()
        {
            return PartialView("pv_ListOfFriends",
                BackendService.GetUserModel(User.Identity.Name));
        }
    }
}
