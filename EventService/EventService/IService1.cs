using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EventService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
         eventData[] GetEventList(string location);
        
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class eventData
        {
            public void evenData()
            {
                this.venueAddress = new venue();
            }
            
            string url;

            public string Url
            {
              get { return url; }
              set { url = value; }
            }
            
            venue venueAddress;

            public venue VenueAddress
            {
              get { return venueAddress; }
              set { venueAddress = value; }
            }
            int id;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            string title;

            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            List<string> artist;

            public List<string> Artist
            {
                get { return artist; }
                set { artist = value; }
            }

            
        }
        
        public class venue
        {
            string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            string city;

            public string City
            {
                get { return city; }
                set { city = value; }
            }
            string country;

            public string Country
            {
                get { return country; }
                set { country = value; }
            }
            string street;

            public string Street
            {
                get { return street; }
                set { street = value; }
            }

            int zip;

            public int Zip
            {
                get { return zip; }
                set { zip = value; }
            }
            double lat;

            public double Lat
            {
                get { return lat; }
                set { lat = value; }
            }
            double lng;

            public double Lng
            {
                get { return lng; }
                set { lng = value; }
            }
        }

}
