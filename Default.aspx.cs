using System;
using System.Web.UI;

namespace Quiz_System
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                this.Master.FindControl("LoginBar").Visible = false;
                this.Master.FindControl("LogoutBar").Visible = true;
                if (Session["role"] != null)
                {
                    if (Session["role"].ToString() == "Teacher")
                        this.Master.FindControl("teacherholder").Visible = true;
                    else
                        this.Master.FindControl("teacherholder").Visible = false;
                    if (Session["role"].ToString() == "Student")
                        this.Master.FindControl("studentholder").Visible = true;
                    else
                        this.Master.FindControl("studentholder").Visible = false;
                }
                else
                {
                    this.Master.FindControl("teacherholder").Visible = false;
                    this.Master.FindControl("studentholder").Visible = false;
                }
            }
            else
            {
                this.Master.FindControl("LogoutBar").Visible = false;
                this.Master.FindControl("LoginBar").Visible = true;
            }
        }

        protected void Contact_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact");
        }
    }
}