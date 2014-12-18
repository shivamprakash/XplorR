using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;

namespace NewsFocusService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NewsService1 : INewsService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public NewsType[] GetNews(string searchQuery)
        {
            List<NewsType> newsList = new List<NewsType>();
            const string bingKey = "Xq44hlNMc7NPJ6BoZpikpF6Ml3tnDuLIM5WUiRC7gZ8";
            var bing = new BingSearchContainer(
                new Uri("https://api.datamarket.azure.com/Bing/Search/")) { Credentials = new NetworkCredential(bingKey, bingKey) };

            var query = bing.News(searchQuery, null, null, null, null, null, null, null, null);
            var results = query.Execute();
            
            foreach (var result in results)
            {
                NewsType newsObj = new NewsType();
                newsObj.Title = result.Title;
                newsObj.Description = result.Description;
                newsObj.Url = result.Url;
                newsList.Add(newsObj);
            }
            return newsList.ToArray();          
            
        }
    }
}
