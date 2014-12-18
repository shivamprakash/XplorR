using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventService
{
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