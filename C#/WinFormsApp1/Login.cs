using System;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
namespace WinFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_login.Text.Length == 0)
            {
                MessageBox.Show("Укажите Ваш Логин", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_login.Focus();
                return;
            }

            if (textBox_password.Text.Length == 0)
            {
                MessageBox.Show("Укажите Ваш Пароль", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_password.Focus();
                return;
            }

            try
            {
                string connectionString = @"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных успешно установлено!");

                    // Вызов проверки логина и пароля
                    bool isAuthenticated = AuthenticateUser(connection, textBox_login.Text, textBox_password.Text);
                    if (isAuthenticated)
                    {
                        MessageBox.Show("Вход выполнен успешно!");
                        // Переход к следующей форме или выполнению других действий
                        RoleUser();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
            }
        }

        // Метод проверки логина и пароля
        private bool AuthenticateUser(SqlConnection con, string login, string password)
        {
            string query = "SELECT COUNT(1) FROM Applicant WHERE Sername = @login AND password = @password";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                int count = (int)cmd.ExecuteScalar();
                return count == 1;
            }
        }
        //DESKTOP - J3RB296\ONESQLEXPRESS
        enum Role { Failed, Admin, Company, Applicant}

        static Role GetRole(string loginUser, string passwordUser)
        {
            // MessageBox.Show($"Login: {loginUser}, Password: {passwordUser}");

            Role role = Role.Failed;
            // todo rename Data Source
            using (var sqlConnection = new SqlConnection(@"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                sqlConnection.Open();
                var command = new SqlCommand($"Select [code_access] From Applicant WHERE Sername=@loginUser AND password=@passwordUser ", sqlConnection);
                command.Parameters.AddWithValue("@loginUser", loginUser);
                command.Parameters.AddWithValue("@passwordUser", passwordUser);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        switch ((int)dataReader["code_access"])
                        {
                            case 1: role = Role.Admin; break;
                            case 2: role = Role.Company; break;
                            case 3: role = Role.Applicant; break;
                        }
                    }
                }
            }
            return role;
        }

        private void RoleUser()
        {
            Role role = GetRole(textBox_login.Text, textBox_password.Text);
            if (role == Role.Failed)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                if (role == Role.Admin)
                {
                    MessageBox.Show("Вы вошли под ролью администратора");
                    var formAdmin = new AdminForm();

                    formAdmin.ShowDialog();
                }
                else if (role == Role.Company)
                {
                    string applicant_code = null;
                    using (var sqlConnection = new SqlConnection(@"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                    {
                        sqlConnection.Open();
                        var command = new SqlCommand($"Select [Code_Applicant] From [Applicant] WHERE Sername=@loginUser and password=@passwordUser", sqlConnection);
                        command.Parameters.AddWithValue("@loginUser", textBox_login.Text);
                        command.Parameters.AddWithValue("@passwordUser", textBox_password.Text);
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                applicant_code = dataReader["Code_Applicant"].ToString();
                            }
                        }
                    }
                    MessageBox.Show("Вы вошли под ролью компания");

                    var formCompany = new CompanyForm(applicant_code);
                    formCompany.ShowDialog();
                }
                else if (role == Role.Applicant)
                {
                    // передача AgentID
                    string applicant_code = null;
                    using (var sqlConnection = new SqlConnection(@"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                    {
                        sqlConnection.Open();
                        var command = new SqlCommand($"Select [Code_Applicant] From [Applicant] WHERE Sername=@loginUser and password=@passwordUser", sqlConnection);
                        command.Parameters.AddWithValue("@loginUser", textBox_login.Text);
                        command.Parameters.AddWithValue("@passwordUser", textBox_password.Text);
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                applicant_code = dataReader["Code_Applicant"].ToString();
                            }
                        }
                    }

                    MessageBox.Show("Вы вошли под ролью соискателя");

                    var formAgent = new ApplicantForm(applicant_code);
                    formAgent.ShowDialog();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
