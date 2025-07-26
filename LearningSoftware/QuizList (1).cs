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
    public partial class QuizList : Form
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
        public QuizList(string username)
        {
            InitializeComponent();
            totalQuestions = 4;
            LoadConnectionString();
            checkAnswer();
            logUser = username;
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Διπλά συνδεδεμένη λίστα");
            answerCorrect.Add("ArrayList: Πίνακας μεταβλητού μεγέθους\"n" +"LinkedList:Διπλά συνδεδεμένη λίστα");
            answerCorrect.Add("Όχι");
            answerCorrect.Add("[Java, Java, Java]");

        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "Τι χρησιμοποιεί η LinkedList";
                    button1.Text = "Τίποτα";
                    button2.Text = "Διπλά συνδεδεμένη λίστα";
                    button3.Text = "Ένα στοιχείο";
                    button4.Text = "Μια υποκλάση";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    break;
                case 2:
                    lblQuestion.Text = "Ποια είναι η διαφορά μεταξύ LinkedList και ArrayList ";
                    button1.Text = "ArrayList:Πίνακας μεταβλητού μεγέθους\"n" +
                    "LinkedList:Διπλά συνδεδεμένη λίστα";
                    button2.Text = "Είναι ίδιες";
                    button3.Text = "Η μια είναι κλάση και η άλλη αντικείμενο";
                    button4.Text = "Τίποτα";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    break;
                case 3:
                    lblQuestion.Text = "Είναι σωστό";
                    button1.Text = "Ναι";
                    button2.Text = "Όχι";
                    correctAnswer = 2;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = false;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Lists\lq2.png");
                    break;
                case 4:
                    lblQuestion.Text = "Τι θα εκτυπώσει στην έξοδο";
                    button1.Text = "Error";
                    button2.Text = "Java";
                    button3.Text = "[Java,Java,Java]";
                    button4.Text = "ex";
                    correctAnswer = 3;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Lists\lq1.png");
                    break;


            }
        }
        private void QuizList_Load(object sender, EventArgs e)
        {
            LoadQuestion();
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
                            cmd.Parameters.AddWithValue("@lesson", "Λίστες");
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

        private void back_Click(object sender, EventArgs e)
        {
            lists lst = new lists(logUser);
            this.Hide();
            lst.Show();
        }
    }
}
