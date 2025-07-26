using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class ClassObjQuiz : Form
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
        public ClassObjQuiz(string username)
        {
            totalQuestions = 5;
            InitializeComponent();
           
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

        private void back_Click(object sender, EventArgs e)
        {
            ClassObjects bck = new ClassObjects(logUser);
            this.Hide();
            bck.ShowDialog();
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Μια αφηρημένη περιγραφή αντικειμένων");
            answerCorrect.Add("Κάποιες μεταβλητές που ονομάζονται πεδία");
            answerCorrect.Add("Στιγμότυπο μιας κλάσης");
            answerCorrect.Add("Με την εντολή new");
            answerCorrect.Add("(1)Rectangle r2=new Rectangle();" + "\n" +
                "(2) r1.insert(11,5);");
        }

        private void ClassObjQuiz_Load(object sender, EventArgs e)
        {
            LoadQuestion();
        }
        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Τι είναι μια κλάση";
                    button1.Text = "Μια μέθοδος";
                    button2.Text = "Το αντίθετο του αντικειμένου";
                    button3.Text = "Μια αφηρημένη περιγραφή αντικειμένων";
                    button4.Text = "Όλα τα παραπάνω";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
                case 2:
                    lblQuestion.Text = "Μια κλάση ορίζεται από:";
                    button1.Text = "Χαρακτήρες";
                    button2.Text = "Τιμές";
                    button3.Text = "Ανιτκειμένα";
                    button4.Text = "Κάποιες μεταβλητές που ονομάζονται πεδία";
                    correctAnswer = 4;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
                case 3:
                    lblQuestion.Text = "Τι είναι ένα αντικείμενο";
                    button1.Text = "Αντίστροφο της μεθόδου";
                    button2.Text = "Στιγμότυπο μιας κλάσης";
                    button3.Text = "Μεταβλητή";
                    button4.Text = "Κονστράκτορας";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;

                case 4:
                    lblQuestion.Text = "Πως γίνεται η δημιουργία ενός αντικείμενου;";
                    button1.Text = "Με την εντολή new";
                    button2.Text = "Με ένα άλλο αντικείμενο";
                    button3.Text = "Με κλάση ";
                    button4.Text = "Με μία μέθοδο";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;

                case 5:
                    lblQuestion.Text = "Έστω ο κώδικας";
                    pictureBox1.Image = new Bitmap(@"Class\cq5.png");
                    pictureBox1.Size = new Size(506, 367);
                    pictureBox1.Location = new Point(265, 12);
                    lblQuestion.Location = new Point(234, 421);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Size = new Size(986, 705);
                    button1.Location = new Point(77, 486);
                    button2.Location = new Point(553, 486);
                    button3.Location = new Point(77, 589);
                    button4.Location = new Point(553, 589);
                    button1.Text = "(1)Rectangle r2=new Rectangle();" + "\n" +
                "(2) r1.insert(11,5);";

                    button2.Text = "(1)Rectangle r2=;" + "\n" +
                "(2) r1.insert;";

                    button3.Text = "(1)Rectangle r2=r1;" + "\n" +
                "(2) r1=r2;";

                    button4.Text = "(1)Rectangle r2=new r1();" + "\n"+
                        "(2) r1.insert=new r2;";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible=true;
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
                            cmd.Parameters.AddWithValue("@lesson", "Κλάσεις και αντικείμενα");
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
    }
}
