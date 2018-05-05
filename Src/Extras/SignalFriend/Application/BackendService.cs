//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
//  

using SignalFriend.Backend;
using SignalFriend.Models;

namespace SignalFriend.Application
{
    public class BackendService
    {
        public static IndexViewModel GetUserModel(string currentUser)
        {
            var users = UserRepository.FriendsOf(currentUser);
            var model = new IndexViewModel("")
            {
                Friends = users,
                CurrentUser = currentUser
            };
            return model;
        }
    }
}