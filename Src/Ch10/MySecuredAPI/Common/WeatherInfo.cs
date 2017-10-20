//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   MySecuredApi
//

using System.Collections.Generic;

namespace Ch10.MySecuredAPI.Common
{
    public class WeatherInfo  
    {
        public WeatherInfo()
        {
            ForecastMax = new List<string>();
        }

        public string Temp { get; set; }
        public IList<string> ForecastMax { get; set; }
    }
}