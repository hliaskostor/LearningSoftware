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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LearningSoftware
{
    public partial class TotalUsage : Form
    {
        string logUser;
        string connectionString = "Server=localhost;port=5432;Database=java;UserID=postgres;Password=0000";
        public TotalUsage(string username)
        {
            InitializeComponent();
            logUser = username;
            totalusage(logUser);
            totalvisits(logUser);
        }

        private void TotalUsage_Load(object sender, EventArgs e)
        {

        }
        private void totalusage(string username)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT lesson AS \"Κεφάλαιο\", datetime AS \"Ώρα επίσκεψης\" FROM visits WHERE username = @username";
                ;

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
                        visits.DataSource = dataTable;
                    }
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            HomePage lessons = new HomePage(logUser);
            this.Hide();
            lessons.ShowDialog();
        }

        private void connections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
