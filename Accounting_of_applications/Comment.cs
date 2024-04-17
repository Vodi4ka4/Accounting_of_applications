using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_of_applications
{
    public partial class Comment : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Accounting_of_applications";
        int id_employer_;
        int id_application;
        public Comment(int applicationId, int id_employer)
        {
            id_employer_ = id_employer;
            id_application = applicationId;
            InitializeComponent();
            Select_comboxBox_status();
        }
        private void Select_comboxBox_status()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT title FROM status";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox_status.Items.Add(reader.GetString(0));
                        }

                    }
                }
            }
        }
        private void Update_application ()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE application SET id_employer = " + id_employer_ + ", " +
                                      "id_status = " + (comboBox_status.SelectedIndex + 1) + ", " +
                                      "comment = '" + textBox_comment.Text + "', " +
                                      "end_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                                      "WHERE id = " + id_application;
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                        {
                            command.ExecuteNonQuery();
                        }
                    connection.Close();
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Update_application();
            this.Close();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_document_Click(object sender, EventArgs e)
        {
            string path = "";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT document FROM application where id = '"+id_application+"'";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            path = reader.GetString(0);
                        }

                    }
                }
            }
            string filePath = path;

                // Запускаем процесс, ассоциированный с PDF-файлом
                Process.Start(filePath);
        }
    }
}
