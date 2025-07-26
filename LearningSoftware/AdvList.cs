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
    public partial class AdvList : Form
    {
        int currentImageIndex = 0;
        List<Image> images = new List<Image>();
        string logUser;
        public AdvList(string username)
        {
            InitializeComponent();
            logUser = username;
        }

        private void AdvList_Load(object sender, EventArgs e)
        {
            LoadImages();
        }
        private void LoadImages()
        {
            images.Add(Image.FromFile(@"Lists\advL1.png"));
            images.Add(Image.FromFile(@"Lists\advL2.png"));
            images.Add(Image.FromFile(@"Lists\advL3.png"));
            images.Add(Image.FromFile(@"Lists\advL4.png")); 
            images.Add(Image.FromFile(@"Lists\advL5.png"));
            showslides.Image = images[currentImageIndex];
            previousPage.Enabled = false;
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

        private void backPage_Click(object sender, EventArgs e)
        {
            lists lst=new lists(logUser);
            this.Hide();
            lst.Show();
        }

        private void quiz_Click(object sender, EventArgs e)
        {
            QuizAdvList lst=new QuizAdvList(logUser);
            this.Hide();
            lst.Show();


        }
    }
    }
