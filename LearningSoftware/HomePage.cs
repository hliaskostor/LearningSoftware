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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void register_Click(object sender, EventArgs e)
        {
            CreateUser create = new CreateUser();
            this.Hide();
            create.ShowDialog();
        }

        

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void manual_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "manual.chm");
        }
    }
}
