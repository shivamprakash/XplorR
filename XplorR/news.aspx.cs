using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace XplorR
{
    public partial class WebForm5 : System.Web.UI.Page
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
                    lblMessage.Text = "Enter the city";
                else
                {

                    string City = Session["city"].ToString();
                    string keyCity = "news" + City;
                    Array Data = null;
                    NewsServiceReference1.NewsServiceClient newsProxy = new NewsServiceReference1.NewsServiceClient();
                    Data = newsProxy.GetNews(Session["artist"].ToString());
                    DataTable table = new DataTable();
                    table.Columns.Add("Title", typeof(string));
                    table.Columns.Add("Description", typeof(string));
                    table.Columns.Add("Url", typeof(string));
                    if (Cache[keyCity] == null)
                    {
                        lblMessage.Text = "News about " + Session["artist"].ToString();


                        for (int i = 0; i < Data.Length; i++)
                        {
                            DataRow entry = table.NewRow();
                            entry["Title"] = ((NewsServiceReference1.NewsType[])(Data))[i].Title;
                            entry["Description"] = ((NewsServiceReference1.NewsType[])(Data))[i].Description;
                            entry["Url"] = ((NewsServiceReference1.NewsType[])(Data))[i].Url;

                            table.Rows.Add(entry);
                        }
                        Cache.Insert(keyCity, table, null, DateTime.Now.AddMinutes(10.0), TimeSpan.Zero);
                    }
                    else
                    {
                        lblMessage.Text = "Retreived from Cache. News about " + Session["artist"].ToString();
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

        protected void btnNext3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/weather.aspx");
        }

        
    }
}