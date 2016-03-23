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

            //TODO: Database


            int Zip = 0;
            string APIkey = "4815a8bfa3e118cb";
            Console.WriteLine("What location would you like to get the weather for?");
            string ZipCodeRegEx = "^([0-9]{5})$";
            string userInput = Console.ReadLine();

            //TODO: better user input check
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
            WeatherReport weatherReport = new WeatherReport();


            //TODO: Write Output Functions
            weatherReport.PrintCurrentConditions(LocalWeatherInfo);
            weatherReport.Print10DayForecast(LocalWeatherInfo);
            weatherReport.PrintSunrise(LocalWeatherInfo);
            weatherReport.PrintSunset(LocalWeatherInfo);
            weatherReport.PrintCurrentAlerts(LocalWeatherInfo);
            weatherReport.PrintActiveHurricanes(LocalWeatherInfo);

            Console.ReadLine();
        }
    }

    public class WeatherReport
    {
        public void PrintCurrentConditions(LocationWeather lw)
        {
            Console.WriteLine($"At Zip Code {lw.current_observation.display_location.zip} ({lw.current_observation.display_location.city}," +
                  $" {lw.current_observation.display_location.state})" +
                  $" it feels like {lw.current_observation.feelslike_string}");
        }

        public void Print10DayForecast(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }

        public void PrintSunrise(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }

        public void PrintSunset(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }

        public void PrintCurrentAlerts(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }

        public void PrintActiveHurricanes(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }
    }



}
