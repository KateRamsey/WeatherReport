using System;

namespace WeatherReport
{
    public class WeatherReportPrinter
    {
        public WeatherReportPrinter(PrintDelegate print)
        {
            Print = print;
        }
        public WeatherReportPrinter() : this(Console.WriteLine)
        {
        
        }
        public delegate void PrintDelegate(string message);
        public PrintDelegate Print { get; set; } 

        public void PrintCurrentConditions(WeatherInfo lw)
        {
            Print($"At Zip Code {lw.Zip} ({lw.City}, {lw.State}) it feels like {lw.CurrentFeelsLike}");
        }

        public void Print10DayForecast(WeatherInfo lw)
        {
            Print($"Your 10 day forecast for {lw.City}, {lw.State}:");
            foreach (var d in lw.TenDayForecast)
            {
                Console.WriteLine($"{d.Month} {d.Day} forecast: High Temp = {d.High} Low Temp = {d.Low}");
                Console.WriteLine($"Conditions will be {d.Condition}");
            }
        }

        public void PrintSunrise(WeatherInfo lw)
        {
            Print($"Sunrise at {lw.City}, {lw.State} is {lw.SunriseHour}:{lw.SunriseMinute}");
        }

        public void PrintSunset(WeatherInfo lw)
        {
            Print($"Sunset at {lw.City}, {lw.State} is {lw.SunsetHour}:{lw.SunsetMinute}");
        }

        public void PrintCurrentAlerts(WeatherInfo lw)
        {
            Print($"Current Alerts in {lw.City}, {lw.State}:");
            if (lw.Alerts.Count !=0)
            {
                foreach (var a in lw.Alerts)
                {
                    Print($"{a.Description}, Expires at: {a.Expires}");
                    Print(a.Message);
                }
            }
            else
            {
                Print("No current alerts for this location");
            }
        }

        public void PrintActiveHurricanes(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }
    }
}