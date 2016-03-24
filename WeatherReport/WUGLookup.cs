using System.Security.Cryptography.X509Certificates;
using RestSharp;

namespace WeatherReport
{
    interface ILookup
    {
        WeatherInfo LookupByZIP();
        WeatherInfo LookupByCityState();
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


        public WeatherInfo LookupByZIP()
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


            return zipWeatherInfo;
        }

        public WeatherInfo LookupByCityState()
        {
            WeatherInfo zipWeatherInfo;

            return zipWeatherInfo;
        }
    }
}