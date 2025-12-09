using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsApp1.Data;

namespace WinFormsApp1.Evaluation
{
    public partial class EvaluationControl : UserControl
    {
        int selectedEvalId = -1;

        public EvaluationControl()
        {
            InitializeComponent();
            LoadEmployees();
            LoadEvaluations();
        }

        // Load nhân viên
        void LoadEmployees()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(
                "SELECT EmployeeID, FullName FROM Employees",
                conn
            );

            using var dr = cmd.ExecuteReader();

            DataTable dt = new();
            dt.Load(dr);

            // Gán data cho ComboBox
            cboEmployee.DataSource = dt;
            cboEmployee.DisplayMember = "FullName";
            cboEmployee.ValueMember = "EmployeeID";

            // Cấu hình auto complete
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cboEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection source = new();

            foreach (DataRow row in dt.Rows)
            {
                if (row["FullName"] != DBNull.Value)
                {
                    string name = row["FullName"]?.ToString() ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        source.Add(name);
                    }
                }
            }

            cboEmployee.AutoCompleteCustomSource = source;
        }


        // Load đánh giá
        void LoadEvaluations()
        {
            cboEmployee.SelectedIndexChanged -= cboEmployee_SelectedIndexChanged;
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
            using var conn = Database.GetConnection();
            SqlDataAdapter da = new("""
                SELECT EvalID, EmployeeID, EvalDate, Score, Comment
                FROM Evaluations
            """, conn);

            DataTable dt = new();
            da.Fill(dt);
            dgvEvaluations.DataSource = dt;
        }

        // THÊM
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new FormAddEvaluation();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadEvaluations();
            }
        }



        // Click chọn dòng
        private void dgvEvaluations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEvaluations.Rows[e.RowIndex];

            if (row.Cells["EvalID"].Value == null) return;

            selectedEvalId = Convert.ToInt32(row.Cells["EvalID"].Value);

            cboEmployee.SelectedValue = row.Cells["EmployeeID"].Value!;
            dtpDate.Value = row.Cells["EvalDate"].Value is DateTime d ? d : DateTime.Now;
            txtScore.Text = row.Cells["Score"].Value?.ToString() ?? "";
            txtComment.Text = row.Cells["Comment"].Value?.ToString() ?? "";
        }

        // SỬA
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEvalId == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa");
                return;
            }

            using var f = new FormEditEvaluation(selectedEvalId);
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadEvaluations();
            }
        }



        // XÓA
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEvalId == -1)
            {
                MessageBox.Show("Chưa chọn dòng để xóa");
                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo
            ) != DialogResult.Yes)
                return;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM Evaluations WHERE EvalID=@id", conn);

            cmd.Parameters.AddWithValue("@id", selectedEvalId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Xóa thành công");

            selectedEvalId = -1;
            LoadEvaluations();
        }

        private void dgvEvaluations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void EvaluationControl_Load(object sender, EventArgs e)
        {

        }

        private void cboEmployee_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboEmployee.SelectedValue == null)
                return;

            int empId;
            if (!int.TryParse(cboEmployee.SelectedValue.ToString(), out empId))
                return;

            LoadEvaluationByEmployee(empId);
        }

        private void LoadEvaluationByEmployee(int empId)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
        SELECT TOP 1
            EvalID,
            EvalDate,
            Score,
            Comment
        FROM Evaluations
        WHERE EmployeeID = @empId
        ORDER BY EvalDate DESC
    ", conn);

            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = empId;

            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                selectedEvalId = Convert.ToInt32(dr["EvalID"]);
                dtpDate.Value = Convert.ToDateTime(dr["EvalDate"]);
                txtScore.Text = dr["Score"].ToString() ?? "";
                txtComment.Text = dr["Comment"]?.ToString() ?? "";
            }
            else
            {
                // Nếu nhân viên chưa có đánh giá nào
                selectedEvalId = -1;
                txtScore.Text = "";
                txtComment.Text = "";
                dtpDate.Value = DateTime.Now;
            }
        }
        private void txtComment_TextChanged(object sender, EventArgs e)
        {

        }

        int GetEmployeeIdByName()
        {
            string name = cboEmployee.Text?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(name))
                return -1;

            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(
                "SELECT EmployeeID FROM Employees WHERE FullName = @name",
                conn
            );
            cmd.Parameters.AddWithValue("@name", name);

            object? result = cmd.ExecuteScalar();
            return (result == null || result == DBNull.Value)
                ? -1
                : Convert.ToInt32(result);
        }

    }
}
