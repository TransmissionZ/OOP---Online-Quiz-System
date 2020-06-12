using System;

namespace Quiz_System
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                this.Master.FindControl("LoginBar").Visible = false;
                this.Master.FindControl("LogoutBar").Visible = true;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            username.Text = Session["id"].ToString();
        }
    }
}