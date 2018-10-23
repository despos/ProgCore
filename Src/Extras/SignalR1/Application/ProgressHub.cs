//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR1.Application
{
    public class ProgressHub : Hub
    {
        private static int Count = 0;
        public override Task OnConnectedAsync()
        {
            //Count++;
            Interlocked.Increment(ref Count);

            base.OnConnectedAsync();
            Clients.All.SendAsync("updateCount", Count);
            Clients.All.SendAsync("connected", Context.ConnectionId);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            //Count--;
            Interlocked.Decrement(ref Count);

            base.OnDisconnectedAsync(exception);
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }
    }
}