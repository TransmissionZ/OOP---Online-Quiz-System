using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Quiz_System
{
    [Serializable()]
    public class QuizFast
    {
        public static (int id, string type, string name) Login(string email, string password)
        {
            IFormatter formatter = new BinaryFormatter();
            string fileS = System.AppDomain.CurrentDomain.BaseDirectory + @"\Data\Students.txt";

            string fileT = System.AppDomain.CurrentDomain.BaseDirectory + @"\Data\Teachers.txt";

            StudentInfo s1 = new StudentInfo(email, password);
            System.Diagnostics.Debug.WriteLine(fileS + fileT);
            Stream stream1 = new FileStream(fileS, FileMode.Open, FileAccess.Read);
            stream1.Position = 0;
            while (stream1.Position != stream1.Length)
            {
                StudentInfo e3 = (StudentInfo)formatter.Deserialize(stream1);
                if (e3.getEmail() == s1.getEmail() && e3.getPass() == s1.getPass())
                {
                    // Console.WriteLine(e3);
                    // Console.WriteLine("Login as Student");
                    stream1.Close();
                    return (e3.getID(), "Student", e3.getName());
                }
            }
            stream1.Close();

            TeacherInfo t1 = new TeacherInfo(email, password);
            //Console.WriteLine("teacher if");
            Stream stream = new FileStream(fileT, FileMode.Open, FileAccess.Read);
            while (stream.Position != stream.Length)
            {
                TeacherInfo e4 = (TeacherInfo)formatter.Deserialize(stream);
                if (e4.getEmail() == t1.getEmail() && e4.getPass() == t1.getPass())
                {
                    //Console.WriteLine(e4);
                    //Console.WriteLine("Login as Teacher");
                    //break;
                    stream.Close();
                    return (-1, "Teacher", e4.getName());
                }
                //else { Console.WriteLine("INVALID ENTRY 2\n"); }
            }
            stream.Close();
            return (-1, null, null);
        }
    }

    [Serializable]
    public class TeacherInfo : QuizFast
    {
        private static int TID = 0;
        private int ID;
        private string Tname;
        private string Temail;
        private string Tpassword;
        // public string fileteacher = @"C:\Users\Sameer\Desktop\university\SEM 2\OOP\PROJECT OOP\Date Teacher.txt";
        public string fileteacher = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Teachers.txt";
        public TeacherInfo() { }
        public TeacherInfo(string email, string password)
        {
            this.Temail = email;
            this.Tpassword = password;
        }
        public TeacherInfo(string name, string email, string password)
        {
            TeacherInfo.TID += 1;
            this.ID = TID;

            this.Tname = name;
            this.Temail = email;
            this.Tpassword = password;
        }
        public string getEmail()
        {
            return Temail;
        }
        public string getPass()
        {
            return Tpassword;
        }
        public string getName()
        {
            return Tname;
        }
        public void Sendteacher(TeacherInfo t)
        {
            IFormatter formatter = new BinaryFormatter(); // Creating 'FORMATTER' to change format of your object
            Stream stream = new FileStream(fileteacher, FileMode.Append);
            // NOW WE WILL SERIALIZE IT USING FORMATTER DEFINED EARLIER

            //# WRITING OBJECTS IN FILE :   
            formatter.Serialize(stream, t);
            stream.Close();
        }
    }
    [Serializable]
    public class StudentInfo : QuizFast
    {
        private string Sname;
        private static int SID;
        private int ID;
        private string Semail;
        private string Spassword;
        public string filestudent = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Students.txt";
        public StudentInfo() { }
        public StudentInfo(string email, string password)
        {
            this.Semail = email;
            this.Spassword = password;
        }
        public StudentInfo(string name, string email, string password)
        {
            StudentInfo.SID += 1;
            this.ID = SID;
            this.Sname = name;
            this.Semail = email;
            this.Spassword = password;
        }
        public string getEmail()
        {
            return Semail;
        }
        public int getID()
        {
            return ID;
        }
        public string getPass()
        {
            return Spassword;
        }
        public string getName()
        {
            return Sname;
        }
        public void Sendstudent(StudentInfo s)
        {
            IFormatter formatter = new BinaryFormatter(); // Creating 'FORMATTER' to change format of your object
            Stream stream = new FileStream(filestudent, FileMode.Append);
            // NOW WE WILL SERIALIZE IT USING FORMATTER DEFINED EARLIER

            //# WRITING OBJECTS IN FILE :   
            formatter.Serialize(stream, s);
            stream.Close();
        }
    }
    [Serializable]
    public class StudentData
    {
        public int StudentID;
        public string Sname;
        private string Semail;
        public List<int> QuizIDs = new List<int>();
        public List<int> QuizMaxScore = new List<int>();
        public List<int> QuizScores = new List<int>();
        public List<string> QuizNames = new List<string>();

        public StudentData() { }
        public StudentData(int id, string name, string email)
        {
            this.StudentID = id;
            this.Sname = name;
            this.Semail = email;
        }
        public void AddQuizAttemped(int qid, int qscore, string qname, int total)
        {
            this.QuizIDs.Add(qid);
            this.QuizScores.Add(qscore);
            this.QuizNames.Add(qname);
            this.QuizMaxScore.Add(total);
        }

        public void InitialiseStudent(StudentData Q, string filename)
        {
            string PathQuiz = AppDomain.CurrentDomain.BaseDirectory + "/Data/Students/" + filename;

            IFormatter formatter = new BinaryFormatter(); // Creating 'FORMATTER' to change format of your object
            Stream stream = new FileStream(PathQuiz, FileMode.OpenOrCreate, FileAccess.Write);
            // NOW WE WILL SERIALIZE IT USING FORMATTER DEFINED EARLIER

            //# WRITING OBJECTS IN FILE :   
            formatter.Serialize(stream, Q);
            stream.Close();
        }
        public static void UpdateStudent(string path, int qid, int qscore, string qname, int total)
        {
            // Reading previous student record and storing in r1.
            //string Pathstudent = @"C:\Users\Sameer\Desktop\university\SEM 2\OOP\PROJECT OOP\" + Sname + ".txt";
            string Pathstudent = path;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(Pathstudent, FileMode.Open, FileAccess.Read);
            StudentData r1 = (StudentData)formatter.Deserialize(stream);
            stream.Close();

            int idx = r1.QuizIDs.IndexOf(qid);
            //Updating r1 with latest marks.

            if (idx < 0)
            {
                r1.QuizIDs.Add(qid);
                r1.QuizScores.Add(qscore);
                r1.QuizNames.Add(qname);
                r1.QuizMaxScore.Add(total);
            }
            else
            {

                r1.QuizIDs[idx] = qid;
                r1.QuizScores[idx] = qscore;
                r1.QuizNames[idx] = qname;
                r1.QuizMaxScore[idx] = total;
            }

            // WRITING r1 IN FILE :  
            formatter = new BinaryFormatter(); // Creating 'FORMATTER' to change format of your object
            stream = new FileStream(Pathstudent, FileMode.Open, FileAccess.Write);
            // NOW WE WILL SERIALIZE IT USING FORMATTER DEFINED EARLIER 
            formatter.Serialize(stream, r1);
            stream.Close();
        }
        public static StudentData ReadStudent(string filename)
        {
            string PathQuiz = filename;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(PathQuiz, FileMode.Open, FileAccess.Read);
            StudentData r1 = (StudentData)formatter.Deserialize(stream);
            stream.Close();
            return r1;
        }
    }

    // Add Quiz Class
    [Serializable]
    class QuizData
    {
        public int NoOfQuestion;
        public int time;
        public int id;
        private string subject;
        public string[] Questions;
        public string[] Answers;
        public string[,] Options;
        public string Qname;
        private int QuestionIndex;
        public QuizData() { }
        public QuizData(string Qname, int NoOfQuestion, int qid, int time, string sub)
        {
            this.subject = sub;
            this.id = qid;
            this.time = time;
            this.QuestionIndex = 0;
            this.NoOfQuestion = NoOfQuestion;
            this.Qname = Qname;
            Questions = new string[NoOfQuestion];
            Answers = new string[NoOfQuestion];
            Options = new string[NoOfQuestion, 4];
        }
        public void AddQuestion(string q, string c1, string c2, string c3, string c4, string c)
        {
            Questions[QuestionIndex] = q;
            Options[QuestionIndex, 0] = c1;
            Options[QuestionIndex, 1] = c2;
            Options[QuestionIndex, 2] = c3;
            Options[QuestionIndex, 3] = c4;
            Answers[QuestionIndex] = c;
            QuestionIndex += 1;
        }
        //public void AddQuiz()
        //{

        //    for (int i = 0; i < NoOfQuestion; i++)
        //    {
        //        int n = 1;
        //        Console.WriteLine("ENTER QUESTION");
        //        Questions[i] = Console.ReadLine();
        //        for (int j = 0; j < 4; j++)
        //        {
        //            Console.WriteLine("ENTER OPTIONS NO." + (n));
        //            Options[i, j] = Console.ReadLine();
        //            n++;
        //        }
        //        Console.WriteLine("ENTER CORRECT OPTION");
        //        Answers[i] = Console.ReadLine();
        //    }
        //}
        public void SendQuiz(QuizData Q, string filename)
        {
            string PathQuiz = AppDomain.CurrentDomain.BaseDirectory + @"\Data\Quizzes\" + filename;
            System.Diagnostics.Debug.WriteLine(PathQuiz);
            IFormatter formatter = new BinaryFormatter(); // Creating 'FORMATTER' to change format of your object
            Stream stream = new FileStream(PathQuiz, FileMode.OpenOrCreate, FileAccess.Write);
            // NOW WE WILL SERIALIZE IT USING FORMATTER DEFINED EARLIER

            //# WRITING OBJECTS IN FILE :   
            formatter.Serialize(stream, Q);
            stream.Close();
        }
        public static QuizData GetQuiz(string path)
        {
            string PathQuiz = path;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(PathQuiz, FileMode.Open, FileAccess.Read);
            QuizData r1 = (QuizData)formatter.Deserialize(stream);
            stream.Close();
            return r1;
            // PRINTING     
            //for (int i = 0; i < NoOfQuestion; i++)
            //{
            //    Console.WriteLine("QUESTION :" + (r1.Questions[i]));
            //    int n = 1;
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.WriteLine("OPTIONS NO." + (n) + (r1.Options[i, j]));
            //        n++;
            //    }
            //    Console.WriteLine("CORRECT OPTION :" + (r1.Answers[i]));
            //}
        }
    }
}