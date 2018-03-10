//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalR1.Application
{
    public class ClockService 
    {
        private readonly IHubContext<ClockHub> _clockHubContext;

        public ClockService(IHubContext<ClockHub> hub)
        {
            _clockHubContext = hub;
        }

        public void Tick()  // Start|Stop
        {
            var time = DateTime.UtcNow.ToString("HH:mm:ss tt zz");
            _clockHubContext.Clients.All.SendAsync("tickUI", time);
        }
    }
}