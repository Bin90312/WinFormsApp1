using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsApp1.Data;

namespace WinFormsApp1
{
    public partial class FormAddEvaluation : Form
    {
        public FormAddEvaluation()
        {
            InitializeComponent();
            SetupEmployeeComboBox();
        }

        // 1. Load danh sách nhân viên + bật autocomplete
        private void SetupEmployeeComboBox()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            SqlCommand cmd = new("SELECT EmployeeID, FullName FROM Employees", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new();
            dt.Load(dr);

            // Load dữ liệu vào ComboBox
            cboEmployee.DataSource = dt;
            cboEmployee.DisplayMember = "FullName";
            cboEmployee.ValueMember = "EmployeeID";

            // Bật chế độ gợi ý khi gõ
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDown;
            cboEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection source = new();
            foreach (DataRow row in dt.Rows)
            {
                source.Add(row["FullName"].ToString());
            }
            cboEmployee.AutoCompleteCustomSource = source;
        }

        // 2. Nút Lưu
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboEmployee.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên");
                return;
            }

            if (!int.TryParse(txtScore.Text, out int score))
            {
                MessageBox.Show("Điểm phải là số");
                return;
            }

            if (score < 0 || score > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10");
                return;
            }

            using var conn = Database.GetConnection();
            conn.Open();

            // Tìm EmployeeID theo tên
            SqlCommand cmdGetId = new(
                "SELECT EmployeeID FROM Employees WHERE FullName = @name",
                conn
            );
            cmdGetId.Parameters.AddWithValue("@name", cboEmployee.Text.Trim());

            object result = cmdGetId.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
                return;
            }

            int empId = (int)result;

            // Thêm đánh giá
            SqlCommand cmd = new(@"
                INSERT INTO Evaluations(EmployeeID, EvalDate, Score, Comment)
                VALUES (@emp, @date, @score, @comment)
            ", conn);

            cmd.Parameters.Add("@emp", SqlDbType.Int).Value = empId;
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = dtpDate.Value.Date;
            cmd.Parameters.Add("@score", SqlDbType.Int).Value = score;
            cmd.Parameters.Add("@comment", SqlDbType.NVarChar, 255).Value =
                txtComment.Text.Trim();

            cmd.ExecuteNonQuery();

            MessageBox.Show("Thêm đánh giá thành công");
            this.DialogResult = DialogResult.OK;
        }
    }
}
