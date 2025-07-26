using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningSoftware
{
    public partial class beginnerInterface : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
        public beginnerInterface(string username)
        {
            InitializeComponent();
            logUser = username;
        }

        private void beginnerInterface_Load(object sender, EventArgs e)
        {
            LoadImages();
        }
        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Interface\interbeg1.png"));
            images.Add(Image.FromFile(@"Interface\interbeg2.png"));
            images.Add(Image.FromFile(@"Interface\interbeg3.png"));
            images.Add(Image.FromFile(@"Interface\interbeg4.png"));
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
            nextPage.Enabled = true;
        }

        private void back_Click(object sender, EventArgs e)
        {

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

        private void quiz_Click(object sender, EventArgs e)
        {
            QuizBegInt qz = new QuizBegInt(logUser);
            this.Hide();
            qz.Show();
        }
    }
}
