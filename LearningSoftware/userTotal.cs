using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LearningSoftware
{
    public partial class userTotal : Form
    {
        string logUser;
        string connectionString;

        public userTotal(string username)
        {
            InitializeComponent();
            logUser = username;
            LoadConnectionString();
            totalscores(logUser);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void totalscores(string username)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT lesson AS \"Κεφάλαιο\", score AS \"Σωστές απαντήσεις\", percentage AS \"Ποσοστό\" FROM scores WHERE username = @username";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;

                            if (dataTable.Rows.Count > 0)
                            {
                                double totalPercentage = 0;
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    totalPercentage += Convert.ToDouble(row["Ποσοστό"]);
                                }
                                double averagePercentage = totalPercentage / dataTable.Rows.Count;

                            
                                if (averagePercentage > 100.00)
                                {
                                    averagePercentage = 100.00;
                                }

                                label1.Text = $"Μέσος όρος: {averagePercentage:F2}%";

                                chart1.Series.Clear();
                                chart1.Titles.Clear();
                                chart1.Titles.Add("Προόδος");

                                Series series = new Series
                                {
                                    Name = "Βαθμολογίες",
                                    Color = Color.Blue,
                                    ChartType = SeriesChartType.Column
                                };

                                chart1.Series.Add(series);

                                foreach (DataRow row in dataTable.Rows)
                                {
                                    series.Points.AddXY(row["Κεφάλαιο"].ToString(), Convert.ToDouble(row["Ποσοστό"]));
                                }

                                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0; 
                                chart1.Invalidate();
                            }
                            else
                            {
                                label1.Text = "Μέσος όρος: N/Α";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void userTotal_Load(object sender, EventArgs e)
        {
        }

        private void back_Click(object sender, EventArgs e)
        {
            UserMenu lessons = new UserMenu(logUser);
            this.Hide();
            lessons.ShowDialog();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }
    }
}
