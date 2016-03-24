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

            string userInput = Console.ReadLine();

            ILookup lookup = new WUGLookup(userInput);


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
