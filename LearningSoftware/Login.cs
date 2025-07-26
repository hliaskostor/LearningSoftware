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
    public partial class Login : Form

    {
        string connectionString;


        NpgsqlConnection dbcon;


        public Login()
        {
            InitializeComponent();
            LoadConnectionString();


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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
                HomePage home = new HomePage();
            this.Hide();
            home.ShowDialog();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (dbcon = new NpgsqlConnection(connectionString))
            {
                try
                {
                    dbcon.Open();

                    string query = "SELECT * FROM students WHERE username = @username AND password = @password";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, dbcon))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameText.Text);
                        cmd.Parameters.AddWithValue("@password", passwordText.Text);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("Επιτυχής σύνδεση" );
                                    
                                UserMenu menu = new UserMenu(usernameText.Text);
                                this.Hide();
                                menu.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Λάθος στοιχεία");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
             
            }
        }




        private void showpass_CheckedChanged(object sender, EventArgs e)
        {

            if (showpass.Checked)
            {
                passwordText.PasswordChar = '\0';
            }
            else
            {
                passwordText.PasswordChar = '*';
            }
        }



        private void passwordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}

