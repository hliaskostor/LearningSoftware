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
    public partial class UserMenu : Form
    {
      string logUser;
        public UserMenu(string username)
        {
            InitializeComponent();
            logUser = username;
            label1.Text="Καλώς ήρθες,"+username;

        }

        private void startjava_Click(object sender, EventArgs e)
        {
            StartJava start=new StartJava(logUser);
            this.Hide();
            start.ShowDialog();
        }

        private void Lessons_Load(object sender, EventArgs e)
        {

        }

        private void total_Click(object sender, EventArgs e)
        {
            userTotal total = new userTotal(logUser);
            this.Hide();
            total.ShowDialog();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close(); 
            Login login = new Login(); 
            login.Show();
        }

        private void visits_Click(object sender, EventArgs e)
        {
            Visits visits = new Visits(logUser);
            this.Hide();
            visits.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void methods_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods(logUser);
            this.Hide();
            methods.ShowDialog();
        }

        private void classButton_Click(object sender, EventArgs e)
        {
            ClassObjects classes = new ClassObjects(logUser);
            this.Hide();
            classes.ShowDialog();
        }

        private void listsButton_Click(object sender, EventArgs e)
        {
           lists lists = new lists(logUser);
            this.Hide();
            lists.ShowDialog();
        }

        private void interfacebutton_Click(object sender, EventArgs e)
        {
            Interface interfaces = new Interface(logUser);
            this.Hide();
            interfaces.ShowDialog();
        }

        private void revise_Click(object sender, EventArgs e)
        {
            reviseQuiz rvs=new reviseQuiz(logUser);
            this.Hide();
            rvs.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
 