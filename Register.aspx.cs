using System;

namespace Quiz_System
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            // prompt.Text = Email.Value + " " + Name.Value + " " + Password.Value + role.SelectedValue;
            if (role.SelectedValue == "Teacher" && Email.Value != "" && Name.Value != "" && Password.Value != "")
            {
                TeacherInfo teacher = new TeacherInfo(Name.Value, Email.Value, Password.Value);
                teacher.Sendteacher(teacher);
                Response.Redirect("Login.aspx");
            }
            else if (role.SelectedValue == "Student" && Email.Value != "" && Name.Value != "" && Password.Value != "")
            {
                StudentInfo student = new StudentInfo(Name.Value, Email.Value, Password.Value);
                student.Sendstudent(student);
                StudentData s = new StudentData(student.getID(), Name.Value, Email.Value);
                string filename = student.getID() + " - " + Name.Value + ".txt";
                s.InitialiseStudent(s, filename);
                Response.Redirect("Login.aspx");
            }
            else
            {
                prompt.Text = "Please select a role.";
            }
        }
    }
}