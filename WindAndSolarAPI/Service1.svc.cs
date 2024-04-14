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

namespace WindAndSolarAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public Pollution GetSolar(string zipcode)
        {

                string url = @"https://raw.githubusercontent.com/millbj92/US-Zip-Codes-JSON/master/USCities.json";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                List<Info> obj = JsonConvert.DeserializeObject<List<Info>>(responsereader);

                Info res = obj.FirstOrDefault(s => s.zip_code == zipcode) as Info;

                string url2 = @"https://api.ambeedata.com/latest/by-lat-lng?lat=" + res.latitude + "&lng=" + res.longitude;
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url2);
                request2.Headers.Add("x-api-key", "a193903d6586f1834d868f732e1ae70ee784dd003afca49c3ed771497d3a9304");
                WebResponse response2 = request2.GetResponse();
                Stream dataStream2 = response2.GetResponseStream();
                StreamReader sreader2 = new StreamReader(dataStream2);
                string responsereader2 = sreader2.ReadToEnd();
                response2.Close();

                Pollution obj2 = JsonConvert.DeserializeObject<Pollution>(responsereader2);


            return obj2;
        }

    }

    public class Pollution
    {
        public string message { set; get; }
        public List<Stations> stations { get; set; }
    }

    public class Stations
    {
        public string CO { get; set; }
        public string NO2 { get; set; }
        public string OZONE { get; set; }
        public string PM10 { get; set; }
        public string PM25 { get; set; }
        public string SO2 { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }
        public string placeName { get; set; }
        public string state { get; set; }
        public string updatedAt { get; set; }
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
