//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
//  

using System.Collections.Generic;
using System.Linq;
using SignalFriend.Backend;
using SignalFriend.Backend.Model;
using SignalFriend.Models;

namespace SignalFriend.Application
{
    public class BackendService
    {
        public static IndexViewModel GetUserModel(string currentUser)
        {
            var users = UserRepository.FriendsOf(currentUser);
            var model = new IndexViewModel("") {Friends = users};
            return model;
        }
    }
}