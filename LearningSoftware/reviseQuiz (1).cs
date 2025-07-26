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
    public partial class reviseQuiz : Form
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
        public reviseQuiz(string username)
        {
            InitializeComponent();
            totalQuestions = 10;
            logUser = username;
        }
        public void checkAnswer()
        {
            answerCorrect.Add("Μια συλλογή μεθόδων");
            answerCorrect.Add("Λάθος");
            answerCorrect.Add("Όχι");
            answerCorrect.Add("[Java, Java, Java]");

        }

        private void LoadQuestion()
        {
            switch (qnum)
            {
                case 1:
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
                case 2:
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
                case 3:
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

                    button4.Text = "(1)Rectangle r2=new r1();" + "\n" +
                        "(2) r1.insert=new r2;";
                    correctAnswer = 1;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    pictureBox1.Visible = true;
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
                case 5:
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
                    this.Size = new Size(816, 489);
                    button1.Location = new Point(52, 281);
                    button2.Location = new Point(578, 281);
                    button3.Location = new Point(52, 391);
                    button4.Location = new Point(578, 391);
                    lblQuestion.Location = new Point(194, 200);
                    break;
                case 6:
                    lblQuestion.Text = "Πόσες φορές θα εκτυπωθεί το μήνυμα Java ";
                    button1.Text = "2 φορές";
                    button2.Text = "3 φορές ";
                    button3.Text = "Error";
                    button4.Text = "1 φορά";
                    correctAnswer = 2;
                    pictureBox1.Visible = true;
                    pictureBox1.Image = new Bitmap(@"Methods\mq4.png");
                    this.Size = new Size(908, 582);
                    pictureBox1.Size = new Size(420, 251);
                    pictureBox1.Location = new Point(213, 28);
                    button1.Location = new Point(72, 368);
                    button2.Location = new Point(584, 368);
                    button3.Location = new Point(72, 478);
                    button4.Location = new Point(584, 478);
                    lblQuestion.Location = new Point(209, 294);
                    break;
                case 7:
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
                    this.Size = new Size(916, 645);
                    button1.Location = new Point(28, 369);
                    button2.Location = new Point(554, 369);
                    button3.Location = new Point(28, 481);
                    button4.Location = new Point(554, 481);
                    break;
                case 8:
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
                case 9:
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
                case 10:
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

            }
        }
        private void reviseQuiz_Load(object sender, EventArgs e)
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
                            cmd.Parameters.AddWithValue("@lesson", "Επαναληπτικό τέστ");
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
            switch (questionNumber)
            {
                case 1:
                    return "Διπλά συνδεδεμένη λίστα";
                case 2:
                    return "ArrayList:Πίνακας μεταβλητού μεγέθους\"n" +
                        "LinkedList:Διπλά συνδεδεμένη λίστα";
                case 3:
                    return "Όχι";
                case 4:
                    return "[Java,Java,Java]";
                default:
                    return "";
            }
        }



        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

       

        private void back_Click_1(object sender, EventArgs e)
        {

        UserMenu usr=new UserMenu(logUser);
            this.Hide();
            usr.Show();
        }
    }
}
