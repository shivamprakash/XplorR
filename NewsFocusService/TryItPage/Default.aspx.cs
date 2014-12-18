using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TryNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Array Data = null;
        NewsServiceReference1.NewsServiceClient newsProxy = new NewsServiceReference1.NewsServiceClient();
        Data = newsProxy.GetNews(txtQuery.Text);
        DataTable table = new DataTable();
        table.Columns.Add("Title", typeof(string));
        table.Columns.Add("Description", typeof(string));
        table.Columns.Add("Url", typeof(string));


        for (int i = 0; i < Data.Length; i++)
        {
            DataRow entry = table.NewRow();
            entry["Title"] = ((NewsServiceReference1.NewsType[])(Data))[i].Title;
            entry["Description"] = ((NewsServiceReference1.NewsType[])(Data))[i].Description;
            entry["Url"] = ((NewsServiceReference1.NewsType[])(Data))[i].Url;

            table.Rows.Add(entry);
        }
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
}