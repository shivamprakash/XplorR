using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace ForecastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ForecastWCF : IForecastWCF
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public Forecast[] GetWeatherForecast(string location)
        {
            List<Forecast> forecastList =new List<Forecast>();
            XmlDocument doc = new XmlDocument();
            String url = "http://api.wunderground.com/api/d5a8a1b1789d37c7/forecast10day/q/CA/" + location + ".xml";
            doc.Load(url);  
            XmlNodeList elemList = doc.SelectNodes("//simpleforecast/forecastdays/forecastday");
                
            for (int i = 0; i < elemList.Count; i++)
            {
                Forecast forecastObj = new Forecast();  
                date forecastDate = new date();
                foreach (XmlNode childNode in elemList[i].SelectSingleNode("date").ChildNodes)
                {
                    Console.WriteLine("Name : " + childNode.Name);

                    if (childNode.Name == "day")
                        forecastDate.Day = Convert.ToInt32(childNode.InnerText);
                    if (childNode.Name == "month")
                        forecastDate.Month = Convert.ToInt32(childNode.InnerText);
                    if (childNode.Name == "year")
                        forecastDate.Year = Convert.ToInt32(childNode.InnerText);

                }
                forecastObj.ForecastDate = forecastDate;
                forecastObj.Maxtemp = Convert.ToSingle(elemList[i].SelectSingleNode("high").SelectSingleNode("fahrenheit").InnerText);
                forecastObj.Mintemp = Convert.ToSingle(elemList[i].SelectSingleNode("low").SelectSingleNode("fahrenheit").InnerText);
                forecastObj.WindObj.Deg = Convert.ToSingle(elemList[i].SelectSingleNode("avewind").SelectSingleNode("degrees").InnerText);
                forecastObj.WindObj.Direction = elemList[i].SelectSingleNode("avewind").SelectSingleNode("dir").InnerText;
                forecastObj.Url = elemList[i].SelectSingleNode("icon_url").InnerText;
                forecastObj.Humidity = Convert.ToInt32(elemList[i].SelectSingleNode("avehumidity").InnerText);
                forecastList.Add(forecastObj);                
            }
            return forecastList.ToArray(); 

        }
        
    }
}
