using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class QuizMethod : Form
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

        public QuizMethod(string username)
        {
            InitializeComponent();
            totalQuestions = 5;
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

        private void QuizMethod_Load(object sender, EventArgs e)
        {
            LoadQuestion();
            LoadConnectionString();
        }

        public void checkAnswer()
        {
            answerCorrect.Add("Αντικείμενο της αντίστοιχης κλάσης");
            answerCorrect.Add("Πρέπει να την κρατάμε σε μια προσωρινή μεταβλητή");
            answerCorrect.Add("3 φορές");
            answerCorrect.Add("Μέσω της κλάσης ή μέσω των αντικειμένων της κλάσης");
            answerCorrect.Add("Με αναφορά στο πραγματικό αντικείμενο");
        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Τι χρειαζόμαστε για να καλέσουμε μια μέθοδο";
                    button1.Text = "Τίποτα";
                    button2.Text = "Αντικείμενο της αντίστοιχης κλάσης";
                    button3.Text = "Κονστράκτορα";
                    button4.Text = "Κλάση";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    break;
                case 2:
                    lblQuestion.Text = "Τι πρέπει να κάνουμε όταν η μέθοδος επιστρέφει τιμή;";
                    button1.Text = "Πρέπει να την κρατάμε σε μια προσωρινή μεταβλητή";
                    button2.Text = "Δημιουργία αντικειμένου ";
                    button3.Text = "Τίποτα";
                    button4.Text = "Δημιουργία κλάσης";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    break;
                case 3:
                    lblQuestion.Text = "Πόσες φορές θα εκτυπωθεί το μήνυμα Java ";
                    button1.Text = "2 φορές";
                    button2.Text = "3 φορές ";
                    button3.Text = "Error";
                    button4.Text = "1 φορά";
                    correctAnswer = 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Methods\mq4.png");
                    this.Size = new Size(855, 577);
                    pictureBox1.Size = new Size(420, 255);
                    pictureBox1.Location = new Point(209, 12);
                    button1.Location = new Point(57, 343);
                    button2.Location = new Point(583, 343);
                    button3.Location = new Point(57, 453);
                    button4.Location = new Point(583, 455);
                    break;

                case 4:
                    lblQuestion.Text = "Πως καλούνται οι static μέθοδοι;";
                    button1.Text = "Μέσω μιας τυχαίας μεταβλητής";
                    button2.Text = "Μέσω κονστράκτορα";
                    button3.Text = "Μέσω της κλάσης ή μέσω των αντικειμένων της κλάσης";
                    button4.Text = "Κανένα απο τα παραπάνω";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    this.Size = new Size(816, 489);
                    button1.Location = new Point(52, 281);
                    button2.Location = new Point(578, 281);
                    button3.Location = new Point(52, 391);
                    button4.Location = new Point(578, 391);

                    break;

                case 5:
                    lblQuestion.Text = "Πως γίνεται το πέρασμα αντικειμένου σε μέθοδο;";
                    button1.Text = "Με μεταβλητή";
                    button2.Text = "Με αντικείμενο";
                    button3.Text = "Με κλάση ";
                    button4.Text = "Με αναφορά στο πραγματικό αντικείμενο";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = false;
                    

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
                        string newDateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                        string query = "INSERT INTO scores (lesson, username, score, percentage, datetime) VALUES (@lesson, @username, @score, @percentage, @datetime)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbcon))
                        {
                            cmd.Parameters.AddWithValue("@lesson", "Μέθοδοι");
                            cmd.Parameters.AddWithValue("@username", logUser);
                            cmd.Parameters.AddWithValue("@score", score);
                            cmd.Parameters.AddWithValue("@percentage", percentage);
                            cmd.Parameters.AddWithValue("@datetime", newDateTime);
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

        private void back_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.ShowDialog();
        }

        private void lblQuestion_Click_1(object sender, EventArgs e)
        {

        }
    }
}