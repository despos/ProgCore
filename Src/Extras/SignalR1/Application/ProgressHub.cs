//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using Microsoft.AspNetCore.SignalR;

namespace SignalR1.Application
{
    public class ProgressHub : Hub
    {
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