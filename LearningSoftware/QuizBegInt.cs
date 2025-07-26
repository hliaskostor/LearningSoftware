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
    public partial class QuizBegInt : Form
    {
        string connectionString;
        int qnum = 1;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;
        string logUser;
        int correctAnswer;

        List<string> answerCorrect = new List<string>();
        List<string> wrongAnswer = new List<string>();
        public QuizBegInt(string username)
        {
            InitializeComponent();
            totalQuestions = 3;


            LoadConnectionString();
            checkAnswer();
            logUser = username;
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Όχι");
            answerCorrect.Add("Shape");
            answerCorrect.Add("Μια συλλογή μεθόδων");

        }
        private string CheckAnswerCor(int questionNumber)
        {
            if (questionNumber <= answerCorrect.Count)
            {
                return answerCorrect[questionNumber - 1];
            }
            return "";

        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                
                case 1:
                    lblQuestion.Text = "Είναι σωστό;";
                    button1.Text = "Ναι";
                    button2.Text = "Όχι";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Interface\quizBeg1.png");
                    break;
                case 2:
                    lblQuestion.Text = "Ποιο είναι το σωστό;";
                    button1.Text = "Shape";
                    button2.Text = "object";
                    button3.Text = "interface";
                    button4.Text = "κενό";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Interface\quizBeg2.png");
                    break;
                case 3:
                    lblQuestion.Text = "Τι είναι τα interfaces;";
                    button1.Text = "Τίποτα";
                    button2.Text = "Κλάσεις";
                    button3.Text = "Αντικείμενα";
                    button4.Text = "Μια συλλογή μεθόθων";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;


            }
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
                        Interface inter=new Interface(logUser);
                        this.Hide();
                        inter.Show();
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
                            cmd.Parameters.AddWithValue("@lesson", "Τεστ βοηθητικού υλικού στα Interfaces");
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
                  
                        Interface inter = new Interface(logUser);
                        this.Hide();
                        inter.Show();
                    }
                    return;
                }

                qnum++;
                LoadQuestion();
            }
        }


        private void QuizBegInt_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Interface inter = new Interface(logUser);
            this.Hide();
            inter.Show();
        }
    }
}
