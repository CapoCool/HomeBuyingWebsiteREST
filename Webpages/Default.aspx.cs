using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webpages
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["States"] == null)
            {
                string url = @"https://github.com/millbj92/US-Zip-Codes-JSON/blob/master/USCities.json?raw=true";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                List<States> obj = JsonConvert.DeserializeObject<List<States>>(responsereader);

                Cache.Insert("States", obj);
            }
        }

        protected void forecastButton_Click(object sender, EventArgs e)
        {
            GetInfo();
            Response.Redirect("WeatherPage.aspx");

        }

        protected void newsButton_Click(object sender, EventArgs e)
        {
            GetInfo();
            Response.Redirect("NewsPage.aspx");
        }

        protected void PollutionButton_Click(object sender, EventArgs e)
        {
            GetInfo();
            Response.Redirect("PollutionPage.aspx");
        }

        private void GetInfo()
        {
            //this is just a way to use some caching and session to pass along some info to the other pages.
            if (zipBox.Text != "")
            {
                List<States> infoList = Cache["States"] as List<States>;
                States res = infoList.FirstOrDefault(s => s.zip_code == zipBox.Text) as States;
                Session["Zipcode"] = res.zip_code;
                Session["State"] = res.state;
            }
        }
    }

    public class Info
    {
        public List<States> states { get; set; }
    }

    public class States
    {
        public string zip_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string county { get; set; }
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