//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//

using System.Text;
using Ch10.SampleApi.Common;

namespace Ch10.SampleApi.Application.Formatters
{
    public class ForecastsXmlFormatter  
    {
        public static string Serialize(WeatherInfo info)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<forecasts current=\"{0}\">", info.Temp);
            foreach (var temp in info.ForecastMax)
            {
                builder.AppendFormat("<max>{0}</max>", temp);
            }
            builder.AppendFormat("</forecasts>");
            return builder.ToString();
        }
    }
}