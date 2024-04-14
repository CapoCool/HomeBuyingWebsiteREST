using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Assignment3Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public Weather GetForecast(string zipcode)
        {
            string url1 = @"https://raw.githubusercontent.com/millbj92/US-Zip-Codes-JSON/master/USCities.json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
            WebResponse response1 = request1.GetResponse();
            Stream dataStream1 = response1.GetResponseStream();
            StreamReader sreader1 = new StreamReader(dataStream1);
            string responsereader1 = sreader1.ReadToEnd();
            response1.Close();

            List<Info> CityInfo = JsonConvert.DeserializeObject<List<Info>>(responsereader1);

            Info res = CityInfo.FirstOrDefault(s => s.zip_code == zipcode) as Info;

            string url = @"https://api.weather.gov/points/" + res.latitude + "," + res.longitude;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "MyApplication/v1.0 (http://foo.bar.baz; foo@bar.baz)";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            Forecast obj2 = JsonConvert.DeserializeObject<Forecast>(responsereader);

            string url3 = @obj2.properties.forecast;
            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(url3);
            request3.UserAgent = "MyApplication/v1.0 (http://foo.bar.baz; foo@bar.baz)";
            WebResponse response3 = request3.GetResponse();
            Stream dataStream3 = response3.GetResponseStream();
            StreamReader sreader3 = new StreamReader(dataStream3);
            string responsereader3 = sreader3.ReadToEnd();
            response3.Close();


            Weather obj3 = JsonConvert.DeserializeObject<Weather>(responsereader3);
            return obj3;
        }

    }


    public class DaysOfWeather
    {
        public int number { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public bool isDayTime { get; set; }
        public int temperature { get; set; }
        public string temperatureUnit { get; set; }
        public string windSpeed { get; set; }
        public string windDirection { get; set; }
        public string icon { get; set; }
        public string shortForecast { get; set; }
        public string detailedForecast { get; set; }

    }

    public class WeatherProperties
    {
        public List<DaysOfWeather> periods { get; set; }
    }

    public class Weather
    {
        public WeatherProperties properties { get; set; }
    }

    public class Forecast
    {
        public Properties properties { get; set; }
    }
    public class Properties
    {
        public string forecast { get; set; }
    }

    public class Info
    {
        public string zip_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string county { get; set; }
    }
}
