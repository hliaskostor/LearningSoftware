using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningSoftware
{
    public partial class begQuizClass : Form
    {
        string connectionString;

        NpgsqlConnection dbcon;

        int qnum = 1;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;
        string logUser;
        int correctAnswer;

        List<string> answerCorrect = new List<string>();
        List<string> wrongAnswer = new List<string>();

     
        public begQuizClass(string username)
        {
            InitializeComponent();
            totalQuestions = 4;


            LoadConnectionString();
            checkAnswer();
            logUser = username;
        }
        public void LoadConnectionString()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            var lines = File.ReadAllLines(configPath);
            foreach (var line in lines)
            {
                if (line.StartsWith("connectionString"))
                {
                    connectionString = line.Substring("connectionString=".Length).Trim();

                }
            }
        }

        private void begQuizClass_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }
        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Ποιο απο τα παρακάτω είναι σωστά;";
                    button1.Text = "1";
                    button2.Text = "2";
                    button3.Text = "3";
                    button4.Text = "Bicycle bicycle=" +"\n" +
                        "new Bicycle();";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    break;
                case 2:
                    lblQuestion.Text = "Ποιο είναι το σωστό στο κενό;";
                    button1.Text = "model";
                    button2.Text = "Car";
                    button3.Text = "mycar";
                    button4.Text = "obj";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Class\bq1.png");
                    this.Size = new Size(883,500);
                    pictureBox1.Size = new Size(260,42);
                    pictureBox1.Location = new Point(280, 68);
                    button1.Location = new Point(40, 242);
                    button2.Location = new Point(512, 242);
                    button3.Location = new Point(40, 345);
                    button4.Location = new Point(512, 345);
                    lblQuestion.Location = new Point(197, 177);
                    break;
                case 3:
                    lblQuestion.Text = "Τι θα εκτυπώσει στην έξοδο;";
                    button1.Text = "101, Sonoo";
                    button2.Text = "s1";
                    button3.Text = "Sonoo";
                    button4.Text = "101";
                    correctAnswer = 1;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Class\bq2.png");
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    this.Size = new Size(972, 664);
                    pictureBox1.Size = new Size(649, 289);
                    pictureBox1.Location = new Point(192, 12);
                    button1.Location = new Point(71, 393);
                    button2.Location = new Point(547, 393);
                    button3.Location = new Point(71, 496);
                    button4.Location = new Point(547, 496);
                    lblQuestion.Location = new Point(222, 338);
                    break;

                case 4:
                    lblQuestion.Text = "Ποιο είναι το σωστό στο κενό;";
                    button1.Text = "myObj2";
                    button2.Text = "obj2";
                    button3.Text = "myObj2.x";
                    button4.Text = "obj1";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Class\bq3.png");
                    this.Size = new Size(911, 600);
                    button1.Location = new Point(50, 367);
                    button2.Location = new Point(526, 367);
                    button3.Location = new Point(50, 470);
                    button4.Location = new Point(526, 470);
                    lblQuestion.Location = new Point(207, 302);
                    break;
            }
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Bicycle bicycle=" + "\n" +
                        "new Bicycle();");
            answerCorrect.Add("Car");
            answerCorrect.Add("101, Sonoo");
            answerCorrect.Add("myObj2");
        }
        private string CheckAnswerCor(int questionNumber)
        {
            switch (questionNumber)
            {
                case 1:
                    return "Bicycle bicycle=" + "\n" +
                        "new Bicycle();";
                case 2:
                    return "Car";
                case 3:
                    return "101, Sonoo";
                case 4:
                    return "myObj2";
                default:
                    return "";
            }
        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            if (sender is Button senderButton)
            {
                int buttonTag = Convert.ToInt32(senderButton.Tag);
                if (buttonTag == correctAnswer)
                {
                    score++;
                }
                else
                {
                    wrongAnswer.Add(lblQuestion.Text + " (Λάθος απάντηση: " + senderButton.Text + ". Σωστή απάντηση: " + CheckAnswerCor(qnum) + ")");
                }

                questionNumber++;

                if (questionNumber > totalQuestions)
                {
                    percentage = (int)Math.Round((double)(score * 100) / totalQuestions);
                    string message;
                    string advanceLevel = "";

                    if (percentage > 50)
                    {
                        advanceLevel = Environment.NewLine + "Συγχαρητήρια! Μπορείτε να δείτε προχωρημένο υλικό.";
                       
                    }

                    if (wrongAnswer.Count > 0)
                    {
                        message = "Τέλος!" + Environment.NewLine +
                                  "Έχεις απαντήσει " + score + "/" + totalQuestions + " σωστές ερωτήσεις." + Environment.NewLine +
                                  "Το συνολικό ποσοστό είναι " + percentage + "%" + advanceLevel + Environment.NewLine +
                                  "Λανθασμένες απαντήσεις:" + Environment.NewLine +
                                  string.Join(Environment.NewLine, wrongAnswer.ToArray());
                    }
                    else
                    {
                        message = "Τέλος!" + Environment.NewLine +
                                  "Έχεις απαντήσει " + score + "/" + totalQuestions + " σωστές ερωτήσεις." + Environment.NewLine +
                                  "Το συνολικό ποσοστό είναι 100%" + advanceLevel;
                    }

                    MessageBox.Show(message);

                    using (NpgsqlConnection dbcon = new NpgsqlConnection(connectionString))
                    {
                        string newDateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                        string query = "INSERT INTO scores (lesson, username, score, percentage,datetime) VALUES (@lesson, @username, @score, @percentage,@datetime)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbcon))
                        {
                            cmd.Parameters.AddWithValue("@lesson", "Τεστ βοηθητικού υλικού στις κλάσεις και αντικείμενα");
                            cmd.Parameters.AddWithValue("@username", logUser);
                            cmd.Parameters.AddWithValue("@score", score);
                            cmd.Parameters.AddWithValue("@percentage", percentage);
                            cmd.Parameters.AddWithValue("@datetime", newDateTime);
                            dbcon.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (percentage > 50)
                    {
                      
                        ClassObjects cob = new ClassObjects(logUser);
                        this.Hide();
                        cob.Show();
                    }
                    return;
                }

                qnum++;
                LoadQuestion();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            beginnerClass bgc = new beginnerClass(logUser);
            this.Hide();
            bgc.Show();
        }
    }
}
