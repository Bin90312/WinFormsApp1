using System;
using System.Windows.Forms;

// ⚠️ ĐỔI namespace này nếu tên thư mục của bạn khác
using WinFormsApp1.Employee;
using WinFormsApp1.Evaluation;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Hiển thị UserControl vào panelContent
        private void ShowControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        // Button NHÂN VIÊN
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ShowControl(new EmployeeControl());
        }

        // Button ĐÁNH GIÁ
        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            ShowControl(new EvaluationControl());
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
