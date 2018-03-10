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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR1.Application;

namespace SignalR1.Controllers
{
    public class TaskController : Controller
    {
        private readonly IHubContext<ProgressHub> _progressHubContext;

        public TaskController(IHubContext<ProgressHub> progressHubContext)
        {
            _progressHubContext = progressHubContext;
        }

        // 
        public void Lengthy([Bind(Prefix="id")] string connId)
        {
            var steps = new Random().Next(3, 20);
            var increase = (int) 100/steps;

            // NOTIFY START
            //_progressHubContext.Clients.Client(connId).SendAsync("initProgressBar");
            _progressHubContext.Clients.All.SendAsync("initProgressBar");
            var total = 0;

            for (var i = 0; i < steps; i++)
            {
                Thread.Sleep(2000);
                total += increase;

                // PROGRESS
                //_progressHubContext.Clients.Client(connId).SendAsync("updateProgressBar", total);
                _progressHubContext.Clients.All.SendAsync("updateProgressBar", total);
            }

            // NOTIFY END
            //_progressHubContext.Clients.Client(connId).SendAsync("clearProgressBar");
            _progressHubContext.Clients.All.SendAsync("clearProgressBar");
        }

    }
}