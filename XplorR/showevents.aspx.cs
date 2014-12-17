using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using System.Data;


namespace XplorR
{
    public partial class WebForm3 : System.Web.UI.Page
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
                if (Session["city"] == null) ;
                //                lblMessage.Text = "Enter the city";
                else
                {
                    //Wait is deliberately used due to some problem with session taking time to update
                    System.Threading.Thread.Sleep(2000);
                    XmlDocument doc = new XmlDocument();
                    DataTable table = new DataTable();
                    table.Columns.Add("Title", typeof(string));
                    //table.Columns.Add("Artist", typeof(string));
                    table.Columns.Add("Address", typeof(string));
                    table.Columns.Add("kmURL", typeof(string));
                    table.Columns.Add("Url", typeof(string));


                    string City = Session["city"].ToString();
                    string keyCity = "events" + City;
                    if (Cache[keyCity] == null)
                    {

                        string url = @"http://localhost:57675/EventService.svc/GetEventList?location=" + Session["city"].ToString();

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        WebResponse response = request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        StreamReader reader = new StreamReader(responseStream);

                        //var xmlDocument = new XmlDocument();

                        string removed_namespace = RemoveAllNamespaces(reader.ReadToEnd());
                        doc.LoadXml(removed_namespace);

                        //  XmlNodeList eventNodes = doc.SelectNodes("//eventData");
                        XmlNodeList eventNodes = doc.GetElementsByTagName("eventData");
                        for (int i = 0; i < eventNodes.Count; i++)
                        {
                            DataRow entry = table.NewRow();
                            entry["Title"] = eventNodes[i].SelectSingleNode("Title").InnerText;
                            entry["kmURL"] = "/setSession.aspx?artist=" + entry["Title"];

                            String add = eventNodes[i].SelectSingleNode("VenueAddress/Street").InnerText +
                                          eventNodes[i].SelectSingleNode("VenueAddress/Name").InnerText +
                                          eventNodes[i].SelectSingleNode("VenueAddress/City").InnerText +
                                          eventNodes[i].SelectSingleNode("VenueAddress/Country").InnerText;
                            entry["Address"] = add;
                            entry["Url"] = eventNodes[i].SelectSingleNode("Url").InnerText;
                            table.Rows.Add(entry);
                        }
                        lblMessage.Text = "Events in " + City + " are : ";
                        Cache.Insert(keyCity, table, null, DateTime.Now.AddMinutes(10.0), TimeSpan.Zero);
                    }
                    else
                    {
                        table = Cache[keyCity] as DataTable;
                        lblMessage.Text = "Retrieved from cache. Events in " + City + " are : ";
                    }


                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
            }
            
                catch
            {
                lblMessage.Text = "Web Service not responding for the input data";
            }
            

        }
        // Source for below 2 functions  for removing namespaces
        // http://stackoverflow.com/questions/987135/how-to-remove-all-namespaces-from-xml-with-c

        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

    }
}