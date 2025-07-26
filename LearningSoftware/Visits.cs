using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace LearningSoftware
{
    public partial class Visits : Form
    {
        string logUser;
        string connectionString;
        public Visits(string username)
        {
            InitializeComponent();
            logUser = username;
            LoadConnectionString();
            totalusage(logUser);
            totalvisits(logUser);
        }

        private void Visits_Load(object sender, EventArgs e)
        {
        

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
        private void totalusage(string username)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT lesson AS \"Κεφάλαιο\", datetime AS \"Ώρα επίσκεψης\" FROM visits WHERE username = @username";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connections.DataSource = dataTable;
                    }
                }
            }
        }

        private void totalvisits(string username)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT lesson AS \"Κεφάλαιο\", COUNT(*) AS \"Αριθμός επισκέψεων\" FROM visits WHERE username = @username GROUP BY lesson";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        totalVisits.DataSource = dataTable;
                    }
                }
            }
        }

      

        private void back_Click(object sender, EventArgs e)
        {
            UserMenu usermenu = new UserMenu(logUser);
            this.Hide();
            usermenu.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void connections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
