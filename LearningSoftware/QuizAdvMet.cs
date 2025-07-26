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
    public partial class QuizAdvMet : Form
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
        public QuizAdvMet(string username)
        {
            logUser=username;
            InitializeComponent();
            totalQuestions = 4;
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
        private void QuizAdvMet_Load(object sender, EventArgs e) { 
             LoadQuestion();
            LoadConnectionString();
        }
        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = " Που καλούνται οι Instance μέθοδοι;";
                    button1.Text = "Σε πολλαπλές μεθόδους";
                    button2.Text = "Σε κονστράκτορα";
                    button3.Text = "Σε ένα αντικείμενο κλάσης";
                    button4.Text = "Στο println";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    break;
                case 2:
                    lblQuestion.Text = "Τι θα εμφανίσει στην έξοδο; ";
                    button1.Text = "40";
                    button2.Text = "10";
                    button3.Text = "0";
                    button4.Text = "35";
                    correctAnswer = 4;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Methods\quizadv1.png");
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    this.Size = new Size(850, 555);
                    pictureBox1.Size = new Size(417, 245);
                    pictureBox1.Location = new Point(200, 26);
                    button1.Location = new Point(33, 374);
                    button2.Location = new Point(617, 374);
                    button3.Location = new Point(33, 451);
                    button4.Location = new Point(617, 451);
                    lblQuestion.Location = new Point(208, 308);
                    break;
                case 3:
                    lblQuestion.Text = "Τι θα εκτυπώσει;";
                    button1.Text = "20";
                    button2.Text = "This is Instance";
                    button3.Text = "Error";
                    button4.Text = "20 και 'This is instance'";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    this.Size = new Size(864, 552);
                    pictureBox1.Image = new Bitmap(@"Methods\quizadv2.png");
                    break;
               

                case 4:
                    lblQuestion.Text = "Τι θα εκτυπώσει;";
                    button1.Text = "Abstract Example";
                    button2.Text = "Error";
                    button3.Text = "Abstract";
                    button4.Text = "Example";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Methods\quizadv3.png");
                    pictureBox1.Visible = true;
                    this.Size = new Size(864, 584);
                    button1.Location = new Point(38, 409);
                    button2.Location = new Point(622, 409);
                    button3.Location = new Point(38, 486);
                    button4.Location = new Point(622, 486);
                    lblQuestion.Location = new Point(203, 364);
                    break;
            }
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Σε ένα αντικείμενο κλάσης");
            answerCorrect.Add("35");
            answerCorrect.Add("20 και 'This is instance'");
            answerCorrect.Add("Example");
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
                                cmd.Parameters.AddWithValue("@lesson", "Τεστ στις μεθόδους για προχωρημένους");
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
            AdvMethods adv=new AdvMethods(logUser);
            this.Hide();
            adv.Show();
        }
    }
}
