//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
//

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalFriend.Backend;

namespace SignalFriend.Application
{
    public class FriendHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            base.OnConnectedAsync();
            var user = Context.User.Identity.Name;
            //Groups.AddAsync(Context.ConnectionId, user);

            return Task.CompletedTask;
        }
    }
}