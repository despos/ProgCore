//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR1.Application
{
    public class ProgressHub : Hub
    {
        private static int Count = 0;
        public override Task OnConnectedAsync()
        {
            Count++;
            base.OnConnectedAsync();
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;
            base.OnDisconnectedAsync(exception);
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        //public void Lengthy()
        //{
        //    // logic
        //    Clients.Client(Context.ConnectionId).SendAsync("initProgressBar");
        //}

        //public void NotifyStart()
        //{
        //    //var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
        //    //hubContext.Clients.Client(connId).initProgressBar();
        //    Clients.Client(Context.ConnectionId).InvokeAsync("initProgressBar");
        //}

        //public void NotifyProgress(int percentage)
        //{
        //    //var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
        //    //Clients.Client(connId).updateProgressBar(percentage, connId);
        //    Clients.Client(Context.ConnectionId).InvokeAsync("updateProgressBar", percentage);
        //}

        //public void NotifyEnd()
        //{
        //    //var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
        //    //hubContext.Clients.Client(connId).clearProgressBar();
        //    Clients.Client(Context.ConnectionId).InvokeAsync("clearProgressBar");
        //}
    }
}