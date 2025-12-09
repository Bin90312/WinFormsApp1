namespace WinFormsApp1.Evaluation
{
    partial class EvaluationControl
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
            cboEmployee = new ComboBox();
            dtpDate = new DateTimePicker();
            button1 = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvEvaluations = new DataGridView();
            txtComment = new TextBox();
            txtScore = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvEvaluations).BeginInit();
            SuspendLayout();
            // 
            // cboEmployee
            // 
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(65, 69);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(151, 28);
            cboEmployee.TabIndex = 0;
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(416, 19);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(218, 27);
            dtpDate.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(828, 113);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(84, 109);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(273, 109);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(448, 109);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvEvaluations
            // 
            dgvEvaluations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvaluations.Dock = DockStyle.Bottom;
            dgvEvaluations.Location = new Point(0, 162);
            dgvEvaluations.Name = "dgvEvaluations";
            dgvEvaluations.RowHeadersWidth = 51;
            dgvEvaluations.Size = new Size(746, 282);
            dgvEvaluations.TabIndex = 9;
            dgvEvaluations.CellClick += dgvEvaluations_CellClick;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(273, 69);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(125, 34);
            txtComment.TabIndex = 5;
            txtComment.TextChanged += txtComment_TextChanged;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(469, 70);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(125, 27);
            txtScore.TabIndex = 2;
            txtScore.TextChanged += txtScore_TextChanged;
            // 
            // EvaluationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvEvaluations);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtComment);
            Controls.Add(btnAdd);
            Controls.Add(button1);
            Controls.Add(txtScore);
            Controls.Add(dtpDate);
            Controls.Add(cboEmployee);
            Name = "EvaluationControl";
            Size = new Size(746, 444);
            Load += EvaluationControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvaluations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboEmployee;
        private DateTimePicker dtpDate;
        private Button button1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvEvaluations;
        private TextBox txtComment;
        private TextBox txtScore;
    }
}
