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
            int Zip;
            string APIkey = "4815a8bfa3e118cb";
            Console.WriteLine("What zip code would you like to get the weather for?");
            Zip = int.Parse(Console.ReadLine());

            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");

            var request = new RestRequest($"conditions/forecast10day/astronomy/alerts/currenthurricane/q/{Zip}.json", Method.GET);


            var response = client.Execute<LocationWeather>(request);


            Console.WriteLine($"At Zip Code {Zip} it feels like {response.Data.current_observation.feelslike_string}");
 


            Console.ReadLine();
        }
    }



}
