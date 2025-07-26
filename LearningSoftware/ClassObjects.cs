using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LearningSoftware
{
    public partial class ClassObjects : Form
    {
        string connectionString;
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;

        public ClassObjects(string username)
        {
            logUser = username;
            InitializeComponent();
            LoadImages();
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

        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Class\c1.png"));
            images.Add(Image.FromFile(@"Class\c2.png"));
            images.Add(Image.FromFile(@"Class\c3.png"));
            images.Add(Image.FromFile(@"Class\c4.png"));
            images.Add(Image.FromFile(@"Class\c5.png"));
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
        }

        private void ClassObjects_Load(object sender, EventArgs e)
        {
            string newDateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO visits (username, lesson, datetime) VALUES (@username, @lesson, @datetime)";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", logUser);
                    cmd.Parameters.AddWithValue("@lesson", "Κλάσεις και αντικείμενα");
                    cmd.Parameters.AddWithValue("@datetime", newDateTime);
                    cmd.ExecuteNonQuery();
                }

                AdvBeg();
            }
        }

        public void AdvBeg()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                int begPercentage = recentPercentage(connection, "Τεστ βοηθητικού υλικού στις κλάσεις και αντικείμενα");
                int normalPercentage = recentPercentage(connection, "Κλάσεις και αντικείμενα");

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

        public int recentPercentage(NpgsqlConnection connection, string lesson)
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

        private void back_Click(object sender, EventArgs e)
        {
            UserMenu usermenu = new UserMenu(logUser);
            this.Hide();
            usermenu.ShowDialog();
        }

        private void quiz_Click(object sender, EventArgs e)
        {
            ClassObjQuiz quiz = new ClassObjQuiz(logUser);
            this.Hide();
            quiz.ShowDialog();
        }

        private void advButton_Click(object sender, EventArgs e)
        {
            AdvClassObj advance = new AdvClassObj(logUser);
            this.Hide();
            advance.ShowDialog();
        }

        private void begButton_Click(object sender, EventArgs e)
        {
            beginnerClass beg = new beginnerClass(logUser);
            this.Hide();
            beg.ShowDialog();
        }
    }
}
