using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class quizbegMeth : Form
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

        public quizbegMeth(string username)
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

        private void quizbegMeth_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }

        public void checkAnswer()
        {
            answerCorrect.Add("3");
            answerCorrect.Add("100");
            answerCorrect.Add("Όχι");
            answerCorrect.Add("Όλα τα παραπάνω");
        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Τι θα εμφανίσει στην έξοδο;";
                    button1.Text = "1";
                    button2.Text = "2";
                    button3.Text = "3";
                    button4.Text = "Error";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Methods\bmetq1.png");
                    this.Size = new Size(914, 624);
                    pictureBox1.Size = new Size(522, 333);
                    pictureBox1.Location = new Point(226, 12);
                    lblQuestion.Location = new Point(227,362);
                    button1.Location = new Point(47, 408);
                    button2.Location = new Point(617, 408);
                    button3.Location = new Point(47, 518);
                    button4.Location = new Point(617, 518);
                    break;
                case 2:
                    lblQuestion.Text = "Τι θα εμφανίσει στην έξοδο;";
                    button1.Text = "100";
                    button2.Text = "10";
                    button3.Text = "5";
                    button4.Text = "0";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    this.Size = new Size(864, 552);
                    pictureBox1.Image = new Bitmap(@"Methods\bmetq2.png");
                    pictureBox1.Size = new Size(517, 188);
                    pictureBox1.Location = new Point(226, 12);
                    button1.Location = new Point(72, 338);
                    button2.Location = new Point(642, 338);
                    button3.Location = new Point(72, 448);
                    button4.Location = new Point(642, 448);
                    lblQuestion.Location = new Point(211, 269);
                    break;
                case 3:
                    lblQuestion.Text = "Είναι σωστό;";
                    button1.Text = "Ναι";
                    button2.Text = "Όχι";
                    correctAnswer = 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Methods\bmetq3.png");
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    this.Size = new Size(931,643);
                    pictureBox1.Size = new Size(529,377);
                    pictureBox1.Location = new Point(211, 12);
                    button1.Location = new Point(57, 469);
                    button2.Location = new Point(641, 469);
                    lblQuestion.Location = new Point(232, 403);
                    break;

                case 4:
                    lblQuestion.Text = "Τι περιλαβάνει ο προσδιοριστής πρόσβασης;";
                    button1.Text = "Μονο τη public";
                    button2.Text = "Μόνο τη protected";
                    button3.Text = "Μόνο την private";
                    button4.Text = "Όλα τα  παραπάνω";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    this.Size = new Size(875,444);
                    button1.Location = new Point(75, 240);
                    button2.Location = new Point(645, 240);
                    button3.Location = new Point(75, 317);
                    button4.Location = new Point(645, 317);
                    lblQuestion.Location = new Point(262,195);
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

                questionNumber++;

                if (questionNumber > totalQuestions)
                {
                    percentage = (int)Math.Round((double)(score * 100) / totalQuestions);
                    string message;
                    string advanceLevel = "";

                    if (percentage >= 50)
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
                            cmd.Parameters.AddWithValue("@lesson", "Τεστ αρχάριων στις μεθόδους");
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
                        Methods met = new Methods(logUser);
                        this.Hide();
                        met.Show();
                    }
                    return;
                }

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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.ShowDialog();
        }

        private void lblQuestion_Click_1(object sender, EventArgs e)
        {

        }

        private void back_Click_1(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.ShowDialog();

        }

        private void back_Click_2(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.ShowDialog();
        }

        private void lblQuestion_Click_2(object sender, EventArgs e)
        {

        }
    }
}