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

using System.Runtime.Serialization.Json;
using System.Data;
public partial class TryEventService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetEvent_Click(object sender, EventArgs e)
    {
        
        XmlDocument doc = new XmlDocument();
        DataTable table = new DataTable();
        table.Columns.Add("Title", typeof(string));
        //table.Columns.Add("Artist", typeof(string));
        table.Columns.Add("Address", typeof(string));
        table.Columns.Add("Url", typeof(string));
        table.Columns.Add("Map", typeof(string));
        string url = @"http://localhost:57675/EventService.svc/GetEventList?location=" + txtQuery.Text;

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

            String add = eventNodes[i].SelectSingleNode("VenueAddress/Street").InnerText +
                          eventNodes[i].SelectSingleNode("VenueAddress/Name").InnerText +
                          eventNodes[i].SelectSingleNode("VenueAddress/City").InnerText +
                          eventNodes[i].SelectSingleNode("VenueAddress/Country").InnerText;
            entry["Address"] = add;
            entry["Url"] = eventNodes[i].SelectSingleNode("Url").InnerText;
            table.Rows.Add(entry);
        }
         GridView1.DataSource = table;
         GridView1.DataBind();               

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