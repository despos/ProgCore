using System;

namespace Forms.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }

        public override string ToString()
        {
            return $"{TemperatureC} °C or {TemperatureF} °F";
        }
    }
}
