using System;
using System.Web.UI;

namespace Quiz_System
{
    public partial class Teacher_Add_Quiz : System.Web.UI.Page
    {
        private static int qid = 0;
        private string[] Questions;
        private string[] Answers;
        private string[,] Options;
        private int QuestionIndex;
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

            if (!IsPostBack)
            {
                QuestionIndex = 0;
                Session["QuestionIndex"] = QuestionIndex;
                Questions = new string[0];
                Session["Questions"] = Questions;
                Answers = new string[0];
                Session["Answers"] = Answers;
                Options = new string[1, 4];
                Session["Options"] = Options;
            }
            else
            {
                QuestionIndex = (int)Session["QuestionIndex"];
                Questions = (string[])Session["Questions"];
                Answers = (string[])Session["Answers"];
                Options = (string[,])Session["Options"];
            }
        }
        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }
        protected void addquestion_Click(object sender, EventArgs e)
        {
            string q = question.Text;
            string a1 = ans1.Text;
            string a2 = ans2.Text;
            string a3 = ans3.Text;
            string a4 = ans4.Text;
            string ca = CorrectAns.SelectedValue;
            //System.Diagnostics.Debug.WriteLine(a1 + a2 + a3 + a4);
            //System.Diagnostics.Debug.WriteLine(a1 != null);
            //System.Diagnostics.Debug.WriteLine(a3 != "");
            if ((a1 != "" && a2 != "" && a3 != "" && a4 != "" && ca != ""))
            {
                qid += 1;
                Q_no.Text = (qid).ToString();
                Array.Resize(ref Questions, QuestionIndex + 1);
                Array.Resize(ref Answers, QuestionIndex + 1);
                Options = ResizeArray<string>(Options, QuestionIndex + 1, 4);
                //Array.Resize(ref Questions, Questions.Length + 1);
                //Array.Resize(ref Questions, Questions.Length + 1);

                // Code for saving question
                Questions[QuestionIndex] = q;
                Session["Questions"] = Questions;
                Options[QuestionIndex, 0] = a1;
                Options[QuestionIndex, 1] = a2;
                Options[QuestionIndex, 2] = a3;
                Options[QuestionIndex, 3] = a4;
                Session["Options"] = Options;
                Answers[QuestionIndex] = ca;
                Session["Answers"] = Answers;

                QuestionIndex += 1;
                Session["QuestionIndex"] = QuestionIndex;

                System.Diagnostics.Debug.WriteLine("QuestionIndex: " + QuestionIndex.ToString());
                System.Diagnostics.Debug.WriteLine("Question: " + Questions[QuestionIndex - 1]);

                question.Text = "";
                ans1.Text = "";
                ans2.Text = "";
                ans3.Text = "";
                ans4.Text = "";
                CorrectAns.SelectedValue = "";
            }
            else
            {
                if (QuestionIndex < 1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "key2", "<script> alert('Add All Options and Correct Option'); </script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "key2", "<script> alert('Please fill a question to submit.'); </script>");
                }
            }
        }

        protected void SubmitQuiz_Click(object sender, EventArgs e)
        {
            if (QuestionIndex < 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "key2", "<script> alert('Please add atleast one Question'); </script>");
            }
            else
            {
                string filename;
                if (subject.SelectedValue == "English")
                {
                    filename = "english/Quiz - " + qid.ToString() + " - " + name.Text + ".txt";
                }
                else
                {
                    filename = "math/Quiz - " + qid.ToString() + " - " + name.Text + ".txt";
                }
                System.Diagnostics.Debug.WriteLine(QuestionIndex.ToString());
                QuizData quiz = new QuizData(name.Text, QuestionIndex, qid, Int16.Parse(time.Text), subject.SelectedValue);
                for (int i = 0; i < QuestionIndex; i++)
                {
                    quiz.AddQuestion(Questions[i], Options[i, 0], Options[i, 1], Options[i, 2], Options[i, 3], Answers[i]);
                }
                quiz.SendQuiz(quiz, filename);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "key2", "<script> alert('Quiz Successfully Added!'); </script>");
                //Response.Redirect("~/Teacher.aspx");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "setTimeout(function(){window.location.href='Teacher.aspx';},2000);", true);
            }

        }
    }
}