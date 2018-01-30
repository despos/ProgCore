//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR1.Application
{
    public class UpdaterHub : Hub
    {
        //public async Task Refresh(string connId)
        //{
        //    // RefreshPage must be available on the JS client
        //    await Clients.All.InvokeAsync("RefreshPage" /* no parameters */);
        //}
    }
}