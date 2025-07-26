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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LearningSoftware
{
    public partial class beginnerMethod : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;

    
        public beginnerMethod(string username)
        {
            InitializeComponent();
            logUser = username;
            LoadImages();
          
        }
        

        private void beginnerMethod_Load(object sender, EventArgs e)
        {
            if (currentImageIndex == 0)
            {
                previousPage.Enabled = false;
            }
        }
        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Methods\bmet1.png"));
            images.Add(Image.FromFile(@"Methods\bmet2.png"));
            images.Add(Image.FromFile(@"Methods\bmet3.png"));
            images.Add(Image.FromFile(@"Methods\bmet4.png"));
            images.Add(Image.FromFile(@"Methods\bmet5.png"));
            showslides.Image = images[currentImageIndex];

        }
        

        private void quiz_Click(object sender, EventArgs e)
        {
            quizbegMeth quiz = new quizbegMeth(logUser);
            this.Hide();
            quiz.ShowDialog();
        }

        private void backPage_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.ShowDialog();
        }

        private void nextPage_Click_1(object sender, EventArgs e)
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

        private void showslides_Click(object sender, EventArgs e)
        {

        }
    }
}
