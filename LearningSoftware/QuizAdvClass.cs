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
    public partial class QuizAdvClass : Form
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
        public QuizAdvClass(string username)
        {
            totalQuestions = 4;
            InitializeComponent();
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
        


        private void QuizAdvClass_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Τι είναι μια abstract κλάση;";
                    button1.Text = "Μια κλάση που μπορει να χρησιμοποιηθεί παντού";
                    button2.Text = "Μια περιορισμένη κλάση";
                    button3.Text = "Ενα αντικείμενο";
                    button4.Text = "Μια μέθοδος";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    break;
                case 2:
                    lblQuestion.Text = "Τι πρέπει να συμπληρωθεί στη θέση (1);";
                    button1.Text = "obj.main();";
                    button2.Text = "Κενό";
                    button3.Text = "display();";
                    button4.Text = "obj.display();";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Class\quiz1.png");
                    break;
                case 3:
                    lblQuestion.Text = "Τι χαρακτηριστικό έχει ένας κονστράκτορας;";
                    button1.Text = "Έχουν επιστρεφόμενο τύπο";
                    button2.Text = "Έχουν προσδιοριστή πρόσβασης public";
                    button3.Text = "Υπεύθυνη για ολες τις κλάσεις";
                    button4.Text = "Δημιουργία αντικείμενων";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible= false;
                    break;

                case 4:
                    lblQuestion.Text = "Τι θα εμφανίσει στην έξοδο";
                    button1.Text = "Error";
                    button2.Text = "Ford";
                    button3.Text = "2024,Ford";
                    button4.Text = "2024";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Class\quiz2.png");
                    this.Size = new Size(850, 521);
                    pictureBox1.Size = new Size(638, 281);
                    pictureBox1.Location = new Point(161, 7);
                    break;
            }
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Μια περιορισμένη κλάση");
            answerCorrect.Add("obj.display();");
            answerCorrect.Add("Έχουν προσδιοριστή πρόσβασης public");
            answerCorrect.Add("2024");
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
                            cmd.Parameters.AddWithValue("@lesson", "Τεστ κλάσεων για προχωρημένουσ");
                            cmd.Parameters.AddWithValue("@username", logUser);
                            cmd.Parameters.AddWithValue("@score", score);
                            cmd.Parameters.AddWithValue("@percentage", percentage);
                            dbcon.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return;
                }

                LoadQuestion();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            AdvClassObj adv = new AdvClassObj(logUser);
            this.Hide();
            adv.Show();
        }
    }
}
