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
    public partial class QuizAdvList : Form
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
        public QuizAdvList(string username)
        {
            logUser = username;
            InitializeComponent();
            totalQuestions = 3;
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
        private void QuizAdvList_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }
        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = " Ποια από τα παρακάτω χρησιμοποιούνται για ταξινόμηση λίστας;" ;
                    button1.Text = "Collections.add()";
                    button2.Text = "Collections.remove()";
                    button3.Text = "Collections.sort()";
                    button4.Text = "Όλα τα παραπάνω";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
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
                    pictureBox1.Image = new Bitmap(@"Lists\quizadv1.png");
                    break;
                case 3:
                    lblQuestion.Text = "Τι αντιπροωπεύει η RoleList;";
                    button1.Text = "Μια λίστα από αντικείμενα Role";
                    button2.Text = "Μια συλλογή από παραμέτρους";
                    button3.Text = "Από κλάσεις";
                    button4.Text = "Τίποτα απο τα παραπάνω";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
            }
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Collections.sort()");
            answerCorrect.Add("Όχι");
            answerCorrect.Add("Τίποτα απο τα παραπάνω");
          
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
                            cmd.Parameters.AddWithValue("@lesson", "Τεστ στις Λίστες για προχωρημένους");
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
            AdvList adv = new AdvList(logUser);
            this.Hide();
            adv.Show();
        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }

