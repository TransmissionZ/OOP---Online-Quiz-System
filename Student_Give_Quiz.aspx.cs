using System;
using System.Diagnostics;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz_System
{
    public partial class Student_Give_Quiz : System.Web.UI.Page
    {
        QuizData quiz;
        int QuestionIndex;
        int score;
        string studentID;
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
                this.Master.FindControl("LogoutBar").Visible = false;
                this.Master.FindControl("LoginBar").Visible = true;
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                score = 0;
                Session["StudentScore"] = score;
                QuestionIndex = 0;
                Session["StudentQuestionIndex"] = QuestionIndex;
                studentID = "";
                Session["Student_ID"] = studentID;
                quiz = new QuizData();
                Session["quizData"] = quiz;

                ScriptManager SM1 = (ScriptManager)Page.Master.FindControl("ScriptManager1");
                string qid = Server.UrlDecode(Request.QueryString["Quiz"].ToString());
                studentID = Server.UrlDecode(Request.QueryString["StudentID"].ToString());
                Debug.WriteLine(studentID);
                string[] EngQuiz = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Quizzes/english", "*", SearchOption.TopDirectoryOnly);
                string[] MathQuiz = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Quizzes/math", "*", SearchOption.TopDirectoryOnly);
                bool foundquiz = false;
                foreach (string file in EngQuiz)
                {
                    string filename = Path.GetFileNameWithoutExtension(file);
                    int IDFrom = filename.IndexOf("- ") + 2;
                    int IDTo = filename.LastIndexOf(" -");
                    string quiz_no = filename.Substring(IDFrom, IDTo - IDFrom);
                    if (quiz_no.Contains(qid))
                    {
                        quiz = QuizData.GetQuiz(file);
                        Session["quizData"] = quiz;
                        foundquiz = true;
                    }
                }
                if (foundquiz == false)
                {
                    foreach (string file in MathQuiz)
                    {
                        string filename = Path.GetFileNameWithoutExtension(file);
                        int IDFrom = filename.IndexOf("- ") + 2;
                        int IDTo = filename.LastIndexOf(" -");
                        string quiz_no = filename.Substring(IDFrom, IDTo - IDFrom);
                        if (quiz_no.Contains(qid))
                        {
                            quiz = QuizData.GetQuiz(file);
                            Session["quizData"] = quiz;
                            foundquiz = true;
                        }
                    }
                }
                int noofq = quiz.NoOfQuestion;
                Debug.WriteLine(noofq.ToString());
                Debug.WriteLine(QuestionIndex.ToString() + "  " + quiz.NoOfQuestion.ToString());
                if (foundquiz == true && QuestionIndex < quiz.NoOfQuestion)
                {

                    Question.Text = quiz.Questions[QuestionIndex];


                    Choices.Items[0].Text = quiz.Options[QuestionIndex, 0];
                    Choices.Items[0].Value = "1";

                    Choices.Items[1].Text = quiz.Options[QuestionIndex, 1];
                    Choices.Items[1].Value = "2";

                    Choices.Items[2].Text = quiz.Options[QuestionIndex, 2];
                    Choices.Items[2].Value = "3";

                    Choices.Items[3].Text = quiz.Options[QuestionIndex, 3];
                    Choices.Items[3].Value = "4";

                    //if (Choices.SelectedValue == (quiz.Answers[QuestionIndex]))
                    //{
                    //    score += 1;
                    //}

                    Session["StudentScore"] = score;
                    QuestionIndex += 1;
                    Session["StudentQuestionIndex"] = QuestionIndex;
                }
                else
                {
                    Session["clear"] = true;
                    //Clear();
                }
                int time = quiz.time;
                if (!SM1.IsInAsyncPostBack)
                    Session["timeout"] = DateTime.Now.AddMinutes(time).ToString();
            }
            else
            {
                QuestionIndex = (int)Session["StudentQuestionIndex"];
                score = (int)Session["StudentScore"];
                studentID = (string)Session["Student_ID"];
                quiz = (QuizData)Session["quizData"];
            }
            if (Session["clear"] != null)
            {
                Clear();
            }
        }


        protected void timer1_tick(object sender, EventArgs e)
        {
            if (0 > DateTime.Compare(DateTime.Now, DateTime.Parse(Session["timeout"].ToString())))
            {
                lblTimer.Text = string.Format("Time Left: 00:{0}:{1}", ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalMinutes).ToString(), ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).Seconds).ToString());
            }
            else
            {
                timer1.Enabled = true;
                //Response.Redirect("Logout.aspx");
                //Debug.WriteLine("TImedOUT!");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "key2", "<script> alert('Timed Out! Your answers have been submitted automatically. Redirecting in 2 seconds.'); </script>");
                //string js = "setTimeout(function(){window.location.href='Student.aspx?ID=" + studentID + "';},2000);";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", js, true);
            }
        }

        //protected void back_Click(object sender, EventArgs e)
        //{
        //    //Display Last Question
        //}

        protected void submitAns_Click(object sender, EventArgs e)
        {
            if (Choices.SelectedValue == quiz.Answers[QuestionIndex - 1])
            {
                score += 1;
            }

            if (quiz.NoOfQuestion > QuestionIndex)
            {
                Question.Text = quiz.Questions[QuestionIndex];
                Choices.Items[0].Text = quiz.Options[QuestionIndex, 0];
                Choices.Items[0].Value = "1";

                Choices.Items[1].Text = quiz.Options[QuestionIndex, 1];
                Choices.Items[1].Value = "2";

                Choices.Items[2].Text = quiz.Options[QuestionIndex, 2];
                Choices.Items[2].Value = "3";

                Choices.Items[3].Text = quiz.Options[QuestionIndex, 3];
                Choices.Items[3].Value = "4";


                Debug.WriteLine(quiz.Answers[QuestionIndex] + "   " + Choices.SelectedValue);
                Session["StudentScore"] = score;
                QuestionIndex += 1;
                Session["StudentQuestionIndex"] = QuestionIndex;
                //Session[""] = Choices;
                //Session[""] = Question;
                //Update Question and calculate score
            }
            else
            {
                Session.Remove("timeout");
                Session["clear"] = true;
                Clear();
            }

        }

        private void Redirect_Click(object sender, EventArgs e)
        {
            Session.Remove("clear");
            string url = "Student.aspx?ID=" + Server.UrlDecode(Request.QueryString["StudentID"].ToString());
            Response.Redirect(url);
        }

        protected void Clear()
        {
            studentID = Request.QueryString["StudentID"].ToString();
            Content4.Controls.Clear();
            Label labelscore = new Label();
            labelscore.Style.Add("text-align", "center");
            labelscore.Font.Bold = true;
            labelscore.Text = "Thank you for giving your quiz!" + "<br />" + "Your Score is " + score.ToString() + "/" + (quiz.NoOfQuestion).ToString() + "<br />" + "<br />";
            Result.Controls.Add(labelscore);
            LinkButton redirect = new LinkButton();
            redirect.Click += Redirect_Click;
            redirect.Style.Add("text-align", "center");
            redirect.Font.Italic = true;
            redirect.ID = "Redirect";
            string studentpath = "";
            try
            {
                string[] Students = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Students", "*", SearchOption.TopDirectoryOnly);
                foreach (string file in Students)
                {
                    string filename = Path.GetFileNameWithoutExtension(file);
                    if (filename.Contains(studentID) == true)
                    {
                        studentpath = file;
                        break;
                    }
                }
                //Debug.WriteLine(studentpath);
                if (Session["updateStudent"] == null)
                {
                    StudentData.UpdateStudent(studentpath, quiz.id, score, quiz.Qname, quiz.NoOfQuestion + 1);
                    Session["updateStudent"] = false;
                }
                redirect.Text = "Go Back To Quiz Menu";
            }
            catch (Exception exc)
            {
                redirect.Text = "There was a problem saving data for this quiz, click here to retry.: " + exc.Message;
            }
            Result.Controls.Add(redirect);
        }
    }
}