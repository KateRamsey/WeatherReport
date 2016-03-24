using System;

namespace WeatherReport
{
    public class WeatherReportPrinter
    {
        public void PrintCurrentConditions(WeatherInfo lw)
        {
            Console.WriteLine($"At Zip Code {lw.Zip} ({lw.City}, {lw.State}) it feels like {lw.CurrentFeelsLike}");
        }

        public void Print10DayForecast(WeatherInfo lw)
        {
            Console.WriteLine($"Your 10 day forecast for {lw.City}, {lw.State}:");
            foreach (var d in lw.TenDayForecast)
            {
                Console.WriteLine($"{d.Month} {d.Day} forecast: High Temp = {d.High} Low Temp = {d.Low}");
                Console.WriteLine($"Conditions will be {d.Condition}");
            }
        }

        public void PrintSunrise(WeatherInfo lw)
        {
            Console.WriteLine($"Sunrise at {lw.City}, {lw.State} is {lw.SunriseHour}:{lw.SunriseMinute}");
        }

        public void PrintSunset(WeatherInfo lw)
        {
            Console.WriteLine($"Sunset at {lw.City}, {lw.State} is {lw.SunsetHour}:{lw.SunsetMinute}");
        }

        public void PrintCurrentAlerts(WeatherInfo lw)
        {
            Console.WriteLine($"Current Alerts in {lw.City}, {lw.State}:");
            if (lw.Alerts.Count !=0)
            {
                foreach (var a in lw.Alerts)
                {
                    Console.WriteLine($"{a.Description}, Expires at: {a.Expires}");
                    Console.WriteLine(a.Message);
                }
            }
            else
            {
                Console.WriteLine("No current alerts for this location");
            }
        }

        public void PrintActiveHurricanes(LocationWeather localWeatherInfo)
        {
            throw new NotImplementedException();
        }
    }
}