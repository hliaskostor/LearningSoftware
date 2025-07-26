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
using Image = System.Drawing.Image;

namespace LearningSoftware
{
    public partial class AdvInt : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
        public AdvInt(string username)
        {
            InitializeComponent();
            logUser = username;
        }

        private void AdvInt_Load(object sender, EventArgs e)
        {
            LoadImages();
        }
        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Interface\AdvInt1.png"));
            images.Add(Image.FromFile(@"Interface\AdvInt2.png"));
            images.Add(Image.FromFile(@"Interface\AdvInt3.png"));
           
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
            nextPage.Enabled = true;
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

        private void backPage_Click(object sender, EventArgs e)
        {
            Interface inter = new Interface(logUser);
            this.Hide();
            inter.Show();
        }

        private void quiz_Click(object sender, EventArgs e)
        {
            QuizAdvInt adv=new QuizAdvInt(logUser);
            this.Hide();
            adv.Show();
        }
    }
}

