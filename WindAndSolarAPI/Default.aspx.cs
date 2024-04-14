using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WindAndSolarAPI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pollutionBox.Visible = false;
        }

        protected void fireButon_Click(object sender, EventArgs e)
        {
            string url = @"http://localhost:61400/Service1.svc/GetSolar?x=" + zipBox.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            Pollution obj = JsonConvert.DeserializeObject<Pollution>(responsereader);

            string pollutionText = string.Empty;

            foreach (Stations p in obj.stations)
            {
                pollutionText += "CO: " + p.CO + "\n";
                pollutionText += "NO2: " + p.NO2 + "\n";
                pollutionText += "OZONE: " + p.OZONE + "\n";
                pollutionText += "PM10: " + p.PM10 + "\n";
                pollutionText += "PM25: " + p.PM25 + "\n";
                pollutionText += "SO2: " + p.SO2 + "\n";
                pollutionText += "City: " + p.city + "\n";
                pollutionText += "Country Code: " + p.countryCode + "\n";
                pollutionText += "Place Name: " + p.placeName + "\n";
                pollutionText += "State: " + p.state + "\n";
                pollutionText += "CO: " + p.CO + "\n";
                pollutionText += "\n\n\n";
            }

            pollutionBox.Text = pollutionText;
            pollutionBox.Visible = true;
        }
    }
}