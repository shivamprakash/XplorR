using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastService
{
    public class Forecast
    {
         public Forecast()
        {
            this.windObj = new wind();
            this.forecastDate = new date();
        }
         string url;

         public string Url
         {
             get { return url; }
             set { url = value; }
         }
         int humidity;

         public int Humidity
         {
             get { return humidity; }
             set { humidity = value; }
         }

         date forecastDate;

         public date ForecastDate
         {
             get { return forecastDate; }
             set { forecastDate = value; }
         }
        wind windObj;

        public wind WindObj
        {
            get { return windObj; }
            set { windObj = value; }
        }
       
                
        float maxtemp;

        public float Maxtemp
        {
            get { return maxtemp; }
            set { maxtemp = value; }
        }
        float mintemp;

        public float Mintemp
        {
            get { return mintemp; }
            set { mintemp = value; }
        }
        
    }
    public class wind
    {
        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        string direction;

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        float deg;

        public float Deg
        {
            get { return deg; }
            set { deg = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class date
    {
        int day;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}
