using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-J3RB296\ONESQLEXPRESS;Initial Catalog=Employment_Bureau;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        int Role;
        int operation_cod;
        String sername, password, phone, address;
        int Code_Applicant;
        bool allFieldsFilled = true;
        public AdminForm()
        {
            InitializeComponent();
            string[] Role_Array = { "Администратор", "Компания", "Соискатель" };
            comboBox_Role.Items.AddRange(Role_Array);
            dataGridView1.Columns.Add("Data", "Данные");
        }
        public int detectionRole()
        {
            int selectedIndex = comboBox_Role.SelectedIndex;
            return selectedIndex + 1;
        }

        private void SearchByCodeApplicant(int codeApplicant)
        {
            try
            {
                // Очистка DataGridView перед добавлением новых данных
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // SQL-запрос для поиска данных по Code_Applicant
                string query = @"
            SELECT a.Code_Applicant, a.Sername, a.password
            FROM dbo.Applicant AS a;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@CodeApplicant", codeApplicant);

                        // Использование SqlDataAdapter для заполнения DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Привязка данных к DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Проверка, найдены ли данные
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Данные по указанному Code_Applicant не найдены.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void button_AddUser_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("Data", "Данные");
            Role = detectionRole();
            if (Role == 0)
            {
                MessageBox.Show("Выберите роль!");
            }
            else
            {
                operation_cod = 1;
                dataGridView1.Rows.Clear();
                switch (Role)
                {
                    case 1:
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[0].HeaderCell.Value = "Логин:";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[1].HeaderCell.Value = "Пароль:";
                        break;
                    case 2:
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[0].HeaderCell.Value = "Название фирмы(логин):";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[1].HeaderCell.Value = "Пароль:";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[2].HeaderCell.Value = "Номер телефона:";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[3].HeaderCell.Value = "Адрес:";
                        break;
                    case 3:
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[0].HeaderCell.Value = "Фамилия(логин):";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[1].HeaderCell.Value = "Имя:";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[2].HeaderCell.Value = "Квалификация:";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[3].HeaderCell.Value = "Другие данные:";
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[4].HeaderCell.Value = "Пароль:";
                        break;
                }
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operation_cod)
                {
                    case 1:
                        switch (Role)
                        {
                            case 1:
                                // Проверка, что все данные введены
                                allFieldsFilled = true;
                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // -1, чтобы игнорировать пустую строку
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

                                // Получение значений из DataGridView
                                sername = dataGridView1.Rows[0].Cells[0].Value.ToString(); // Логин/Фамилия
                                password = dataGridView1.Rows[1].Cells[0].Value.ToString(); // Пароль

                                // Создание параметризованного SQL-запроса
                                string query = "INSERT INTO dbo.[Applicant] (Sername, password, code_access) VALUES (@Sername, @Password, @CodeAccess)";

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        // Добавление параметров
                                        command.Parameters.AddWithValue("@Sername", sername);
                                        command.Parameters.AddWithValue("@Password", password);
                                        command.Parameters.AddWithValue("@CodeAccess", Role);

                                        // Выполнение запроса
                                        int rowsAffected = command.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Данные успешно добавлены1!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не удалось добавить данные.");
                                        }
                                    }
                                    break;

                                }
                            case 2:
                                allFieldsFilled = true;
                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // -1, чтобы игнорировать пустую строку
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

                                // Получение значений из DataGridView
                                sername = dataGridView1.Rows[0].Cells[0].Value.ToString(); // Логин/Фамилия
                                password = dataGridView1.Rows[1].Cells[0].Value.ToString(); // Пароль
                                phone = dataGridView1.Rows[2].Cells[0].Value.ToString();
                                address = dataGridView1.Rows[3].Cells[0].Value.ToString();

                                // Создание параметризованного SQL-запроса
                                query = @"
            INSERT INTO dbo.[Applicant] (Sername, password, code_access) 
            VALUES (@Sername, @Password, @CodeAccess);
            SELECT SCOPE_IDENTITY();";

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        // Добавление параметров
                                        command.Parameters.AddWithValue("@Sername", sername);
                                        command.Parameters.AddWithValue("@Password", password);
                                        command.Parameters.AddWithValue("@CodeAccess", Role);
                                        Code_Applicant = Convert.ToInt32(command.ExecuteScalar());

                                        // Выполнение запроса
                                        int rowsAffected = command.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Данные успешно добавлены2!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не удалось добавить данные.");
                                        }
                                    }


                                    query = @"
                INSERT INTO dbo.[Employer] (Code_Applicant, Emp_Phone, Address, Title) 
                VALUES (@Code_Applicant, @phone, @address, @Sername);";
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@phone", phone);
                                        command.Parameters.AddWithValue("@address", address);
                                        command.Parameters.AddWithValue("@Code_Applicant", Code_Applicant);
                                        command.Parameters.AddWithValue("@Sername", sername);

                                        // Выполнение запроса
                                        int rowsAffected = command.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Данные успешно добавлены3!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не удалось добавить данные.");
                                        }

                                    }
                                    break;
                                }
                            case 3:
                                // Проверка, что все данные введены
                                allFieldsFilled = true;
                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // -1, чтобы игнорировать пустую строку
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

                                // Получение значений из DataGridView
                                sername = dataGridView1.Rows[0].Cells[0].Value.ToString(); // Логин/Фамилия
                                string name = dataGridView1.Rows[1].Cells[0].Value.ToString(); // Пароль
                                string qwalification = dataGridView1.Rows[2].Cells[0].Value.ToString();
                                string other_date = dataGridView1.Rows[3].Cells[0].Value.ToString();
                                password = dataGridView1.Rows[4].Cells[0].Value.ToString();

                                // Создание параметризованного SQL-запроса
                                query = "INSERT INTO dbo.[Applicant] (Sername, Name, Qualification, Other_Data, [code_access], [password]) VALUES (@Sername, @name, @qwalification, @other_date, @CodeAccess, @password)";

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        // Добавление параметров
                                        command.Parameters.AddWithValue("@Sername", sername);
                                        command.Parameters.AddWithValue("@name", name);
                                        command.Parameters.AddWithValue("@other_date", other_date);
                                        command.Parameters.AddWithValue("@qwalification", qwalification);
                                        command.Parameters.AddWithValue("@password", password);
                                        command.Parameters.AddWithValue("@CodeAccess", Role);

                                        // Выполнение запроса
                                        int rowsAffected = command.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show("Данные успешно добавлены1!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Не удалось добавить данные.");
                                        }
                                    }
                                    break;

                                }
                        }
                        break;
                    case 2:
                        try
                        {
                            // Проверка, что выбран пользователь для удаления
                            if (string.IsNullOrEmpty(dataGridView1.Rows[0].Cells[0].Value?.ToString()))
                            {
                                MessageBox.Show("Введите Code_Applicant для удаления!");
                                return;
                            }

                            // Получение Code_Applicant из DataGridView
                            int codeApplicant = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                            // SQL-запрос для удаления пользователя
                            string deleteQuery = @"
            DELETE FROM dbo.[Employer] WHERE Code_Applicant = @CodeApplicant;
            DELETE FROM dbo.[Applicant] WHERE Code_Applicant = @CodeApplicant;";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                                {
                                    // Добавление параметра
                                    command.Parameters.AddWithValue("@CodeApplicant", codeApplicant);

                                    // Выполнение запроса
                                    int rowsAffected = command.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Пользователь успешно удален!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пользователь с указанным Code_Applicant не найден.");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}");
                        }
                        break;
                    case 3:
                        SearchByCodeApplicant(3);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void button_DeleteUser_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("Data", "Данные");
            dataGridView1.Rows.Clear();
            operation_cod = 2;
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].HeaderCell.Value = "Введите Id:";
        }

        private void button_ChangeUser_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("Data", "Данные");
            dataGridView1.Rows.Clear();
            operation_cod = 3;
        }
    }
}

