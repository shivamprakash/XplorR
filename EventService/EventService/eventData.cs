using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventService
{
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
        //List<string> artist;

        //public List<string> Artist
        //{
        //    get { return artist; }
        //    set { artist = value; }
        //}


    }

   
}