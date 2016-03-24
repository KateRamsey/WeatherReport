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

        public void PrintSunrise(LocationWeather lw)
        {
            Console.WriteLine($"Sunrise at {lw.current_observation.display_location.city}, " +
                              $"{lw.current_observation.display_location.state} is {lw.moon_phase.sunrise.hour}" +
                              $":{lw.moon_phase.sunrise.minute}");
        }

        public void PrintSunset(LocationWeather lw)
        {
            Console.WriteLine($"Sunset at {lw.current_observation.display_location.city}, " +
                              $"{lw.current_observation.display_location.state} is {lw.moon_phase.sunset.hour}" +
                              $":{lw.moon_phase.sunset.minute}");
        }

        public void PrintCurrentAlerts(LocationWeather lw)
        {
            Console.WriteLine($"Current Alerts in {lw.current_observation.display_location.city}, {lw.current_observation.display_location.state_name}:");
            if (lw.alerts.Count !=0)
            {
                foreach (var a in lw.alerts)
                {
                    Console.WriteLine($"{a.description}, Expires at: {a.expires}");
                    Console.WriteLine(a.message);
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