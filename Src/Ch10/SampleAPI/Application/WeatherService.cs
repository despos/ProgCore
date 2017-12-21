//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch10 - Designing a Web API
//   SampleApi
//


using System.Net.Http;
using System.Threading.Tasks;
using Ch10.SampleApi.Common;
using Newtonsoft.Json;

namespace Ch10.SampleApi.Application
{
    public class WeatherService
    {
        private const string YahooUrlBase =
                "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20%3D{0}%20and%20u%3D\'{1}\'&format=json";
        public WeatherInfo GetForecasts(string woeid = "721943", string tempUnit = "c", int days = 1)
        {
            //if (String.IsNullOrWhiteSpace(woeid))
            //    woeid = "721943";     // Rome

            var url = string.Format(YahooUrlBase, woeid, tempUnit);
            var client = new HttpClient();
            var data = client.GetStringAsync(url).Result;
            var wfc = JsonConvert.DeserializeObject<WeatherQuery>(data);
            var info = new WeatherInfo
            {
                Temp = wfc.query.results.channel.item.condition.temp
            };
            var index = 0;
            foreach (var f in wfc.query.results.channel.item.forecast)
            {
                if (index == days)
                    break;
                var t = f.high;
                info.ForecastMax.Add(t);
                index++;
            }
            return info;
        }

        public async Task<WeatherInfo> GetForecastsAsync(string woeid = "721943", string tempUnit = "c", int days = 1)
        {
            //if (String.IsNullOrWhiteSpace(woeid))
            //    woeid = "721943";     // Rome

            var url = string.Format(YahooUrlBase, woeid, tempUnit);
            var client = new HttpClient();
            var data = await client.GetStringAsync(url);
            var wfc = JsonConvert.DeserializeObject<WeatherQuery>(data);
            var info = new WeatherInfo
            {
                Temp = wfc.query.results.channel.item.condition.temp
            };
            var index = 0;
            foreach (var f in wfc.query.results.channel.item.forecast)
            {
                if (index == days)
                    break;
                var t = f.high;
                info.ForecastMax.Add(t);
                index++;
            }
            return info;
        }
    }
}