namespace WinFormsApp1
{
    partial class FormEditEvaluation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpDate = new DateTimePicker();
            txtScore = new TextBox();
            txtComment = new TextBox();
            btnSave = new Button();
            cboEmployee = new ComboBox();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(212, 24);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(196, 27);
            dtpDate.TabIndex = 1;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(50, 82);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(125, 27);
            txtScore.TabIndex = 2;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(245, 82);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(125, 27);
            txtComment.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(266, 264);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // cboEmployee
            // 
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(37, 24);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(151, 28);
            cboEmployee.TabIndex = 6;
            // 
            // FormEditEvaluation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 354);
            Controls.Add(cboEmployee);
            Controls.Add(btnSave);
            Controls.Add(txtComment);
            Controls.Add(txtScore);
            Controls.Add(dtpDate);
            Name = "FormEditEvaluation";
            Text = "FormEditEvaluation";
            Click += btnSave_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtpDate;
        private TextBox txtScore;
        private TextBox txtComment;
        private Button btnSave;
        private ComboBox cboEmployee;
    }
}