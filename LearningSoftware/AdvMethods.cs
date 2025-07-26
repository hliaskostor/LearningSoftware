using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Image = System.Drawing.Image;

namespace LearningSoftware
{
    public partial class AdvMethods : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
        public AdvMethods(string username)
        {
            InitializeComponent();
            LoadImages();
            logUser = username;
        }
        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Methods\advmet1.png"));
            images.Add(Image.FromFile(@"Methods\advmet2.png"));
            images.Add(Image.FromFile(@"Methods\advmet3.png"));
            images.Add(Image.FromFile(@"Methods\advmet4.png"));
            images.Add(Image.FromFile(@"Methods\advmet5.png"));
            images.Add(Image.FromFile(@"Methods\advmet6.png"));
            images.Add(Image.FromFile(@"Methods\advmet7.png"));
            images.Add(Image.FromFile(@"Methods\advmet8.png"));
            images.Add(Image.FromFile(@"Methods\advmet9.png"));
            showslides.Image = images[currentImageIndex];
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

        private void AdvMethods_Load(object sender, EventArgs e)
        {
            if (currentImageIndex == 0)
            {
                previousPage.Enabled = false;
            }
        }

        private void backPage_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.Show();
        }

        private void quiz_Click(object sender, EventArgs e)
        {
            QuizAdvMet quiz = new QuizAdvMet(logUser);
            this.Hide();
            quiz.Show();
        }
    }
}
