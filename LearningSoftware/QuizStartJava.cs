using LearningSoftware;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class QuizStartJava : Form
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

        public QuizStartJava(string username)
        {
            InitializeComponent();
            totalQuestions = 3;
            
            LoadConnectionString();
            logUser = username;
            checkAnswer();
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

        private void StudentMenu_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }

        public void checkAnswer()
        {
            answerCorrect.Add("Ασφάλεια");
            answerCorrect.Add("Intelij IDEA");
            answerCorrect.Add("Όχι");
        }

        public void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Ποια Είναι το πλεονέκτημα της Java";
                    button1.Text = "Απόδοση";
                    button2.Text = "Κατανάλωσης μνήμης";
                    button3.Text = "Ασφάλεια";
                    button4.Text = "Πολυπλοκότητα";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
                case 2:
                    lblQuestion.Text = "Ποιο από τους παρακάτω compilers είναι για την Java";
                    button1.Text = "Pycharm";
                    button2.Text = "Visual Studio";
                    button3.Text = "Matlab";
                    button4.Text = "Intelij IDEA";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
                case 3:
                    lblQuestion.Text = "Είναι σωστό;";
                    button1.Text = "Ναι";
                    button2.Text = "Όχι";
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    correctAnswer = 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"StartJava\q3.png");
                    break;
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

            
                if (questionNumber == totalQuestions)
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
                            cmd.Parameters.AddWithValue("@lesson", "Τι είναι η Java");
                            cmd.Parameters.AddWithValue("@username", logUser);
                            cmd.Parameters.AddWithValue("@score", score);
                            cmd.Parameters.AddWithValue("@percentage", percentage);
                            dbcon.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return; 
                }

                questionNumber++;
                qnum++;
                LoadQuestion();
            }
        }

        private string CheckAnswerCor(int questionNumber)
        {
            if (questionNumber <= answerCorrect.Count)
            {
                return answerCorrect[questionNumber - 1];
            }
            return "";

        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            StartJava start = new StartJava(logUser);
            this.Hide();
            start.ShowDialog();
        }
    }
}