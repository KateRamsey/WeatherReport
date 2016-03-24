using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO: Database


            string Zip = "0";
            string APIkey = "4815a8bfa3e118cb";
            Console.WriteLine("What location would you like to get the weather for?");
            string ZipCodeRegEx = "^([0-9]{5})$";
            string userInput = Console.ReadLine();

            WUGLookup wuglookup = new WUGLookup(userInput);

            //TODO: better user input check
            if (userInput == ZipCodeRegEx)
            {
                Zip = userInput;
            }

            var client = new RestClient($"http://api.wunderground.com/api/{APIkey}");
            RestRequest request;


            if (Zip != "0")
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
            WeatherReportPrinter weatherReportPrinter = new WeatherReportPrinter();


            weatherReportPrinter.PrintCurrentConditions(LocalWeatherInfo);
            Console.WriteLine();
            weatherReportPrinter.Print10DayForecast(LocalWeatherInfo);
            Console.WriteLine();
            weatherReportPrinter.PrintSunrise(LocalWeatherInfo);
            weatherReportPrinter.PrintSunset(LocalWeatherInfo);
            Console.WriteLine();
            weatherReportPrinter.PrintCurrentAlerts(LocalWeatherInfo);
            //weatherReportPrinter.PrintActiveHurricanes(LocalWeatherInfo);

            Console.ReadLine();
        }
    }
}
