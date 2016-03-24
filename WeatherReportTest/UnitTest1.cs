using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReport;
using System.Linq;

namespace WeatherReportTest
{
    [TestClass]
    public class UnitTest1
    {
        ILookup wulookup = new WUGLookup();
       // WeatherInfo weather = lookup.LookUp(userInput);
        private WeatherInfo weather;

        //To Test: RegEx (Zip vs City, State), printers, real or not real city
        [TestMethod]
        public void WeatherUndergroundZipCode()
        {
            weather = wulookup.LookUp("72023");
            Assert.AreEqual(weather.City, "Cabot");
        }

        [TestMethod]
        public void WeatherUndergroundBadZipCode()
        {
            weather = wulookup.LookUp("7202365656565");
            Assert.IsNull(weather);
        }
    }
}
