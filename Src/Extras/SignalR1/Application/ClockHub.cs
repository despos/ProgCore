
//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR - 1
//

using System;
using System.Reactive.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRSamples;

namespace SignalR1.Application
{
    public class ClockHub : Hub
    {
        private static bool _clockRunning = false;

        public void Start()
        {
            _clockRunning = true;
            Clients.All.SendAsync("clockStarted");
        }

        public void Stop()
        {
            _clockRunning = false;
            Clients.All.SendAsync("clockStopped");
        }

        //public IObservable<string> Tick()
        //{
        //    return Observable.Create(
        //        async (IObserver<string> observer) =>
        //        {
        //            while(_clockRunning)
        //            {
        //                observer.OnNext(DateTime.UtcNow.ToString("HH:mm:ss"));
        //                await Task.Delay(1000);
        //            }
        //        });
        //}

        //public ChannelReader<string> Tick()
        //{
        //    var observable = Observable.Create(
        //        async (IObserver<string> observer) =>
        //        {
        //            while (_clockRunning)
        //            {
        //                observer.OnNext(DateTime.UtcNow.ToString("HH:mm:ss"));
        //                await Task.Delay(1000);
        //            }
        //        });
        //    return observable.AsChannelReader();
        //}

        public ChannelReader<string> Tick()
        {
            var channel = Channel.CreateUnbounded<string>();
            Task.Run(async () =>
            {
                while (_clockRunning)
                {
                    var time = DateTime.UtcNow.ToString("HH:mm:ss");
                    await channel.Writer.WriteAsync(time);
                    await Task.Delay(1000);
                }
                channel.Writer.TryComplete();
            });
            return channel.Reader;
        }
    }
}