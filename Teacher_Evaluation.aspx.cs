using System;
using System.IO;
using System.Web.UI.WebControls;

namespace Quiz_System
{
    public partial class Teacher_Evaluation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                this.Master.FindControl("LoginBar").Visible = false;
                this.Master.FindControl("LogoutBar").Visible = true;
                // username.text = session["id"].tostring();
            }
            else
            {
                // this.master.findcontrol("logoutbar").visible = false;
                // this.master.findcontrol("loginbar").visible = true;
                Response.Redirect("~/Login.aspx");
            }

            PC.Controls.Add(new Literal() { Text = "<br/>" });
            PC.Controls.Add(new Literal() { Text = "<br/>" });
            Label teachername = new Label();
            teachername.Style.Add("text-align", "left");
            teachername.Style.Add("font-style", "italic");
            teachername.Style.Add("font-size", "32px");
            teachername.Text = "Students Of " + Session["id"].ToString();
            PC.Controls.Add(teachername);
            PC.Controls.Add(new Literal() { Text = "<hr/>" });

            string[] students = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Students", "*", SearchOption.TopDirectoryOnly);
            if (students.Length < 1)
            {
                Label nostudents = new Label();
                nostudents.Style.Add("font-style", "italic");
                nostudents.Text = "No Students found, Let your students utilize our website!";
                PC.Controls.Add(nostudents);
            }
            foreach (string file in students)
            {
                StudentData s = StudentData.ReadStudent(file);
                Label studentname = new Label();
                studentname.Style.Add("display", "inline-block");
                studentname.Style.Add("width", "200px");
                studentname.Style.Add("text-align", "center");
                studentname.Font.Italic = true;
                studentname.Style.Add("font-size", "20px");
                studentname.Text = "<u>Student Name:</u> " + "<b>" + s.Sname + "</b>";
                PC.Controls.Add(studentname);
                for (int i = 0; i < s.QuizIDs.Count; i++)
                {

                    //PC.Controls.Add(new Literal() { Text = "<br/>" });
                    //PC.Controls.Add(new Literal() { Text = "<br/>" });
                    
                    //Label ID = new Label();
                    //ID.Style.Add("text-align", "left");
                    //ID.Text = s.QuizIDs[i].ToString();
                    //PC.Controls.Add(ID);
                    Label name = new Label();
                    name.Style.Add("text-align", "center");
                    name.Style.Add("display", "inline-block");
                    name.Style.Add("width", "50%");
                    name.Text = s.QuizNames[i].ToString();
                    PC.Controls.Add(name);
                    Label score = new Label();
                    score.Style.Add("text-align", "right");
                    name.Style.Add("display", "inline-block");
                    name.Style.Add("width", "95%");
                    score.Text = s.QuizScores[i].ToString() + "/" + (s.QuizMaxScore[i] - 1).ToString();
                    PC.Controls.Add(score);
                    PC.Controls.Add(new Literal() { Text = "<br/>" });
                }

            }
        }
    }
}