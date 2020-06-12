using System;
using System.Web.UI;

namespace Quiz_System
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                LoginBar.Visible = false;
                LogoutBar.Visible = true;
                if (Session["role"] != null)
                {
                    if (Session["role"].ToString() == "Teacher")
                        teacherholder.Visible = true;
                    else
                        teacherholder.Visible = false;
                    if (Session["role"].ToString() == "Student")
                    {
                        studentholder.Visible = true;
                        slink.HRef += Session["sid"];
                    }
                    else
                        studentholder.Visible = false;
                }
                else
                {
                    teacherholder.Visible = false;
                    studentholder.Visible = false;
                }
            }
            else
            {
                LoginBar.Visible = true;
                LogoutBar.Visible = false;
            }

        }
        protected void logout_click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}