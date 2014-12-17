using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XplorR
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["xplorrCookie"] != null)
            {
                if (Request.Cookies["xplorrCookie"]["name"] != null)
                { lblName.Text = "Welcome " + Request.Cookies["xplorrCookie"]["name"].ToString(); }
            }
           
        }
    }
}