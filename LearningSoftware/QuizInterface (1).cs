
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
    public partial class QuizInterface : Form
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

        public QuizInterface(string username)
        {
            InitializeComponent();
            totalQuestions = 3;


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
        private void QuizInterface_Load(object sender, EventArgs e)
        {
            LoadQuestion();
        }

        public void checkAnswer()
        {
            answerCorrect.Add("Μια συλλογή μεθόδων");
            answerCorrect.Add("Λάθος");
            answerCorrect.Add("(1)shape" + "\n" +
                "(2)side" + "\n" +
                "(3)draw");

        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
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
                case 2:
                    lblQuestion.Text = "Είναι σωστό ή λάθος";
                    button1.Text = "Σωστό";
                    button2.Text = "Λάθος";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    pictureBox1.Visible = true;
                    pictureBox1.Size = new Size(495, 289);
                    pictureBox1.Location = new Point(196, 37);
                    lblQuestion.Location = new Point(192, 373);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap(@"Interface\qI1.png");
                    this.Size = new Size(989, 665);
                    button1.Location = new Point(72, 466);
                    button2.Location = new Point(515, 466);
                    button3.Location = new Point(72, 555);
                    button4.Location = new Point(515, 555);

                    break;
                case 3:
                    lblQuestion.Text = "Ποια είναι η σωστή απάντηση;";
                    button1.Text = "(1)Animal" + "\n" +
                        "(2)eat" + "\n" +
                        "(3)travel";
                    button2.Text = "(1)travel" + "\n" +
                        "(2)Animal" + "\n" +
                        "(3)eat";
                    button3.Text = "Error";
                    button4.Text = "(1)eat" + "\n" +
                        "(2)travel" + "\n" +
                        "(3)Animal";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Size = new Size(352, 450);
                    pictureBox1.Location = new Point(265, 12);
                    lblQuestion.Location = new Point(197, 489);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap(@"Interface\qI2.png");
                    this.Size = new Size(1029, 723);
                    button1.Location = new Point(88, 548);
                    button2.Location = new Point(531, 536);
                    button3.Location = new Point(88, 634);
                    button4.Location = new Point(531, 632);
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
                    string beginnerLevel = "";
                    if (percentage >= 50)
                    {
                        advanceLevel = Environment.NewLine + "Συγχαρητήρια! Μπορείτε να δείτε προχωρημένο υλικό.";
                    }
                    else if (percentage < 50)
                    {
                        beginnerLevel = Environment.NewLine + "Δυστυχώς χρειάζεστε περισσότερο εξάσκηση. Έχει ενεργοποιηθεί η ενότητα 'Βοηθητικό υλικό." +
                                       " Αν θέλετε να δείτε προχωρημένο υλικό πρέπει να πάρετε στο κουίζ του βοηθητικού υλικού πάνω από 50%.";
                    }

                    if (wrongAnswer.Count > 0)
                    {
                        message = "Τέλος!" + Environment.NewLine +
                                  "Έχεις απαντήσει " + score + "/" + totalQuestions + " σωστές ερωτήσεις." + Environment.NewLine +
                                  "Το συνολικό ποσοστό είναι " + percentage + "%" + Environment.NewLine +
                                  "Λανθασμένες απαντήσεις:" + Environment.NewLine +
                                  string.Join(Environment.NewLine, wrongAnswer.ToArray()) + advanceLevel + beginnerLevel;
                    }
                    else
                    {
                        message = "Τέλος!" + Environment.NewLine +
                                  "Έχεις απαντήσει " + score + "/" + totalQuestions + " σωστές ερωτήσεις." + Environment.NewLine +
                                  "Το συνολικό ποσοστό είναι 100%" + advanceLevel + beginnerLevel;
                    }

                    MessageBox.Show(message);

                    using (NpgsqlConnection dbcon = new NpgsqlConnection(connectionString))
                    {
                        string query = "INSERT INTO scores (lesson, username, score, percentage) VALUES (@lesson, @username, @score, @percentage)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbcon))
                        {
                            cmd.Parameters.AddWithValue("@lesson", "Interface");
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

        private void back_Click_1(object sender, EventArgs e)
        {
            Interface interfaces = new Interface(logUser);
            this.Hide();
            interfaces.ShowDialog();
        }
    }
}

