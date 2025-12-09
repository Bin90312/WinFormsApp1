using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsApp1.Data;

namespace WinFormsApp1.Employee
{
    public partial class EmployeeControl : UserControl
    {
        private int selectedEmployeeId = -1;
        private DataTable employeeTable = new();

        public EmployeeControl()
        {
            InitializeComponent();
            LoadEmployees();
            SetupSearchComboBox();
        }

        // ========================= LOAD DATA =========================

        private void LoadEmployees()
        {
            string sql = "SELECT EmployeeID, FullName, BirthDate, Salary FROM Employees";

            using SqlConnection conn = Database.GetConnection();
            using SqlDataAdapter da = new(sql, conn);

            employeeTable = new DataTable();
            da.Fill(employeeTable);

            dgvEmployees.DataSource = employeeTable;
        }

        // ========================= COMBOBOX AUTO COMPLETE =========================

        private void SetupSearchComboBox()
        {
            cboSearchName.DropDownStyle = ComboBoxStyle.DropDown;
            cboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSearchName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection source = new();

            if (employeeTable.Rows.Count > 0)
            {
                foreach (DataRow row in employeeTable.Rows)
                {
                    if (row["FullName"] != DBNull.Value)
                    {
                        string name = row["FullName"].ToString()!;
                        if (!string.IsNullOrWhiteSpace(name))
                            source.Add(name);
                    }
                }
            }

            cboSearchName.AutoCompleteCustomSource = source;

            // Tránh đăng ký event nhiều lần
            cboSearchName.TextChanged -= cboSearchName_TextChanged;
            cboSearchName.TextChanged += cboSearchName_TextChanged;
        }

        // ========================= FILTER SEARCH =========================

        private void cboSearchName_TextChanged(object? sender, EventArgs e)
        {
            string keyword = cboSearchName.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(keyword))
            {
                dgvEmployees.DataSource = employeeTable;
                return;
            }

            DataView dv = employeeTable.DefaultView;
            dv.RowFilter = $"FullName LIKE '%{keyword}%'";
            dgvEmployees.DataSource = dv;
        }

        // ========================= CHỌN DÒNG =========================

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEmployees.Rows[e.RowIndex];
            if (row.Cells["EmployeeID"].Value == null || row.Cells["EmployeeID"].Value == DBNull.Value) return;

            selectedEmployeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
        }

        // ========================= THÊM =========================

        private void button1_Click(object sender, EventArgs e)
        {
            using var f = new FormEmployee();   // ✅ dùng form chung
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
                SetupSearchComboBox();
            }
        }

        // ========================= SỬA =========================

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa");
                return;
            }

            using var f = new FormEmployee(selectedEmployeeId);   // ✅ form chung
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
                SetupSearchComboBox();
            }
        }

        // ========================= XÓA =========================

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(
                "DELETE FROM Employees WHERE EmployeeID=@id", conn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = selectedEmployeeId;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Đã xóa thành công");

            selectedEmployeeId = -1;
            LoadEmployees();
            SetupSearchComboBox();
        }

        // ========================= EMPTY EVENTS =========================

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
