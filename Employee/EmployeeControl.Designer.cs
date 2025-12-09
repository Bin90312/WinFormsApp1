namespace WinFormsApp1.Employee
{
    partial class EmployeeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvEmployees = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            cboSearchName = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(0, 128);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(942, 342);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(72, 67);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(235, 67);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(389, 67);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cboSearchName
            // 
            cboSearchName.FormattingEnabled = true;
            cboSearchName.Location = new Point(72, 13);
            cboSearchName.Name = "cboSearchName";
            cboSearchName.Size = new Size(342, 28);
            cboSearchName.TabIndex = 4;
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboSearchName);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvEmployees);
            Name = "EmployeeControl";
            Size = new Size(942, 469);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEmployees;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private ComboBox cboSearchName;
    }
}
