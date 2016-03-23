namespace WeatherReport
{
    public class QpfAllday
    {
        public double @in { get; set; }
        public int mm { get; set; }
    }

    public class QpfDay
    {
        public double @in { get; set; }
        public int mm { get; set; }
    }

    public class QpfNight
    {
        public double @in { get; set; }
        public int mm { get; set; }
    }

    public class SnowAllday
    {
        public double @in { get; set; }
        public double cm { get; set; }
    }

    public class SnowDay
    {
        public double @in { get; set; }
        public double cm { get; set; }
    }

    public class SnowNight
    {
        public double @in { get; set; }
        public double cm { get; set; }
    }

    public class Maxwind
    {
        public int mph { get; set; }
        public int kph { get; set; }
        public string dir { get; set; }
        public int degrees { get; set; }
    }

    public class Avewind
    {
        public int mph { get; set; }
        public int kph { get; set; }
        public string dir { get; set; }
        public int degrees { get; set; }
    }
}