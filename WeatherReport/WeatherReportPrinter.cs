using System;

namespace WeatherReport
{
    public class WeatherReportPrinter
    {
        public void PrintCurrentConditions(LocationWeather lw)
        {
            Console.WriteLine($"At Zip Code {lw.current_observation.display_location.zip} ({lw.current_observation.display_location.city}," +
                              $" {lw.current_observation.display_location.state})" +
                              $" it feels like {lw.current_observation.feelslike_string}");
        }

        public void Print10DayForecast(LocationWeather lw)
        {
            Console.WriteLine($"Your 10 day forecast for {lw.current_observation.display_location.city}, {lw.current_observation.display_location.state}:");
            foreach (var d in lw.forecast.simpleforecast.forecastday)
            {
                Console.WriteLine($"{d.date.monthname_short} {d.date.day}, forecast: High Temp = {d.high} " +
                                  $"Low Temp = {d.low}");
                Console.WriteLine($"Conditions will be {d.conditions}");
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