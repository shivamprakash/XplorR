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
    protected void Search_Click(object sender, EventArgs e)
    {
        Array Data = null;
        NewsServiceReference1.NewsServiceClient newsClient = new NewsServiceReference1.NewsServiceClient();
        Data = newsClient.GetNews(txtBoxQuery.Text);
        
    }

    //protected DataTable GetNews()
    //{
        
    //    return table;

    //}
}