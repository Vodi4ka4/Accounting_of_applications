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
    public partial class Auto : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Accounting_of_applications";
        int id_role;
        int id;
        public Auto()
        {
            InitializeComponent();
        }
        private void Check_user()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id, id_role FROM users where login = '"+textBox_login.Text.ToString()+"'AND password = '"+textBox_password.Text.ToString()+"'";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            id_role = reader.GetInt32(1);
                        }

                    }
                }
            }
        }

        private void button_reg_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            reg.ShowDialog();
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            Check_user();
            if (id_role == 1)
            {
                Enrollee enrollee = new Enrollee(id);
                enrollee.ShowDialog();
            }
            if (id_role == 2)
            {
                Employer employer = new Employer(id);
                employer.ShowDialog();
            }
        }
    }
}
