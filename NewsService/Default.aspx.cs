using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            newsBox.Visible = false;
        }

        protected void fireButon_Click(object sender, EventArgs e)
        {

            string url2 = @"http://localhost:53961/Service1.svc/GetNews?x=" + stateBox.Text;
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(url2);
            WebResponse response2 = request2.GetResponse();
            Stream dataStream2 = response2.GetResponseStream();
            StreamReader sreader2 = new StreamReader(dataStream2);
            string responsereader2 = sreader2.ReadToEnd();
            response2.Close();


            News obj2 = JsonConvert.DeserializeObject<News>(responsereader2);

            string newsText = string.Empty;

            foreach (Articles a in obj2.articles)
            {
                newsText += "Title: " + a.title + "\n";
                newsText += "Description: " + a.description + "\n";
                newsText += "Content: " + a.content + "\n";
                newsText += "Url: " + a.url + "\n";
                newsText += "image: " + a.image + "\n";
                newsText += "Published: " + a.publishedAt + "\n";
                newsText += "Source Name: " + a.source.name + "\n";
                newsText += "Source Url: " + a.source.url + "\n";

                newsText += "\n\n\n";
            }

            newsBox.Text = newsText;
            newsBox.Visible = true;
        }
    }
}