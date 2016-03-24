namespace WeatherReport
{
    interface ILookup
    {
        WeatherInfo LookupByZIP();
        WeatherInfo LookupByCityState();
    }

    public class WUGLookup : ILookup
    {
        private string userInput;

        public WUGLookup(string userinput)
        {
            this.userInput = userinput;
        }

        public WeatherInfo LookupByZIP()
        {
            throw new System.NotImplementedException();
        }

        public WeatherInfo LookupByCityState()
        {
            throw new System.NotImplementedException();
        }
    }
}