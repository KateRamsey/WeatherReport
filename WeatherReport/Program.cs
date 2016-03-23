using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new RestClient("http://api.wunderground.com/api/4815a8bfa3e118cb");

            var request = new RestRequest("conditions/forecast10day/astronomy/alerts/currenthurricane/q/72120.json", Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
           

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            Console.WriteLine(content);
            Console.ReadLine();
        }
    }



}
