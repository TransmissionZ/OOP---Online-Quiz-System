using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_System
{
    public partial class Student : System.Web.UI.Page
    {
        int qid { set; get; }
        StudentData s = new StudentData();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["id"] != null)
            //{
            //    this.Master.FindControl("LoginBar").Visible = false;
            //    this.Master.FindControl("LogoutBar").Visible = true;
            //    // username.text = session["id"].tostring();
            //}
            //else
            //{
            //    //this.Master.FindControl("LogoutBar").Visible = false;
            //    //this.Master.FindControl("LoginBar").Visible = true;
            //    Response.Redirect("~/Login.aspx");
            //}

            if (Session["id"] == null)
            {
                Response.Redirect("~/Login.aspx");

            }
            username.Text = Session["id"].ToString();
            string StudentID = "";
            try
            {
                StudentID = Server.UrlDecode(Request.QueryString["ID"].ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in URL Decode in Student: " + ex.Message);
            }
            string[] students = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Students", "*", SearchOption.TopDirectoryOnly);

            foreach (string file in students)
            {
                if (Path.GetFileNameWithoutExtension(file).Contains(StudentID) == true)
                {
                    s = StudentData.ReadStudent(file);
                    break;
                }
            }

            Session["sid"] = s.StudentID.ToString();
            
            string[] EngQuiz = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Quizzes/english", "*", SearchOption.TopDirectoryOnly);
            int EngQuizCount = EngQuiz.Length;
            string[] MathQuiz = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Quizzes/math", "*", SearchOption.TopDirectoryOnly);
            int MathQuizCount = MathQuiz.Length;
            if (EngQuizCount != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Quiz Name", typeof(string)),
                new DataColumn("Attempted?", typeof(string)),
                new DataColumn("Score",typeof(string)) });

                foreach (string file in EngQuiz)
                {
                    int quiz_id = 0, quiz_score = 0, max_score = 0;
                    System.Web.UI.HtmlControls.HtmlGenericControl quiztitle = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    quiztitle.Style.Add("float", "left");
                    English.Controls.Add(quiztitle);
                    System.Web.UI.HtmlControls.HtmlGenericControl attempted = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    attempted.Style.Add("text-align", "center");
                    English.Controls.Add(attempted);
                    System.Web.UI.HtmlControls.HtmlGenericControl score = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    score.Style.Add("float", "right");
                    score.Style.Add("text-align", "right");
                    English.Controls.Add(score);

                    LinkButton btn = new LinkButton();
                    btn.Click += get_quiz;
                    //btn.Text = "Quiz " + (quiz_no).ToString() + " - " + qtitle;
                    string filename = Path.GetFileNameWithoutExtension(file);
                    btn.Text = filename;
                    int IDFrom = filename.IndexOf("- ") + 2;
                    int IDTo = filename.LastIndexOf(" -");
                    string quiz_no = filename.Substring(IDFrom, IDTo - IDFrom);

                    int quiz = Int16.Parse(quiz_no);
                    bool isInList = s.QuizIDs.IndexOf(quiz) != -1;
                    if (isInList == true)
                    {
                        quiz_id = s.QuizIDs[s.QuizIDs.IndexOf(quiz)];
                        quiz_score = s.QuizScores[s.QuizIDs.IndexOf(quiz)];
                        max_score = s.QuizMaxScore[s.QuizIDs.IndexOf(quiz)];
                    }
                    btn.CommandArgument = quiz_no;
                    btn.ID = quiz_no;
                    btn.Style.Add("float", "left");
                    quiztitle.Controls.Add(btn);
                    Label Attempted = new Label();
                    Attempted.Style.Add("text-align", "center");
                    Attempted.Style.Add("display", "inline-block");
                    Attempted.Style.Add("font-weight", "bold");
                    Attempted.Style.Add("width", "400px");
                    Attempted.Style.Add("float", "center");

                    Label Score = new Label();
                    Score.Style.Add("text-align", "right");
                    Score.Style.Add("display", "inline-block");
                    Score.Style.Add("font-weight", "bold");
                    Score.Style.Add("display", "inline-block");
                    Score.Style.Add("width", "95%");
                    if (isInList == true)
                    {
                        Score.Text = quiz_score.ToString() + "/" + (max_score - 1).ToString();
                        Attempted.Text = "Attempted";
                    }
                    else
                    {
                        Score.Text = "-";
                        Attempted.Text = "Not Attempted";
                    }

                    score.Controls.Add(Score);
                    attempted.Controls.Add(Attempted);
                    attempted.Controls.Add(new LiteralControl("<br/>"));
                    English.Controls.Add(new LiteralControl("<br />"));
                    dt.Rows.Add(filename, Attempted.Text, Score.Text);
                }
                //StringBuilder sb = new StringBuilder();
                ////Table start.
                //sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");

                ////Adding HeaderRow.
                //sb.Append("<tr>");
                //foreach (DataColumn column in dt.Columns)
                //{
                //    sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
                //}
                //sb.Append("</tr>");


                ////Adding DataRow.
                //foreach (DataRow row in dt.Rows)
                //{
                //    sb.Append("<tr>");
                //    foreach (DataColumn column in dt.Columns)
                //    {
                //        sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
                //    }
                //    sb.Append("</tr>");
                //}

                ////Table end.
                //sb.Append("</table>");
                //ltTable.Text = sb.ToString();
            }
            else
            {
                Label l = new Label();
                l.Text = "No Quizes Found";
                English.Controls.Add(l);
            }

            //Math Quizes
            if (MathQuizCount != 0)
            {
                foreach (string file in MathQuiz)
                {
                    int quiz_id = 0, quiz_score = 0, max_score = 0;
                    System.Web.UI.HtmlControls.HtmlGenericControl mathtitle = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    mathtitle.Style.Add("float", "left");
                    Math.Controls.Add(mathtitle);
                    System.Web.UI.HtmlControls.HtmlGenericControl mathattempt = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    mathattempt.Style.Add("text-align", "center");
                    Math.Controls.Add(mathattempt);
                    System.Web.UI.HtmlControls.HtmlGenericControl mathscore = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    mathscore.Style.Add("float", "right");
                    mathscore.Style.Add("text-align", "right");
                    Math.Controls.Add(mathscore);
                    LinkButton btn = new LinkButton();
                    btn.Click += get_quiz;
                    //btn.Text = "Quiz " + (quiz_no).ToString() + " - " + qtitle;
                    string filename = Path.GetFileNameWithoutExtension(file);
                    btn.Text = filename;
                    int IDFrom = filename.IndexOf("- ") + 2;
                    int IDTo = filename.LastIndexOf(" -");
                    string quiz_no = filename.Substring(IDFrom, IDTo - IDFrom);
                    int quiz = Int16.Parse(quiz_no);
                    bool isInList = s.QuizIDs.IndexOf(quiz) != -1;
                    if (isInList == true)
                    {
                        quiz_id = s.QuizIDs[s.QuizIDs.IndexOf(quiz)];
                        quiz_score = s.QuizScores[s.QuizIDs.IndexOf(quiz)];
                        max_score = s.QuizMaxScore[s.QuizIDs.IndexOf(quiz)];
                    }
                    btn.CommandArgument = quiz_no;
                    btn.ID = quiz_no;
                    btn.Style.Add("float", "left");
                    mathtitle.Controls.Add(btn);
                    Label Attempted = new Label();
                    Attempted.Style.Add("text-align", "center");
                    Attempted.Style.Add("display", "inline-block");
                    Attempted.Style.Add("font-weight", "bold");
                    Attempted.Style.Add("width", "400px");
                    Attempted.Style.Add("float", "center");

                    Label Score = new Label();
                    Score.Style.Add("text-align", "right");
                    Score.Style.Add("display", "inline-block");
                    Score.Style.Add("font-weight", "bold");
                    Score.Style.Add("display", "inline-block");
                    Score.Style.Add("width", "95%");
                    if (isInList == true)
                    {

                        Score.Text = quiz_score.ToString() + "/" + (max_score - 1).ToString();
                        Attempted.Text = "Attempted";
                    }
                    else
                    {
                        Attempted.Text = "Not Attempted";
                    }
                    mathscore.Controls.Add(Score);
                    mathattempt.Controls.Add(Attempted);
                    Math.Controls.Add(new LiteralControl("<br />"));
                    //dt.Rows.Add(filename, Attempted.Text, Score.Text);
                }
            }
            else
            {
                Label l = new Label();
                l.Text = "No Quizes Found";
                Math.Controls.Add(l);
            }
            //    StringBuilder sb = new StringBuilder();
            //    //Table start.
            //    sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'>");

            //    //Adding HeaderRow.
            //    sb.Append("<tr>");
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.ColumnName + "</th>");
            //    }
            //    sb.Append("</tr>");


            //    //Adding DataRow.
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        sb.Append("<tr>");
            //        foreach (DataColumn column in dt.Columns)
            //        {
            //            sb.Append("<td style='width:100px;border: 1px solid #ccc'>" + row[column.ColumnName].ToString() + "</td>");
            //        }
            //        sb.Append("</tr>");
            //    }

            //    //Table end.
            //    sb.Append("</table>");
            //    mathltTable.Text = sb.ToString();
            //}

            
        }


        protected void get_quiz(object sender, EventArgs e)
        {

            LinkButton btn = sender as LinkButton;
            string qid = btn.CommandArgument;
            Response.Redirect("~/Student_Give_Quiz.aspx?Quiz=" + Server.UrlEncode(qid.ToString()) + "&" + "StudentID=" + Server.UrlDecode(Request.QueryString["ID"].ToString()));
            //Math.Visible = false;

            //Response.Redirect("~/Student_Give_Quiz.aspx?quiz=" + );
        }

    }
}