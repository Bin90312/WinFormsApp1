using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsApp1.Data;

namespace WinFormsApp1
{
    public partial class FormEditEvaluation : Form
    {
        private readonly int _evalId;

        public FormEditEvaluation(int evalId)
        {
            InitializeComponent();
            _evalId = evalId;
            SetupEmployeeAutoComplete();
            LoadEvaluation();
        }

        // 1) Load nhân viên + chống null warning
        private void SetupEmployeeAutoComplete()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand("SELECT EmployeeID, FullName FROM Employees", conn);
            using var dr = cmd.ExecuteReader();

            DataTable dt = new();
            dt.Load(dr);

            cboEmployee.DataSource = dt;
            cboEmployee.DisplayMember = "FullName";
            cboEmployee.ValueMember = "EmployeeID";

            cboEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cboEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection source = new();

            foreach (DataRow row in dt.Rows)
            {
                if (row["FullName"] != DBNull.Value)
                {
                    string name = row["FullName"].ToString()!;

                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        source.Add(name);
                    }
                }
            }

            cboEmployee.AutoCompleteCustomSource = source;
        }

        // 2) Load dữ liệu đánh giá
        private void LoadEvaluation()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
                SELECT EmployeeID, EvalDate, Score, Comment
                FROM Evaluations
                WHERE EvalID = @id
            ", conn);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = _evalId;

            using var dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show("Không tìm thấy dữ liệu");
                DialogResult = DialogResult.Cancel;
                return;
            }

            cboEmployee.SelectedValue = Convert.ToInt32(dr["EmployeeID"]);
            dtpDate.Value = Convert.ToDateTime(dr["EvalDate"]);
            txtScore.Text = dr["Score"].ToString() ?? "";
            txtComment.Text = dr["Comment"].ToString() ?? "";
        }

        // 3) Nút LƯU
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData(out int score))
                return;

            int empId = GetEmployeeIdByName();
            if (empId == -1)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
                return;
            }

            using var conn = Database.GetConnection();
            conn.Open();

            using var cmd = new SqlCommand(@"
                UPDATE Evaluations SET
                    EmployeeID = @emp,
                    EvalDate   = @date,
                    Score      = @score,
                    Comment    = @comment
                WHERE EvalID = @id
            ", conn);

            cmd.Parameters.Add("@emp", SqlDbType.Int).Value = empId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = dtpDate.Value.Date;
            cmd.Parameters.Add("@score", SqlDbType.Int).Value = score;
            cmd.Parameters.Add("@comment", SqlDbType.NVarChar).Value = txtComment.Text.Trim();
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = _evalId;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Cập nhật thành công");
            DialogResult = DialogResult.OK;
        }

        // 4) Lấy ID theo tên - an toàn null
        private int GetEmployeeIdByName()
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
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

            object? result = cmd.ExecuteScalar();
            return (result == null || result == DBNull.Value) ? -1 : Convert.ToInt32(result);
        }

        // 5) Validate
        private bool ValidateData(out int score)
        {
            score = 0;

            if (string.IsNullOrWhiteSpace(cboEmployee.Text))
            {
                MessageBox.Show("Chưa nhập nhân viên");
                return false;
            }

            if (!int.TryParse(txtScore.Text, out score))
            {
                MessageBox.Show("Điểm phải là số");
                return false;
            }

            if (score < 0 || score > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10");
                return false;
            }

            return true;
        }
    }
}
