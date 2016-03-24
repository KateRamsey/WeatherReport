using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using RestSharp;

namespace WeatherReport
{
    interface ILookup
    {
        WeatherInfo LookUp(string userinput);
    }

    public class WUGLookup : ILookup
    {
        private string APIkey = "4815a8bfa3e118cb";

        public WeatherInfo LookUp(string userInput)
        {
            //TODO: Better RegEx and user input check
            string ZipCodeRegEx = "^([0-9]{5})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(userInput, ZipCodeRegEx))
            {
                return this.LookupByZIP(userInput);
            }
            else
            {
                return this.LookupByCityState(userInput);
            }
        }


        private WeatherInfo LookupByZIP(string userInput)
        {
            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");

            var request = new RestRequest(
                $"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{userInput}.json", Method.GET);

            var response = client.Execute<LocationWeather>(request);
            var LocalWeatherInfo = response.Data;
            if (LocalWeatherInfo.current_observation != null)
            {
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
            else
            {
                return null;
            }
        }

        private WeatherInfo LookupByCityState(string userInput)
        {
            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");

            var request = new RestRequest(
                $"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{userInput}.json", Method.GET);

            var response = client.Execute<LocationWeather>(request);
            var LocalWeatherInfo = response.Data;
            if (LocalWeatherInfo.current_observation != null)
            {
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
            else
            {
                return null;
            }
        }
    }
}