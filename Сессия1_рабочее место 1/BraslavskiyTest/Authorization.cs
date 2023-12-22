using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BraslavskiyTest
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=192.168.57.3;Initial Catalog=Braslavskiy_agent;Persist Security Info=True;User ID=user;Password=12345";
            connection = new SqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            string query = "SELECT COUNT(*) FROM Agents WHERE login=@login AND password=@password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            connection.Open();
            int count = (int)command.ExecuteScalar();
            connection.Close();
            if (count > 0)
            {
                MessageBox.Show("Успешная авторизация!");
                AdminPanel mainForm = new AdminPanel();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
