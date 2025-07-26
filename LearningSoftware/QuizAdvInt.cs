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
    public partial class QuizAdvInt : Form
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
        public QuizAdvInt(string username)
        {
            logUser = username;
            InitializeComponent();
            totalQuestions = 2;
            checkAnswer();
            LoadConnectionString();
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
        private void QuizAdvInt_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }
        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = " Τι ταιριάζει στο κενό;";
                    button1.Text = "Τίποτα";
                    button2.Text = "Rectangle";
                    button3.Text = "interface";
                    button4.Text = "Polygon";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Interface\Advquiz1.png");
                    break;
                case 2:
                    lblQuestion.Text = "Είναι σωστό;";
                    button1.Text = "Ναι";
                    button2.Text = "Όχι";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Interface\Advquiz2.png");
                    break;
               
            }
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Polygon");
            answerCorrect.Add("Όχι");

        }
        private string CheckAnswerCor(int questionNumber)
        {
            if (questionNumber <= answerCorrect.Count)
            {
                return answerCorrect[questionNumber - 1];
            }
            return "";

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
                    if (wrongAnswer.Count > 0)
                    {
                        message = "Τέλος!" + Environment.NewLine +
                                  "Έχεις απαντήσει " + score + "/" + totalQuestions + " σωστές ερωτήσεις." + Environment.NewLine +
                                  "Το συνολικό ποσοστό είναι " + percentage + "%" + Environment.NewLine +
                                  "Λανθασμένες απαντήσεις:" + Environment.NewLine +
                                  string.Join(Environment.NewLine, wrongAnswer.ToArray());
                    }
                    else
                    {
                        message = "Τέλος!" + Environment.NewLine +
                                  "Έχεις απαντήσει " + score + "/" + totalQuestions + " σωστές ερωτήσεις." + Environment.NewLine +
                                  "Το συνολικό ποσοστό είναι 100%";
                    }

                    MessageBox.Show(message);

                    using (NpgsqlConnection dbcon = new NpgsqlConnection(connectionString))
                    {
                        string query = "INSERT INTO scores (lesson, username, score, percentage) VALUES (@lesson, @username, @score, @percentage)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbcon))
                        {
                            cmd.Parameters.AddWithValue("@lesson", "Τεστ στα interfaces για προχωρημένους");
                            cmd.Parameters.AddWithValue("@username", logUser);
                            cmd.Parameters.AddWithValue("@score", score);
                            cmd.Parameters.AddWithValue("@percentage", percentage);
                            dbcon.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return;
                }
                qnum++;
                LoadQuestion();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            AdvMethods adv = new AdvMethods(logUser);
            this.Hide();
            adv.Show();
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            AdvMethods adv = new AdvMethods(logUser);
            this.Hide();
            adv.Show();
        }
    }
}

