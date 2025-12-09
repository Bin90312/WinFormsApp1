using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Data;

namespace WinFormsApp1
{
    public partial class FormEmployee : Form
    {
        private int employeeId = -1;
        private bool isEditMode = false;

        // ================== CONSTRUCTOR ADD ==================
        public FormEmployee()
        {
            InitializeComponent();
            this.Text = "Thêm nhân viên";
        }

        // ================== CONSTRUCTOR EDIT ==================
        public FormEmployee(int id)
        {
            InitializeComponent();
            employeeId = id;
            isEditMode = true;
            this.Text = "Cập nhật nhân viên";
            LoadEmployee();
        }

        // ================== LOAD DATA KHI SỬA ==================
        private void LoadEmployee()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(
                "SELECT FullName, BirthDate, Salary FROM Employees WHERE EmployeeID=@id", conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtFullName.Text = reader["FullName"].ToString();
                dtpBirthDate.Value = Convert.ToDateTime(reader["BirthDate"]);
                txtSalary.Text = reader["Salary"].ToString();
            }
        }

        // ================== NÚT LƯU ==================
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string salaryText = txtSalary.Text.Trim();
            DateTime birthDate = dtpBirthDate.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên");
                return;
            }

            if (!decimal.TryParse(salaryText, out decimal salary))
            {
                MessageBox.Show("Lương không hợp lệ");
                return;
            }

            using var conn = Database.GetConnection();
            conn.Open();

            SqlCommand cmd;

            if (isEditMode)
            {
                // -------- UPDATE --------
                cmd = new SqlCommand(@"
                    UPDATE Employees
                    SET FullName=@name, BirthDate=@birth, Salary=@salary
                    WHERE EmployeeID=@id", conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = employeeId;
            }
            else
            {
                // -------- INSERT --------
                cmd = new SqlCommand(@"
                    INSERT INTO Employees(FullName, BirthDate, Salary)
                    VALUES(@name, @birth, @salary)", conn);
            }

            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@birth", SqlDbType.Date).Value = birthDate;
            cmd.Parameters.Add("@salary", SqlDbType.Decimal).Value = salary;

            cmd.ExecuteNonQuery();

            MessageBox.Show(isEditMode ? "Cập nhật thành công" : "Thêm thành công");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
