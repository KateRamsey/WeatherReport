using System.Security.Cryptography.X509Certificates;
using RestSharp;

namespace WeatherReport
{
    interface ILookup
    {
        WeatherInfo LookUp();
    }

    public class WUGLookup : ILookup
    {
        private string userInput;
        string APIkey = "4815a8bfa3e118cb";

        public WUGLookup(string userinput)
        {
            this.userInput = userinput;
        }

        public WeatherInfo LookUp()
        {
            //TODO: Better RegEx and user input check
            string ZipCodeRegEx = "^([0-9]{5})$";
            if (userInput == ZipCodeRegEx)
            {
                return this.LookupByZIP();
            }
            else
            {
                return this.LookupByCityState();
            }
        }


        private WeatherInfo LookupByZIP()
        {
            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");

            var request = new RestRequest(
                $"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{this.userInput}.json", Method.GET);

            var response = client.Execute<LocationWeather>(request);
            var LocalWeatherInfo = response.Data;

            WeatherInfo zipWeatherInfo = new WeatherInfo();
            zipWeatherInfo.Zip = LocalWeatherInfo.current_observation.display_location.zip;
            zipWeatherInfo.City = LocalWeatherInfo.current_observation.display_location.city;
            zipWeatherInfo.State = LocalWeatherInfo.current_observation.display_location.state;
            zipWeatherInfo.CurrentFeelsLike = LocalWeatherInfo.current_observation.feelslike_string;
            zipWeatherInfo.SunriseHour = LocalWeatherInfo.moon_phase.sunrise.hour;
            zipWeatherInfo.SunriseMinute = LocalWeatherInfo.moon_phase.sunrise.minute;
            zipWeatherInfo.SunsetHour = LocalWeatherInfo.moon_phase.sunset.hour;
            zipWeatherInfo.SunsetMinute = LocalWeatherInfo.moon_phase.sunset.minute;

            foreach (var f in LocalWeatherInfo.forecast.simpleforecast.forecastday)
            {
                SimpleForecast sf = new SimpleForecast();
                sf.Condition = f.conditions;
                sf.Day = f.date.day.ToString();
                sf.High = f.high.ToString();
                sf.Low = f.low.ToString();
                sf.Month = f.date.monthname;
                zipWeatherInfo.TenDayForecast.Add(sf);
            }
            foreach (var a in LocalWeatherInfo.alerts)
            {
                SimpleAlert sa = new SimpleAlert();
                sa.Description = a.description;
                sa.Expires = a.expires;
                sa.Message = a.message;
                zipWeatherInfo.Alerts.Add(sa);
            }

            return zipWeatherInfo;
        }

        private WeatherInfo LookupByCityState()
        {
            WeatherInfo zipWeatherInfo;

            return zipWeatherInfo;
        }
    }
}