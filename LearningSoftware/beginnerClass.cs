using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class beginnerClass : Form
    {
        string connectionString;

        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
        public beginnerClass(string username)
        {
       
            InitializeComponent();
            LoadImages();
            LoadConnectionString();
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

     


        public void LoadImages()
        {
            images.Add(Image.FromFile(@"Class\cb1.png"));
            images.Add(Image.FromFile(@"Class\cb2.png"));
            images.Add(Image.FromFile(@"Class\cb3.png"));
            images.Add(Image.FromFile(@"Class\cb4.png"));
            images.Add(Image.FromFile(@"Class\cb5.png"));
            images.Add(Image.FromFile(@"Class\cb6.png"));
            images.Add(Image.FromFile(@"Class\cb7.png"));
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
            nextPage.Enabled = true;

        }

        private void beginnerClass_Load(object sender, EventArgs e)
        {
          
        }

        private void showslides_Click(object sender, EventArgs e)
        {

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


        private void button1_Click(object sender, EventArgs e)
        {
            begQuizClass bgq=new begQuizClass(logUser);
            this.Hide();
            bgq.ShowDialog();
        }

        private void backPage_Click(object sender, EventArgs e)
        {
            ClassObjects co = new ClassObjects(logUser);
            this.Hide();
            co.ShowDialog();
        }

       
    }
}
