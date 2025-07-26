using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class lists : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;

        string connectionString;


        public lists(string username)
        {
            InitializeComponent();
            logUser = username;
            LoadConnectionString();
            LoadImages();
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
    

        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Lists\l1.png"));
            images.Add(Image.FromFile(@"Lists\l2.png"));
            images.Add(Image.FromFile(@"Lists\l3.png"));
            images.Add(Image.FromFile(@"Lists\l4.png"));
            images.Add(Image.FromFile(@"Lists\l5.png"));
            images.Add(Image.FromFile(@"Lists\l6.png"));
            images.Add(Image.FromFile(@"Lists\l7.png"));
            images.Add(Image.FromFile(@"Lists\l8.png"));
            images.Add(Image.FromFile(@"Lists\l9.png"));
            images.Add(Image.FromFile(@"Lists\l10.png"));
            images.Add(Image.FromFile(@"Lists\l11.png"));
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
            nextPage.Enabled = true;
        }

        private void lists_Load(object sender, EventArgs e)
        {
            if (currentImageIndex == 0)
            {
                previousPage.Enabled = false;
            }
            string newDateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO visits (username, lesson, datetime) VALUES (@username, @lesson, @datetime)";
                AdvBeg();

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", logUser);
                    cmd.Parameters.AddWithValue("@lesson", "Λίστες");
                    cmd.Parameters.AddWithValue("@datetime", newDateTime);
                    cmd.ExecuteNonQuery();
                }

            }
        }




        private void quiz_Click(object sender, EventArgs e)
        {
            QuizStartJava quiz = new QuizStartJava(logUser);
            this.Hide();
            quiz.ShowDialog();
        }

        private void showslides_Click_1(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            UserMenu usermenu = new UserMenu(logUser);
            this.Hide();
            usermenu.ShowDialog();
        }
        public void AdvBeg()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                int begPercentage = RecentPercentage(connection, "Τεστ βοηθητικού υλικού στις Λίστες");
                int normalPercentage = RecentPercentage(connection, "Λίστες");

                if (normalPercentage >= 50 || begPercentage >= 50)
                {
                    advButton.Visible = true;
                    begButton.Visible = false;
                    advButton.Location = new Point(249, 14);
                }
                else if (normalPercentage < 50 && normalPercentage != -1)
                {
                    advButton.Visible = false;
                    begButton.Visible = true;
                }
                else
                {
                    advButton.Visible = false;
                    begButton.Visible = false;
                }
            }
        }

        public int RecentPercentage(NpgsqlConnection connection, string lesson)
        {
            string query = @"SELECT percentage FROM scores WHERE username = @username AND lesson = @lesson ORDER BY datetime DESC LIMIT 1";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", logUser);
                cmd.Parameters.AddWithValue("@lesson", lesson);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            return -1;
        }
        private void nextPage_Click(object sender, EventArgs e)
        {
            currentImageIndex++;

            if (currentImageIndex >= images.Count)
            {
                currentImageIndex = 0;
            }

            showslides.Image = images[currentImageIndex];

            if (currentImageIndex == images.Count - 1)
            {
                nextPage.Enabled = false;
            }

            previousPage.Enabled = true;
        }

        private void previousPage_Click(object sender, EventArgs e)
        {
            currentImageIndex--;

            if (currentImageIndex < 0)
            {
                currentImageIndex = images.Count - 1;
            }

            showslides.Image = images[currentImageIndex];

            if (currentImageIndex == 0)
            {
                previousPage.Enabled = false;
            }

            nextPage.Enabled = true;
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            UserMenu lessons = new UserMenu(logUser);
            this.Hide();
            lessons.ShowDialog();
        }

        private void quiz_Click_1(object sender, EventArgs e)
        {
            QuizList qzl=new QuizList(logUser);
            this.Hide();
            qzl.ShowDialog();  
        }

        private void begButton_Click(object sender, EventArgs e)
        {
            beginnerList beg = new beginnerList(logUser);
            this.Hide();
            beg.ShowDialog();
        }

        private void advButton_Click(object sender, EventArgs e)
        {
            AdvList adv = new AdvList(logUser);
            this.Hide();
            adv.ShowDialog();
        }
    }
}
