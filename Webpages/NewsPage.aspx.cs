using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Caching;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webpages
{
    public partial class NewsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            newsBox.Visible = false;
            if (Session["State"] != null)
            {
                zipBox.Text = Session["State"].ToString();
            }
        }

        protected void newsButton_Click(object sender, EventArgs e)
        {
                
                string url2 = @"http://localhost:53961/Service1.svc/GetNews?x=" + zipBox.Text;
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

                //hold the object for about 5 minutes
                if (Cache["CacheNewsObject"] == null)
                {
                    Cache.Insert("CacheNewsObject", newsText, null, DateTime.Now.AddSeconds(300), Cache.NoSlidingExpiration);
                }

                newsBox.Text = newsText;
                newsBox.Visible = true;
        }

        protected void previousDataButton_Click(object sender, EventArgs e)
        {
            if (Cache["CacheNewsObject"] == null)
            {
                newsBox.Text = "You either didn't have previous data, or the cache expired";
                newsBox.Visible = true;
            }
            else
            {
                newsBox.Text = Cache["CacheNewsObject"].ToString();
                newsBox.Visible = true;
            }
        }
    }
}