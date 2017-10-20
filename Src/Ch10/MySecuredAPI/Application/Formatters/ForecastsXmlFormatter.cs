//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   MyAPI  
//

using System.Text;
using Ch10.MySecuredAPI.Common;

namespace MyAPI.Application.Formatters
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