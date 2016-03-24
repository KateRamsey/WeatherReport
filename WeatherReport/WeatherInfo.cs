using System.Collections.Generic;

namespace WeatherReport
{
    public class WeatherInfo
    {
        public WeatherInfo()
        {
            TenDayForecast = new List<SimpleForecast>();
            Alerts = new List<SimpleAlert>();
        }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CurrentFeelsLike { get; set; }
        public string SunsetHour { get; set; }
        public string SunsetMinute { get; set; }
        public string SunriseHour { get; set; }
        public string SunriseMinute { get; set; }
        public List<SimpleForecast> TenDayForecast { get; set; }
        public List<SimpleAlert> Alerts { get; set; }
        //huricane
    }

    public class SimpleForecast
    {
        public string Month { get; set; }
        public string Day { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Condition { get; set; }
    }

    public class SimpleAlert
    {
        public string Description { get; set; }
        public string Expires { get; set; }
        public string Message { get; set; }
    }
}