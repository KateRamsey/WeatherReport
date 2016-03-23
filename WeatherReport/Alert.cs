namespace WeatherReport
{
    public class Alert
    {
        public string type { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string date_epoch { get; set; }
        public string expires { get; set; }
        public string expires_epoch { get; set; }
        public string tz_short { get; set; }
        public string tz_long { get; set; }
        public string message { get; set; }
        public string phenomena { get; set; }
        public string significance { get; set; }
    }
}