using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class StartJava : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
    
        string connectionString;


        public StartJava(string username)
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
            images.Add(Image.FromFile(@"StartJava\1.png"));
            images.Add(Image.FromFile(@"StartJava\2.png"));
            images.Add(Image.FromFile(@"StartJava\3.png"));
            images.Add(Image.FromFile(@"StartJava\4.png"));
            images.Add(Image.FromFile(@"StartJava\5.png"));
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
            nextPage.Enabled = true;
        }

        private void StartJava_Load(object sender, EventArgs e)
        {
            string newDateTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO visits (username, lesson, datetime) VALUES (@username, @lesson, @datetime)";


                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", logUser);
                    cmd.Parameters.AddWithValue("@lesson", "Τι είναι η Java");
                    cmd.Parameters.AddWithValue("@datetime", newDateTime);
                    cmd.ExecuteNonQuery();
                }

            }
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


   

    

        private void showslides_Click(object sender, EventArgs e)
        {

        }

     

        private void previousPage_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {

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
    }
}
