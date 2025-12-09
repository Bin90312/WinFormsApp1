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

            // GẮN SỰ KIỆN QUAN TRỌNG
            dgvEmployees.CellClick += dgvEmployees_CellClick;

            LoadEmployees();
            SetupSearchComboBox();
        }

        // ===================== LOAD NHÂN VIÊN =====================

        private void LoadEmployees()
        {
            string sql = "SELECT EmployeeID, FullName, BirthDate, Salary FROM Employees";

            using SqlConnection conn = Database.GetConnection();
            using SqlDataAdapter da = new(sql, conn);

            employeeTable = new DataTable();
            da.Fill(employeeTable);

            dgvEmployees.DataSource = employeeTable;
            selectedEmployeeId = -1; // reset sau mỗi lần load
        }

        // ===================== COMBOBOX TÌM KIẾM =====================

        private void SetupSearchComboBox()
        {
            cboSearchName.DropDownStyle = ComboBoxStyle.DropDown;
            cboSearchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSearchName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection source = new();

            foreach (DataRow row in employeeTable.Rows)
            {
                if (row["FullName"] != DBNull.Value)
                {
                    string name = row["FullName"].ToString()!;
                    if (!string.IsNullOrWhiteSpace(name))
                        source.Add(name);
                }
            }

            cboSearchName.AutoCompleteCustomSource = source;

            // tránh gắn trùng event
            cboSearchName.TextChanged -= cboSearchName_TextChanged;
            cboSearchName.TextChanged += cboSearchName_TextChanged;
        }

        // ===================== LỌC DỮ LIỆU =====================

        private void cboSearchName_TextChanged(object? sender, EventArgs e)
        {
            string keyword = cboSearchName.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(keyword))
            {
                dgvEmployees.DataSource = employeeTable;
                return;
            }

            DataView dv = new(employeeTable);
            dv.RowFilter = $"FullName LIKE '%{keyword}%'";
            dgvEmployees.DataSource = dv;

            // reset lựa chọn
            selectedEmployeeId = -1;
        }

        // ===================== BẮT SỰ KIỆN CLICK DÒNG =====================

        private void dgvEmployees_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEmployees.Rows[e.RowIndex];

            if (row.Cells["EmployeeID"].Value is null ||
                row.Cells["EmployeeID"].Value == DBNull.Value)
            {
                selectedEmployeeId = -1;
                return;
            }

            selectedEmployeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
        }

        // ===================== THÊM =====================

        private void button1_Click(object sender, EventArgs e)
        {
            selectedEmployeeId = -1;

            using var f = new FormEmployee(); // form dùng chung
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
                SetupSearchComboBox();
            }
        }

        // ===================== SỬA =====================

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa");
                return;
            }

            using var f = new FormEmployee(selectedEmployeeId);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
                SetupSearchComboBox();
            }
        }

        // ===================== XÓA =====================

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(
                "DELETE FROM Employees WHERE EmployeeID=@id", conn);

            cmd.Parameters.AddWithValue("@id", selectedEmployeeId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Đã xóa thành công");

            selectedEmployeeId = -1;
            LoadEmployees();
            SetupSearchComboBox();
        }

        // ✨ Tránh lỗi Designer
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
