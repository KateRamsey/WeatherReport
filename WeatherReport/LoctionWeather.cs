using System.Collections.Generic;

namespace WeatherReport
{
    public class LoctionWeather
    {
        public CurrentObservation current_observation { get; set; }
        public Forecast forecast { get; set; }
        public MoonPhase moon_phase { get; set; }
        public SunPhase sun_phase { get; set; }
        public string query_zone { get; set; }
        public List<Alert> alerts { get; set; }
        public List<object> currenthurricane { get; set; }
    }
}