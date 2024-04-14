using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3Service
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resultsBox.Visible = false;
        }

        protected void forecastButton_Click(object sender, EventArgs e)
        {
            string zipcode = zipBox.Text;
            string url3 = "http://localhost:53732/Service1.svc/GetForecast?x=" + zipcode;
            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(url3);
            request3.UserAgent = "MyApplication/v1.0 (http://foo.bar.baz; foo@bar.baz)";
            WebResponse response3 = request3.GetResponse();
            Stream dataStream3 = response3.GetResponseStream();
            StreamReader sreader3 = new StreamReader(dataStream3);
            string responsereader3 = sreader3.ReadToEnd();
            response3.Close();


            Weather obj3 = JsonConvert.DeserializeObject<Weather>(responsereader3);

            string resultsText = string.Empty;

            foreach (DaysOfWeather forecast in obj3.properties.periods)
            {
                resultsText += "Day: " + forecast.number + "\n";
                resultsText += "Start Time: " + forecast.startTime + "\n";
                resultsText += "End Time: " + forecast.endTime + "\n";
                resultsText += "Is Day Time: " + forecast.isDayTime + "\n";
                resultsText += "Temperature: " + forecast.temperature + "\n";
                resultsText += "Temperature Unit: " + forecast.temperatureUnit + "\n";
                resultsText += "Wind Speed: " + forecast.windSpeed + "\n";
                resultsText += "Wind Direction: " + forecast.windDirection + "\n";
                resultsText += "URL of Icon: " + forecast.icon + "\n";
                resultsText += "Short Forecast: " + forecast.shortForecast + "\n";
                resultsText += "Detailed Forecast: " + forecast.detailedForecast + "\n";
                resultsText += "\n\n\n";
            }

            resultsBox.Text = resultsText;
            resultsBox.Visible = true;

        }
    }

    //public class DaysOfWeather
    //{
    //    public int number { get; set; }
    //    public string startTime { get; set; }
    //    public string endTime { get; set; }
    //    public bool isDayTime { get; set; }
    //    public int temperature { get; set; }
    //    public string temperatureUnit { get; set; }
    //    public string windSpeed { get; set; }
    //    public string windDirection { get; set; }
    //    public string icon { get; set; }
    //    public string shortForecast { get; set; }
    //    public string detailedForecast { get; set; }

    //}

    //public class WeatherProperties
    //{
    //    public List<DaysOfWeather> periods { get; set; }
    //}

    //public class Weather
    //{
    //    public WeatherProperties properties { get; set; }
    //}
}