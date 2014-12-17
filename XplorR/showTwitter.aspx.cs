using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using System.IO;

namespace XplorR
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["xplorrCookie"] != null)
                {
                    if (Request.Cookies["xplorrCookie"]["name"] != null)
                    { lblName.Text = "Welcome " + Request.Cookies["xplorrCookie"]["name"].ToString(); }
                }
                string response = "";
                if (Session["city"] == null)
                    lblMessage.Text = "Enter City";
                else
                {
                    string City = Session["city"].ToString();
                    string keyCity = "twitter" + City;
                    if (Cache[keyCity] == null)
                    {
                        lblMessage.Text = "Trending topics from " + Session["city"].ToString() + " are :";
                        WebRequest req = WebRequest.Create("http://localhost:1337/ElecServices.svc/trending/place=" + Session["city"].ToString());
                        WebResponse resp = req.GetResponse();

                        // Reading and parsing the response data
                        Stream dataStream = resp.GetResponseStream();
                        StreamReader sReader = new StreamReader(dataStream);
                        string responseFromServer = sReader.ReadToEnd();
                        resp.Close();

                        // Loading the string response as an XML
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.LoadXml(responseFromServer);

                        XmlNodeList nodes = xmldoc.GetElementsByTagName("Name");
                        foreach (XmlNode n in nodes)
                        {
                            response += n.InnerText + "\n";
                        }
                        Cache.Insert(keyCity, response, null, DateTime.Now.AddMinutes(10.0), TimeSpan.Zero);
                    }
                    else
                    {
                        lblMessage.Text = "Retrieved from Cache. Trending topics from " + Session["city"].ToString() + " are :";
                        response = Cache[keyCity].ToString();
                    }


                    txtResult.Text = response;
                }
                displaytweetCount();
            }
            catch
            {
                lblMessage.Text = "Web Service not responding for the input data";
            }
            
        }

        private void displaytweetCount()
        {
            string response = "";
            if (Session["city"] == null || Session["city"].ToString() == "")
                lblMessage.Text = "Enter City";
            else
            {
                string City = Session["city"].ToString();
                string keyCity = "twittercount" + City + Session["artist"].ToString();
                if (Cache[keyCity] == null)
                {
                    
                    WebRequest req = WebRequest.Create("http://localhost:1337/ElecServices.svc/count/q=" + Session["artist"].ToString() + "," + Session["city"].ToString());
                    WebResponse resp = req.GetResponse();

                    // Reading and parsing the response data
                    Stream dataStream = resp.GetResponseStream();
                    StreamReader sReader = new StreamReader(dataStream);
                    string responseFromServer = sReader.ReadToEnd();
                    resp.Close();

                    // Loading the string response as an XML
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responseFromServer);

                    // Displaying our fetched values
                    //response = "Data: \nTweet Count - ";
                    response = "No of tweets from " + Session["city"].ToString() + " about " + Session["artist"].ToString() + " are: ";
                    XmlNodeList nodes = xmldoc.GetElementsByTagName("Count");
                    foreach (XmlNode n in nodes)
                    {
                        response += n.InnerText + "\n";
                        if (response == null || response == "")
                            response = "0";
                    }
                    Cache.Insert(keyCity, response, null, DateTime.Now.AddMinutes(10.0), TimeSpan.Zero);
                    
                }
                else
                    response =" Retreived from cache memory. " + Cache[keyCity].ToString();

                lblCount.Text = response;
            }
        }

        protected void btnNext3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/news.aspx");
        }
    }
}