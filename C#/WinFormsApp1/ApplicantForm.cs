using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace WinFormsApp1
{

    public partial class ApplicantForm : Form
    {
        int id;
        string connectionString = @"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ApplicantForm(string idd)
        {
            InitializeComponent();
            id = Convert.ToInt32(idd);
        }

        private static readonly Random random = new Random();

        public void gridStart()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void button_Date_User_Click(object sender, EventArgs e)
        {
            gridStart();
            string query = @"
            SELECT
                Sername,
                Name,
                Qualification, 
                Other_Data,
                password
            FROM
                dbo.Applicant
            WHERE
                Code_Applicant = @CodeApplicant;"
             ;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Sername, Name, Qualification, Other_Data, password;
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
            Sername = dataGridView1.Rows[0].Cells[0].Value.ToString();
            Name = dataGridView1.Rows[0].Cells[1].Value.ToString();
            Qualification = dataGridView1.Rows[0].Cells[2].Value.ToString();
            Other_Data = dataGridView1.Rows[0].Cells[3].Value.ToString();
            password = dataGridView1.Rows[0].Cells[4].Value.ToString();
            string query = @"
            UPDATE dbo.Applicant
            SET
                Sername = @Sername,
                Name = @Name,
                Qualification = @Qualification,
                Other_Data = @Other_Data,
                password = @password
            WHERE
                Code_Applicant = @CodeApplicant;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodeApplicant", id);
                    command.Parameters.AddWithValue("@Sername", Sername);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Qualification", Qualification);
                    command.Parameters.AddWithValue("@Other_Data", Other_Data);
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
            gridStart();
            string query = @"
            SELECT
                Va.Code_Vacancy,
                E.Emp_Phone,
                E.Address,
                E.Title,
                TA.Type_Activity,
                Va.Salary
            FROM
                dbo.Employer AS E
            JOIN
                dbo.Vacancy AS Va ON E.Code_Employer = Va.Code_Employer
            JOIN
                dbo.TypeActivity AS TA ON Va.Code_Activity = TA.Code_Activity;";
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

        private void button3_Click(object sender, EventArgs e)
        {

            int  max;
            double comission = Math.Round(random.NextDouble() * 0.20, 2);
            DateTime myDate = DateTime.Now;
            string formattedDate = myDate.ToString("yyyy-MM-dd");
            string query = "SELECT MAX(Code_Vacancy) FROM dbo.Vacancy";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand(query, connection))
                 {
                    object resultt = command.ExecuteScalar();
                    max = Convert.ToInt32(resultt);
                 }
            }
            if (int.TryParse(textBox1.Text, out int result))
            {
                if (result <= max)
                {
                    query = @"
        SELECT 1
        FROM dbo.Transactions
        WHERE Code_Vacancy = @CodeVacancy
          AND Code_Applicant = @CodeApplicant;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CodeVacancy", result);
                            command.Parameters.AddWithValue("@CodeApplicant", id);

                            // ExecuteScalar() возвращает первый столбец первой строки в результирующем наборе.
                            // Если строка не найдена, возвращает null.
                            object resulte = command.ExecuteScalar();
                            if (resulte == null)
                            {
                                query = "INSERT INTO dbo.[Transactions] (Code_Vacancy, Code_Applicant, Comission, Date_Transaction) VALUES (@Code_Vacancy, @Code_Applicant, @Comission, @Date_Transaction)";
                                using (SqlConnection connectionn = new SqlConnection(connectionString))
                                {
                                    connectionn.Open();

                                    using (SqlCommand commandd = new SqlCommand(query, connectionn))
                                    {
                                        commandd.Parameters.AddWithValue("@Code_Vacancy", result);
                                        commandd.Parameters.AddWithValue("@Code_Applicant", id);
                                        commandd.Parameters.AddWithValue("@Comission", comission);
                                        commandd.Parameters.AddWithValue("@Date_Transaction", formattedDate);
                                        int rowsAffected = commandd.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Сделка совершена!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не удалось совершить сделку.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Сделка уже существует!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не существующая вакансия");
                }
            }
                else
            {
                
                MessageBox.Show("Не удалось считать код вакансии данные.");
            }
        }
    }
}
