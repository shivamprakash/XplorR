using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    class Forecast
    {
        String date;

        public String Date
        {
            get { return date; }
            set { date = value; }
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
}
