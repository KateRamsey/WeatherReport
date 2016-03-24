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
            Console.WriteLine("What location would you like to get the weather for?");

            string userInput = Console.ReadLine();

            ILookup lookup = new WUGLookup(userInput);
            WeatherInfo weather = lookup.LookUp();

            WeatherReportPrinter weatherReportPrinter = new WeatherReportPrinter();

            weatherReportPrinter.PrintCurrentConditions(weather);
            Console.WriteLine();
            weatherReportPrinter.Print10DayForecast(weather);
            Console.WriteLine();
            weatherReportPrinter.PrintSunrise(weather);
            weatherReportPrinter.PrintSunset(weather);
            Console.WriteLine();
            weatherReportPrinter.PrintCurrentAlerts(weather);
            //weatherReportPrinter.PrintActiveHurricanes(weather);

            Console.ReadLine();
        }
    }
}
