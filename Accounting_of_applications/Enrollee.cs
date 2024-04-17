using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace Accounting_of_applications
{
    public partial class Enrollee : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Accounting_of_applications";
        int id_user_;
        string second_name;
        string first_name;
        string surname;
        List<string> educationAreas;
        private PrintDocument printDocument = new PrintDocument();
        public Enrollee(int id_user)
        {
            InitializeComponent();
            id_user_ = id_user;
            Select_datagrid();
        }
        private void Select_datagrid ()
        {
            string query = "SELECT application.id, level_education.title AS level_education_title, direction.title AS direction_title, status.title AS status_title, application.comment " +
               "FROM application " +
               "JOIN level_education ON application.id_level_education = level_education.id " +
               "JOIN application_direction ON application.id = application_direction.id_application " +
               "JOIN direction ON application_direction.id_direction = direction.id " +
               "JOIN status ON application.id_status = status.id " +
               "WHERE application.id_user = @UserId";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", id_user_);
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "applications");
                    dataGridView_applications.DataSource = dataSet.Tables["applications"];
                    dataGridView_applications.Columns[0].HeaderText = "ID";
                    dataGridView_applications.Columns[1].HeaderText = "Уровень образования";
                    dataGridView_applications.Columns[2].HeaderText = "Направление";
                    dataGridView_applications.Columns[3].HeaderText = "Статус";
                    dataGridView_applications.Columns[4].HeaderText = "Комментарий";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }
        }
        private void Select_fullName()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT second_name, first_name, surname FROM application WHERE id_user = @id_user";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id_user", id_user_);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            second_name = reader.GetString(0);
                            first_name = reader.GetString(1);
                            surname = reader.GetString(2);
                        }
                        else
                        {
                            // Если не найдено ни одной записи
                            // Можно добавить соответствующую обработку
                        }
                    }
                }
            }
        }
        private void Select_directions()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT direction.title " +
                            "FROM direction " +
                            "JOIN application_direction ON application_direction.id_direction = direction.id " +
                            "JOIN application ON application.id = application_direction.id_application " +
                            "WHERE application.id_user = "+13+"";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        educationAreas = new List<string>();
                        while (reader.Read())
                        {
                            educationAreas.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void button_pdf_Click(object sender, EventArgs e)
        {
            Select_fullName();
            Select_directions();
            if (dataGridView_applications.SelectedRows.Count > 0)
            {
                int selectedRowID = (int)dataGridView_applications.SelectedRows[0].Cells["id"].Value;

                printDocument.PrintPage += (s, ev) =>
                {
                    int startX = 10;
                    int startY = 10;
                    int offset = 20;
                    Graphics g = ev.Graphics;

                    string fullName = second_name+" "+first_name+" "+surname;

                    // Measure string width 
                    SizeF textSize = g.MeasureString("ЗАЯВЛЕНИЕ", new Font("Arial", 14, FontStyle.Bold));
                    int headerX = (int)((ev.PageBounds.Width - textSize.Width) / 2); // Calculate X position for centering 

                    // Draw document header 
                    g.DrawString("ЗАЯВЛЕНИЕ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, headerX, startY);
                    startY += offset * 2;

                    // Draw student's full name
                    g.DrawString($"Я, {fullName}, подал документы в ВУЗ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, startX, startY);
                    startY += offset * 2;

                    // Draw education areas 
                    g.DrawString("На направления подготовки:", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, startX, startY);
                    startY += offset;
                    foreach (string area in educationAreas)
                    {
                        g.DrawString(area, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, startX, startY);
                        startY += offset;
                    }

                    // Draw date 
                    startY += offset * 2;
                    g.DrawString(DateTime.Now.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, startX, startY);
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявление для печати.");
            }
        }
    }
}

