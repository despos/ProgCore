//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - Azure
//

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalAzure.Application
{
    public class UserCountHub : Hub
    {
        private static int _count;

        public override Task OnConnectedAsync()
        {
            _count++;
            base.OnConnectedAsync();
            this.Clients.All.SendAsync("updateCount", _count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _count--;
            base.OnDisconnectedAsync(exception);
            this.Clients.All.SendAsync("updateCount", _count);
            return Task.CompletedTask;
        }

        public string GetConnectionId()
        {
            return this.Context.ConnectionId;
        }
    }
}