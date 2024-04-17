using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Accounting_of_applications
{
    public partial class Employer : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Accounting_of_applications";
        int id_employer;
        public Employer(int id)
        {
            InitializeComponent();
            id_employer = id;
            Select_datagrid("");
        }
        private void Select_datagrid(string text)
        {
            string query = "SELECT application.id, level_education.title AS level_education_title, status.title AS status_title, application.id_employer, application.first_name, application.second_name, application.surname, application.passport, application.snils, application.email, application.phone, application.parent_first_name, application.parent_second_name, application.parent_surname, application.previous_institution, application.document, application.comment, application.start_date, application.end_date, application.id_user, direction.title AS direction_title " +
                   "FROM application " +
                   "JOIN level_education ON application.id_level_education = level_education.id " +
                   "JOIN status ON application.id_status = status.id " +
                   "JOIN application_direction ON application.id = application_direction.id_application " +
                   "JOIN direction ON application_direction.id_direction = direction.id "+text;


            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "application");
                    dataGridView_application.DataSource = dataSet.Tables["application"];
                    dataGridView_application.Columns[0].HeaderText = "ID";
                    dataGridView_application.Columns[1].HeaderText = "Уровень образования";
                    dataGridView_application.Columns[2].HeaderText = "Статус";
                    dataGridView_application.Columns[3].HeaderText = "ID Работодателя";
                    dataGridView_application.Columns[4].HeaderText = "Имя";
                    dataGridView_application.Columns[5].HeaderText = "Фамилия";
                    dataGridView_application.Columns[6].HeaderText = "Отчество";
                    dataGridView_application.Columns[7].HeaderText = "Паспорт";
                    dataGridView_application.Columns[8].HeaderText = "СНИЛС";
                    dataGridView_application.Columns[9].HeaderText = "Почта";
                    dataGridView_application.Columns[10].HeaderText = "Телефон";
                    dataGridView_application.Columns[11].HeaderText = "Имя родителя";
                    dataGridView_application.Columns[12].HeaderText = "Фамилия родителя";
                    dataGridView_application.Columns[13].HeaderText = "Отчество родителя";
                    dataGridView_application.Columns[14].HeaderText = "Предыдущее учреждение";
                    dataGridView_application.Columns[15].HeaderText = "Документ об образовании";
                    dataGridView_application.Columns[16].HeaderText = "Комментарий";
                    dataGridView_application.Columns[17].HeaderText = "Дата начала";
                    dataGridView_application.Columns[18].HeaderText = "Дата окончания";
                    dataGridView_application.Columns[19].HeaderText = "ID Пользователя";
                    dataGridView_application.Columns[20].HeaderText = "Направление";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string text = "where DATE(start_date) = '" + dateTimePicker1.Value+"'";
            Select_datagrid(text);
        }

        private void dataGridView_application_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int applicationId = Convert.ToInt32(dataGridView_application.Rows[e.RowIndex].Cells[0].Value);
                Comment comment = new Comment(applicationId, id_employer);
                comment.ShowDialog();
            }
        }

        private void dataGridView_application_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_application.SelectedRows.Count > 0)
            {
                int applicationId = Convert.ToInt32(dataGridView_application.SelectedRows[0].Cells[0].Value);
                Comment comment = new Comment(applicationId, id_employer);
                comment.ShowDialog();

            }
        }

        private void Employer_Load(object sender, EventArgs e)
        {
            Select_datagrid("");
        }

        private void button_stat_Click(object sender, EventArgs e)
        {
            Stat stat = new Stat(id_employer);
            stat.ShowDialog();
        }

        private void textBox_number_TextChanged(object sender, EventArgs e)
        {
            if (textBox_number.Text == "")
            {
                Select_datagrid("");
            }
            else
            {
                string text = "where application.id = '" + textBox_number.Text + "'";
                Select_datagrid(text);
            }
        }
    }
}
