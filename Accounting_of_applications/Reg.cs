using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Accounting_of_applications
{
    public partial class Reg : Form
    {
        DataTable dataTable = new DataTable();
        string path;
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Accounting_of_applications";
        int id_level_education;
        int id_user;
        public Reg()
        {
            InitializeComponent();
            select_level_education();
            select_datagrid();
        }
        private void select_level_education()
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
        }//Заполняет combobox с уровнем образования
        private void select_checkedListBox_direction()
        {
            checkedListBox_direction.Items.Clear();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT title FROM direction WHERE id_level_education = (SELECT id FROM level_education WHERE title = '"+comboBox_level_education.SelectedItem.ToString()+ "')";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            checkedListBox_direction.Items.Add(reader.GetString(0));
                        }

                    }
                }
            }
        }//Заполняет направления
        private void visible_panel()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id FROM level_education where title = '"+comboBox_level_education.SelectedItem.ToString()+"'";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        id_level_education = reader.GetInt32(0);
                        if (reader.GetInt32(0) == 1)
                        {
                            panel_EGE.Visible = false;
                            flowLayoutPanel_diplom.Visible = false;
                            flowLayoutPanel_certificate.Visible = true;
                        }
                        else if (reader.GetInt32(0) == 2 || reader.GetInt32(0) == 3)
                        {
                            select_predmet();
                            panel_EGE.Visible = true;
                            flowLayoutPanel_diplom.Visible = false;
                            flowLayoutPanel_certificate.Visible = false;
                        }
                        else if (reader.GetInt32(0) == 4)
                        {
                            panel_EGE.Visible = false;
                            flowLayoutPanel_diplom.Visible = true;
                            flowLayoutPanel_certificate.Visible = false;
                        }
                    }
                }
            }
        }//Показывает нужную панель
        private void select_predmet()
        {
            comboBox_predmet.Items.Clear();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT title FROM subject where title NOT IN ('Диплом','Аттестат')";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox_predmet.Items.Add(reader.GetString(0));
                        }

                    }
                }
            }
        }//Заполняет предметы для Егэ
        private void select_datagrid()
        {
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Баллы", typeof(double));
        }
        private void Check_not_null()
        {
            if (textBox_second_name.Text.ToString() == "")
            {
                MessageBox.Show("Заполните Фамилию");
            }
            if (textBox_first_name.Text.ToString() == "")
            {
                MessageBox.Show("Заполните Имя");
            }
            if (textBox_passport.Text.ToString() == "")
            {
                MessageBox.Show("Заполните пасспортные данные");
            }
            if(textBox_email.Text.ToString() == "")
            {
                MessageBox.Show("Заполните почту");
            }
            if(textBox_snils.Text.ToString() == "")
            {
                MessageBox.Show("Заполните снилс");
            }
            if(textBox_phone.Text.ToString() == "")
            {
                MessageBox.Show("Заполните телефон");
            }
            if(textBox_previous_institution.Text.ToString()=="")
            {
                MessageBox.Show("Заолните ранее оконченное учебное заведение");
            }
            if(textBox_login.Text.ToString() == "")
            {
                MessageBox.Show("Заполните логин");
            }
            if (textBox_password.Text.ToString() == "")
            {
                MessageBox.Show("Заполните пароль");
            }
            if (textBox_parent_second_name.Text.ToString() == "")
            {
                MessageBox.Show("Заполните Фамилию родителя (законного представителя)");
            }
            if (textBox_parent_first_name.Text.ToString() == "")
            {
                MessageBox.Show("Заполните Имя родителя (законного представителя)");
            }
            if (path == null)
            {
                MessageBox.Show("Загрузите сканы документов");
            }
        }//Проверка всего заполненного
        private void Reg_user()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Insert into users(id_role,login,password) values (1,'"+textBox_login.Text.ToString()+"','"+textBox_password.Text.ToString()+"')";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id FROM users where login = '"+ textBox_login.Text.ToString() + "'";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_user = reader.GetInt32(0);
                        }

                    }
                }
                connection.Close();
            }
        }//регестрирует пользователя в бд
        private void Insert_application_subject (int id_application, int id_subject, double point)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Insert into application_subject(id_application, id_subject, points) values (" + id_application + ","+id_subject+","+point+")";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        private void Insert_application()
        {
            int id_application = 0;
            int id_direction = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Insert into application(id_level_education, id_status, first_name, second_name, surname, passport, snils, email, phone, " +
                    "parent_first_name, parent_second_name, parent_surname, previous_institution, document, start_date, id_user) " +
                    "values ("+id_level_education+", 1, '"+textBox_first_name.Text.ToString()+"' , '"+textBox_second_name.Text.ToString()+"' , " +
                    "'"+textBox_surname.Text.ToString()+"' , '"+textBox_passport.Text.ToString()+"' , '"+textBox_snils.Text.ToString()+"' , '"+textBox_email.Text.ToString()+"' , " +
                    "'"+textBox_phone.Text.ToString()+"' , '"+textBox_parent_first_name.Text.ToString()+"' , '"+textBox_parent_second_name.Text.ToString()+"' , '"+textBox_parent_surname.Text.ToString()+"' , '"+textBox_previous_institution.Text.ToString()+"' , '"+path+"' , '"+ DateTime.Now + "', "+id_user+")";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    {
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id FROM application where id_user = "+id_user;
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_application = reader.GetInt32(0);
                        }

                    }
                }
            }
            foreach (object item in checkedListBox_direction.CheckedItems)
            {
                string checkedItem = item.ToString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT id FROM direction WHERE title = @Title";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Title", item.ToString());
                        id_direction = (int)command.ExecuteScalar();
                    }
                }
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Insert into application_direction(id_application, id_direction) values (" + id_application + ",@id_direction)";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_direction", id_direction);
                        command.ExecuteNonQuery();
                    }
                }
            }
            if (id_level_education == 1)
            {
                Insert_application_subject(id_application, 15, Convert.ToDouble(numericUpDown_certificate.Value));
            }
            if (id_level_education == 4)
            {
                Insert_application_subject(id_application, 16, Convert.ToDouble(numericUpDown_certificate.Value));
            }
            if (id_level_education == 2 || id_level_education == 3)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int id_subject = 0;
                    string title = (string)row["Название"];
                    double point = (double)row["Баллы"];
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT id FROM subject WHERE title = @Title";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Title", title.ToString());
                            id_subject = (int)command.ExecuteScalar();
                        }
                    }
                    Insert_application_subject(id_application, id_subject, point);
                }
            }
        }//Сохраняет заявку в бд
        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_level_education_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_checkedListBox_direction();
            visible_panel();
        }

        private void button_add_Click(object sender, EventArgs e)
        {

            // Добавляем строки в DataTable
            dataTable.Rows.Add(comboBox_predmet.SelectedItem.ToString(), numericUpDown_point.Value);

            // Привязываем DataTable к DataGridView
            dataGridView_EGE.DataSource = dataTable;
        }//Кнопка для добавления в датагрид элементов

        private void button_document_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }
        }//Кнопка для загрузки документов

        private void button_reg_Click(object sender, EventArgs e)
        {
            Check_not_null();
            Reg_user();
            Insert_application();
        }
    }
}
