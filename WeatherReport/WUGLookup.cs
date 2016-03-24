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

            WeatherInfo zipWeatherInfo = new WeatherInfo
            {
                Zip = LocalWeatherInfo.current_observation.display_location.zip,
                City = LocalWeatherInfo.current_observation.display_location.city,
                State = LocalWeatherInfo.current_observation.display_location.state,
                CurrentFeelsLike = LocalWeatherInfo.current_observation.feelslike_string,
                SunriseHour = LocalWeatherInfo.moon_phase.sunrise.hour,
                SunriseMinute = LocalWeatherInfo.moon_phase.sunrise.minute,
                SunsetHour = LocalWeatherInfo.moon_phase.sunset.hour,
                SunsetMinute = LocalWeatherInfo.moon_phase.sunset.minute
            };

            foreach (var f in LocalWeatherInfo.forecast.simpleforecast.forecastday)
            {
                SimpleForecast sf = new SimpleForecast
                {
                    Condition = f.conditions,
                    Day = f.date.day.ToString(),
                    High = f.high.ToString(),
                    Low = f.low.ToString(),
                    Month = f.date.monthname
                };
                zipWeatherInfo.TenDayForecast.Add(sf);
            }
            foreach (var a in LocalWeatherInfo.alerts)
            {
                SimpleAlert sa = new SimpleAlert
                {
                    Description = a.description,
                    Expires = a.expires,
                    Message = a.message
                };
                zipWeatherInfo.Alerts.Add(sa);
            }

            return zipWeatherInfo;
        }

        private WeatherInfo LookupByCityState()
        {
            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");

            var request = new RestRequest(
                $"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{this.userInput}.json", Method.GET);

            var response = client.Execute<LocationWeather>(request);
            var LocalWeatherInfo = response.Data;

            WeatherInfo CSWeatherInfo = new WeatherInfo
            {
                Zip = LocalWeatherInfo.current_observation.display_location.zip,
                City = LocalWeatherInfo.current_observation.display_location.city,
                State = LocalWeatherInfo.current_observation.display_location.state,
                CurrentFeelsLike = LocalWeatherInfo.current_observation.feelslike_string,
                SunriseHour = LocalWeatherInfo.moon_phase.sunrise.hour,
                SunriseMinute = LocalWeatherInfo.moon_phase.sunrise.minute,
                SunsetHour = LocalWeatherInfo.moon_phase.sunset.hour,
                SunsetMinute = LocalWeatherInfo.moon_phase.sunset.minute
            };

            foreach (var f in LocalWeatherInfo.forecast.simpleforecast.forecastday)
            {
                SimpleForecast sf = new SimpleForecast
                {
                    Condition = f.conditions,
                    Day = f.date.day.ToString(),
                    High = f.high.ToString(),
                    Low = f.low.ToString(),
                    Month = f.date.monthname
                };
                CSWeatherInfo.TenDayForecast.Add(sf);
            }
            foreach (var a in LocalWeatherInfo.alerts)
            {
                SimpleAlert sa = new SimpleAlert
                {
                    Description = a.description,
                    Expires = a.expires,
                    Message = a.message
                };
                CSWeatherInfo.Alerts.Add(sa);
            }

            return CSWeatherInfo;
        }
    }
}