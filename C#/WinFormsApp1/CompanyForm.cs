using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class CompanyForm : Form
    {
        int id, idEmpp;
 //       string Emp_Phone, Address, Title, password;
        string connectionString = @"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string[] vacancy_array = { "Разработка ПО", "Бухгалтерия и аудит", "Инженерное проектирование", "Продажи и маркетинг", "Юридические услуги", "Дизайн интерьера", "Строительство", "Пищевое производство", "Уборка помещений", "Транспортные услуги", "Швейное производство", "Разнопрофильные услуги", "Производство мебели" };
        public CompanyForm(string code)
        {
            InitializeComponent();
            id = Convert.ToInt32(code);
            comboBox_vacancy.Items.AddRange(vacancy_array);
        }

        public void gridStart()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridStart();
            string query = "SELECT\r\n    TA.Type_Activity,\r\n    V.Salary\r\nFROM\r\n    dbo.Vacancy AS V\r\nJOIN\r\n    dbo.TypeActivity AS TA\r\n    ON V.Code_Activity = TA.Code_Activity  \r\nJOIN\r\n    dbo.Employer AS E\r\n    ON V.Code_Employer = E.Code_Employer  \r\nWHERE\r\n    E.Code_Applicant = @CodeApplicant;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodeApplicant", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void Mydata_Click(object sender, EventArgs e)
        {
            gridStart();
            string query = @"
            SELECT
                E.Emp_Phone,
                E.Address,
                E.Title,
                A.password
            FROM
                dbo.Employer AS E
            JOIN
                dbo.Applicant AS A
                ON E.Code_Applicant = A.Code_Applicant
            WHERE
                E.Code_Applicant = @CodeApplicant;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodeApplicant", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void button_data_change_Click(object sender, EventArgs e)
        {
            string Emp_Phone, Address, Title, password;
            bool allFieldsFilled = true;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[0].Value?.ToString()))
                {
                    allFieldsFilled = false;
                    break;
                }
            }
            if (!allFieldsFilled)
            {
                MessageBox.Show("Значения не введены (введены не все)!");
                return;
            }
            Emp_Phone = dataGridView1.Rows[0].Cells[0].Value.ToString();
            Address = dataGridView1.Rows[0].Cells[1].Value.ToString();
            Title = dataGridView1.Rows[0].Cells[2].Value.ToString();
            password = dataGridView1.Rows[0].Cells[3].Value.ToString();
            string query = @"
            UPDATE e
            SET
                e.Emp_Phone = @Emp_Phone,
                e.Address = @Address,
                e.Title = @Title
            FROM
                dbo.Employer AS e
            WHERE
                e.Code_Applicant = @CodeApplicant;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodeApplicant", id);
                    command.Parameters.AddWithValue("@Emp_Phone", Emp_Phone);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Title", Title);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добновить данные.");
                    }
                }
            }
            query = @"
            UPDATE dbo.Applicant
            SET
                Sername = @Title,
                password = @password
            WHERE
                Code_Applicant = @CodeApplicant;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodeApplicant", id);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@password", password);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно обновлены!");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добновить данные.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int vac = comboBox_vacancy.SelectedIndex;
            if (vac == -1) { MessageBox.Show("Выберите вид деятельности!"); }
            else if (int.TryParse(textBox1.Text, out int result))
            {
                string query = "SELECT Code_Employer FROM dbo.Employer WHERE Code_Applicant = @Code_Applicant";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("Code_Applicant", id);
                        object idEmp = command.ExecuteScalar();
                        idEmpp = Convert.ToInt32(idEmp);
                    }
                }
                query = "INSERT INTO dbo.[Vacancy] (Code_Employer, Code_Activity, Salary) VALUES (@Code_Employer, @Code_Activity, @Salary)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("Code_Employer", idEmpp);
                        command.Parameters.AddWithValue("@Code_Activity", vac + 1);
                        command.Parameters.AddWithValue("@Salary", result);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно добавлены!");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить данные.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите зарплату!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gridStart();
            string query = @"
            SELECT
                TA.Type_Activity,
                Va.Salary,
                Tr.Comission,
                Tr.Date_Transaction,
                Ap.Sername,
                Ap.Name,
                Ap.Qualification
            FROM
                dbo.Employer AS E
            JOIN
                dbo.Vacancy AS Va ON E.Code_Employer = Va.Code_Employer
            JOIN
                dbo.TypeActivity AS TA ON Va.Code_Activity = TA.Code_Activity
            JOIN
                dbo.Transactions AS Tr ON Va.Code_Vacancy = Tr.Code_Vacancy
            JOIN
                dbo.Applicant AS Ap ON Tr.Code_Applicant = Ap.Code_Applicant
            WHERE
                E.Code_Applicant = @CodeApplicant;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodeApplicant", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
    }
}
