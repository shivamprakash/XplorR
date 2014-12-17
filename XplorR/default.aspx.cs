using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XplorR
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btnNext1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/showevents.aspx");
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            HttpCookie nameCookie = new HttpCookie("xplorrCookie");
            nameCookie["name"] = txtName.Text;
            nameCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(nameCookie);
            Session["city"] = txtCity.Text;
            lblName.Text = "Welcome " + nameCookie["name"].ToString();
        }
    }
}