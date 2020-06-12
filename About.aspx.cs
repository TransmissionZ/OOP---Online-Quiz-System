using System;
using System.Web.UI;

namespace Quiz_System
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Master.FindControl("LoginBar").Visible = false;
            //this.Master.FindControl("LogoutBar").Visible = false;
            //if (Session["id"] != null)
            //{
            //    this.Master.FindControl("LoginBar").Visible = false;
            //    this.Master.FindControl("LogoutBar").Visible = true;
            //    // username.text = session["id"].tostring();
            //}
            //else
            //{
            //    this.Master.FindControl("LogoutBar").Visible = false;
            //    this.Master.FindControl("LoginBar").Visible = true;
            //    //Response.Redirect("~/Login.aspx");
            //}
        }
    }
}