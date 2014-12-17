using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XplorR
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["xplorrCookie"] != null)
                {
                    if (Request.Cookies["xplorrCookie"]["name"] != null)
                    { lblName.Text = "Welcome " + Request.Cookies["xplorrCookie"]["name"].ToString(); }
                }
                if (Session["city"] == null)
                    lblMessage.Text = "Enter City";
                else
                {
                    string City = Session["city"].ToString();
                    //if (Session["city"].ToString() == "Phoenix" || Session["city"].ToString() == "phoenix")
                    //    City = "Los Angeles";
                    string keyCity = "weather" + City;
                    Array Data = null;
                    weatherReference.ForecastWCFClient weatherClient = new weatherReference.ForecastWCFClient();
                    Data = weatherClient.GetWeatherForecast(City);

                    DataTable table = new DataTable();
                    table.Columns.Add("Date", typeof(string));
                    table.Columns.Add("Image", typeof(string));
                    table.Columns.Add("MaxTemp", typeof(string));
                    table.Columns.Add("MinTemp", typeof(string));
                    table.Columns.Add("Wind", typeof(string));
                    table.Columns.Add("Humidity", typeof(string));
                    if (Cache[keyCity] == null)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            DataRow entry = table.NewRow();
                            String dt = ((weatherReference.Forecast[])(Data))[i].ForecastDate.Month + "/" +
                                ((weatherReference.Forecast[])(Data))[i].ForecastDate.Day + "/" +
                            ((weatherReference.Forecast[])(Data))[i].ForecastDate.Year;
                            entry["Date"] = dt;
                            entry["MaxTemp"] = ((weatherReference.Forecast[])(Data))[i].Maxtemp;
                            entry["MinTemp"] = ((weatherReference.Forecast[])(Data))[i].Mintemp;
                            entry["Wind"] = ((weatherReference.Forecast[])(Data))[i].WindObj.Direction;
                            entry["Humidity"] = ((weatherReference.Forecast[])(Data))[i].Humidity;
                            entry["Image"] = ((weatherReference.Forecast[])(Data))[i].Url;
                            table.Rows.Add(entry);
                        }
                        Cache.Insert(keyCity, table, null, DateTime.Now.AddMinutes(10.0), TimeSpan.Zero);
                        lblMessage.Text = "Weather forecast for " + City + " is : ";
                    }
                    else
                    {
                        lblMessage.Text = "Retreived from cache. Weather forecast for " + City + " is : ";
                        table = Cache[keyCity] as DataTable;
                    }

                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
            }
            catch
            {
                lblMessage.Text = "Web Service not responding for the input data";
            }
        }
    }
}