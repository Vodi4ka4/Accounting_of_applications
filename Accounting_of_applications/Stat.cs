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

namespace Accounting_of_applications
{
    public partial class Stat : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Accounting_of_applications";
        int id_employer = 0;
        TimeSpan time;
        public Stat(int id)
        {
            InitializeComponent();
            id_employer = id;
            Call();
            Select_comboBox();
            Time();
        }
        private void Call()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id FROM application WHERE id_employer = @id_employer";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_employer", id_employer);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            label_call.Text = Convert.ToString(Convert.ToInt32(label_call.Text) + 1);
                        }
                    }
                }
            }
        }
        private void Time()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT start_date, end_date FROM application WHERE id_employer = @id_employer";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_employer", id_employer);
                    TimeSpan totalTime = TimeSpan.Zero;
                    int count = 0;
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime startTime = reader.GetDateTime(0);
                            DateTime endTime = reader.GetDateTime(1);
                            totalTime += (endTime - startTime);
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        TimeSpan averageTime = TimeSpan.FromTicks(totalTime.Ticks / count);
                        label_time.Text = averageTime.ToString();
                    }
                    else
                    {
                        label_time.Text = "Нет данных для расчета";
                    }
                }
            }
        }
        private void Select_comboBox()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT title FROM level_education";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox_level_education.Items.Add(reader.GetString(0));
                        }

                    }
                }
            }
        }
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id FROM application WHERE id_employer = @id_employer AND id_level_education = @id_level_education";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_employer", id_employer);
                    command.Parameters.AddWithValue("@id_level_education", comboBox_level_education.SelectedIndex + 1);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            label_type.Text = Convert.ToString(Convert.ToInt32(label_call.Text) + 1);
                        }
                    }
                }
            }
        }
    }
}
