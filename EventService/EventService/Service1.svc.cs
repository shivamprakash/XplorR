using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.Configuration;
using System.Net;

namespace EventService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        public eventData[] GetEventList(string location)
        {
            List<eventData> eventList= new List<eventData>();
            XmlDocument doc = new XmlDocument();
            int no_of_entries;
            string apiKey = WebConfigurationManager.AppSettings["apikey"];
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("geo", "http://www.w3.org/2003/01/geo/wgs84_pos#" );
            string url = @"http://ws.audioscrobbler.com/2.0/?method=geo.getevents&location=" + location +
                "&api_key=" + apiKey + "&limit=1"; 
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            XmlNode pages = doc.SelectSingleNode("//lfm/events");
           
            if (root.Attributes[0].Value == "ok")
            {
                
                no_of_entries = Convert.ToInt32(pages.Attributes[5].Value);
                //change
                url = @"http://ws.audioscrobbler.com/2.0/?method=geo.getevents&location=" + location +
                "&api_key=" + apiKey + "&limit=10";// +no_of_entries;
                doc.Load(url);               
                XmlNodeList eventNodes = doc.SelectNodes("//lfm/events/event");
                foreach (XmlNode eventShow in eventNodes)
                {
                    XmlNodeList gpointnodeslat = eventShow.SelectNodes("//location/geo:point//geo:lat", nsmgr);
                    XmlNodeList gpointnodeslong = eventShow.SelectNodes("//location/geo:point//geo:long", nsmgr);
                    eventData data = new eventData();
                    venue venAdd = new venue();
                    data.Id = Convert.ToInt32(eventShow.SelectSingleNode("id").InnerText);
                    data.Title = eventShow.SelectSingleNode("title").InnerText;
                    //foreach(XmlNode artists in eventShow.ChildNodes)
                    //{
                    //    data.Artist.Add(artists.InnerText);
                    //}
                    venAdd.Name = eventShow.SelectSingleNode("//venue/name").InnerText;
                    venAdd.City = eventShow.SelectSingleNode("//venue/location/city").InnerText;
                    venAdd.Country = eventShow.SelectSingleNode("//venue/location/country").InnerText;
                    venAdd.Street = eventShow.SelectSingleNode("//venue/location/street").InnerText;
                    //venAdd.Zip = Convert.ToInt32(eventShow.SelectSingleNode("//venue/location/postalcode").InnerText);

                    venAdd.Lat = Convert.ToDouble(gpointnodeslat[0].InnerText);
                    venAdd.Lng = Convert.ToDouble(gpointnodeslong[0].InnerText);
                    data.VenueAddress = venAdd;
                    data.Url = eventShow.SelectSingleNode("url").InnerText;
                    eventList.Add(data);
                }              
            }            
            
            return eventList.ToArray();
        }

        
    
    }
}
