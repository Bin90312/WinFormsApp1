using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnEvaluation = new Button();
            btnEmployee = new Button();
            panelContent = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ButtonHighlight;
            panelMenu.Controls.Add(btnEvaluation);
            panelMenu.Controls.Add(btnEmployee);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 459);
            panelMenu.TabIndex = 1;
            // 
            // btnEvaluation
            // 
            btnEvaluation.Dock = DockStyle.Top;
            btnEvaluation.Location = new Point(0, 40);
            btnEvaluation.Name = "btnEvaluation";
            btnEvaluation.Size = new Size(200, 41);
            btnEvaluation.TabIndex = 0;
            btnEvaluation.Text = "ĐÁNH GIÁ";
            btnEvaluation.Click += btnEvaluation_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.Dock = DockStyle.Top;
            btnEmployee.Location = new Point(0, 0);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(200, 40);
            btnEmployee.TabIndex = 1;
            btnEmployee.Text = "NHÂN VIÊN";
            btnEmployee.Click += btnEmployee_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = SystemColors.ButtonHighlight;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(646, 459);
            panelContent.TabIndex = 0;
            panelContent.Paint += panelContent_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 459);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Name = "MainForm";
            Text = "QUẢN LÝ NHÂN VIÊN & ĐÁNH GIÁ";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnEmployee;
        private Button btnEvaluation;
        private Panel panelContent;
    }
}
