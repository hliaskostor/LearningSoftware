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
    public partial class AdvClassObj : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
        public AdvClassObj(string username)
        {
            InitializeComponent();
            LoadImages();
            logUser = username;
        }
        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Class\ac1.png"));
            images.Add(Image.FromFile(@"Class\ac2.png"));
            images.Add(Image.FromFile(@"Class\ac3.png"));
            images.Add(Image.FromFile(@"Class\ac4.png"));
            images.Add(Image.FromFile(@"Class\ac5.png"));
            showslides.Image = images[currentImageIndex];
        }


        private void AdvClassObj_Load(object sender, EventArgs e)
        {
            if (currentImageIndex == 0)
            {
                previousPage.Enabled = false;
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

        private void quiz_Click(object sender, EventArgs e)
        {
            QuizAdvClass quiz=new QuizAdvClass(logUser);
            this.Hide();
            quiz.Show();
        }

        private void backPage_Click(object sender, EventArgs e)
        {
            ClassObjects co=new ClassObjects(logUser);
            this.Hide();
            co.Show();
        }
    }
}
