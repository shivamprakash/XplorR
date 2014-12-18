using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NewsFocusService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INewsService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]

        NewsType[] GetNews(string searchQuery);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
[DataContract]
    public class NewsType
    {
        string url;
    [DataMember]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        string description;
    [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string title;
    [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

    }
}
