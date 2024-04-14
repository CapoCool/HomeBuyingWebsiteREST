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

namespace NewsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public News GetNews(string state)
        {
                string url1 = @"https://gnews.io/api/v4/search?q=" + state + "&token=ee6a0c932dfd29d30647ea88b6e91697";
                HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url1);
                WebResponse response1 = request1.GetResponse();
                Stream dataStream1 = response1.GetResponseStream();
                StreamReader sreader1 = new StreamReader(dataStream1);
                string responsereader1 = sreader1.ReadToEnd();
                response1.Close();

                News obj3 = JsonConvert.DeserializeObject<News>(responsereader1);

                return obj3;
        }

    }


    public class News
    {
        public string totalArticles { get; set; }
        public List<Articles> articles { get; set; }
    }

    public class Articles
    {
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string publishedAt { get; set; }
        public Source source { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
