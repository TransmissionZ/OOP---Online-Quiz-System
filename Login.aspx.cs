using System;

namespace Quiz_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            //string user = "Your name is " + username.Value;
            //ltMessage.Text = user;
            //TeacherInfo(1, username.Value, pass.Value);
            var Log = QuizFast.Login(username.Value, pass.Value);
            if (Log.type != null)
            {
                if (Log.type == "Teacher")
                {
                    Session["id"] = Log.name;
                    Session["role"] = "Teacher";
                    Response.Redirect("~/Teacher");
                }
                else if (Log.type == "Student")
                {
                    Session["id"] = Log.name;
                    Session["role"] = "Student";

                    Response.Redirect("~/Student.aspx?ID=" + Server.UrlEncode(Log.id.ToString()));
                }
            }
            else
            {
                ltMessage.Text = "Wrong Email or Password";
            }
            //Session["id"] = username.Value;
            // Session.RemoveAll();

        }
    }

}