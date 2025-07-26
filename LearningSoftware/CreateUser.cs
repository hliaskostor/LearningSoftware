using Npgsql;
using System;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class CreateUser : Form
    {
        string connectionString;

        NpgsqlConnection dbcon;

        public CreateUser()
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

        private void CreateUser_Load(object sender, EventArgs e)
        {
            newpassword.PasswordChar = '*';
        }

        private void back_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            this.Hide();
            home.ShowDialog();
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            newpassword.PasswordChar = showpass.Checked ? '\0' : '*';
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newname.Text) ||
                string.IsNullOrWhiteSpace(newsurname.Text) ||
                string.IsNullOrWhiteSpace(newusername.Text) ||
                string.IsNullOrWhiteSpace(newpassword.Text))
            {
                MessageBox.Show("Η εγγραφή ήταν ανεπιτυχής, συμπληρώστε όλα τα πεδία");
                return;
            }

            using (dbcon = new NpgsqlConnection(connectionString))
            {
                try
                {
                    dbcon.Open();

                    string checkQuery = "SELECT COUNT(*) FROM students WHERE username = @username";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, dbcon))
                    {
                        checkCmd.Parameters.AddWithValue("@username", newusername.Text);
                        int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (userCount > 0)
                        {
                            MessageBox.Show("Ο χρήστης υπάρχει ήδη");
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO students (name, surname, username, password) VALUES (@name, @surname, @username, @password)";
                    using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertQuery, dbcon))
                    {
                        insertCmd.Parameters.AddWithValue("@name", newname.Text);
                        insertCmd.Parameters.AddWithValue("@surname", newsurname.Text);
                        insertCmd.Parameters.AddWithValue("@username", newusername.Text);
                        insertCmd.Parameters.AddWithValue("@password", newpassword.Text);

                        int count = insertCmd.ExecuteNonQuery();
                        if (count > 0)
                        {
                            MessageBox.Show("Η εγγραφή ήταν επιτυχής");
                            Login login = new Login();
                            this.Hide();
                            login.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Η εγγραφή απέτυχε");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
