namespace WeatherReport
{
    public class MoonPhase
    {
        public string percentIlluminated { get; set; }
        public string ageOfMoon { get; set; }
        public string phaseofMoon { get; set; }
        public string hemisphere { get; set; }
        public Sunrise sunrise { get; set; }
        public Sunset sunset { get; set; }
        public Moonrise moonrise { get; set; }
        public Moonset moonset { get; set; }
    }

    public class Sunrise
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class Sunset
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class Moonrise
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class Moonset
    {
        public string hour { get; set; }
        public string minute { get; set; }
    }

    public class SunPhase
    {
        public Sunrise sunrise { get; set; }
        public Sunset sunset { get; set; }
    }
}