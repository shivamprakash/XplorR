using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;



namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://api.openweathermap.org/data/2.5/forecast?q=London,us&mode=xml");
                       
            
            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("time");
            XmlNodeList bookList = doc.GetElementsByTagName("temperature");
            Console.WriteLine("Start");
            Forecast forecastObj = new Forecast();
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("http://api.openweathermap.org/data/2.5/forecast?q=London,us&mode=xml");                     
                XmlNodeList elemList = doc.GetElementsByTagName("time");
                XmlNodeList bookList = doc.GetElementsByTagName("temperature");
                Console.WriteLine("Start");
                Forecast forecastObj = new Forecast();
                for (int i = 0; i < elemList.Count; i++)
                {
                Console.WriteLine(elemList[i].Attributes["from"].Value);
                Console.WriteLine(bookList[i].Attributes["value"].Value);
                
            }
                Console.ReadKey();
        }
    }
}
