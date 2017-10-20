//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using System.Collections.Generic;

namespace Ch10.SampleApi.Common
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