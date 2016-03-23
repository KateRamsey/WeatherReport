using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {
            int Zip = 0;
            string APIkey = "4815a8bfa3e118cb";
            Console.WriteLine("What location would you like to get the weather for?");
            string ZipCodeRegEx = "^([0-9]{5})$";
            string userInput = Console.ReadLine();
            if (userInput == ZipCodeRegEx)
            {
                Zip = Int32.Parse(userInput);
            }

            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");
            RestRequest request;


            if (Zip != 0)
            {
                request = new RestRequest(
                   $"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{Zip}.json", Method.GET);
            }
            else
            {
                request = new RestRequest($"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{userInput}.json", Method.GET);
            }
            var response = client.Execute<LocationWeather>(request);
            var LocalWeatherInfo = response.Data;

            Console.WriteLine($"At Zip Code {LocalWeatherInfo.current_observation.display_location.zip} ({LocalWeatherInfo.current_observation.display_location.city}," +
                              $" {LocalWeatherInfo.current_observation.display_location.state})" +
                              $" it feels like {LocalWeatherInfo.current_observation.feelslike_string}");


            Console.ReadLine();
        }
    }



}
