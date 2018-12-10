//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   MyAPI  
//


using System;
using System.Collections.Generic;
using Forms.Shared;

namespace Forms.Server.Application
{
    public class WeatherService
    {
        public IList<WeatherForecast> GetForecasts(string locationId)
        {
            var list = new List<WeatherForecast>();
            for(var i=0; i < 5; i++)
            {
                var c = new Random().Next(0, 20);
                var wf = new WeatherForecast
                {
                    Date = DateTime.Today,
                    TemperatureC = c,
                    TemperatureF = c * 9 / 5 + 32
                };
                list.Add(wf);
            }
            return list;
        }

        public WeatherForecast Now(string locationId)
        {
            var c = new Random().Next(0, 20);
            var wf = new WeatherForecast
            {
                Date = DateTime.Today,
                TemperatureC = c,
                TemperatureF = c * 9 / 5 + 32
            };
            return wf;
        }
    }
}