namespace WinFormsApp1
{
    partial class FormAddEvaluation
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
            cboEmployee = new ComboBox();
            dtpDate = new DateTimePicker();
            txtScore = new TextBox();
            txtComment = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // cboEmployee
            // 
            cboEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(23, 21);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(151, 28);
            cboEmployee.TabIndex = 0;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(204, 19);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(199, 27);
            dtpDate.TabIndex = 1;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(23, 85);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(157, 27);
            txtScore.TabIndex = 2;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(256, 85);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(125, 34);
            txtComment.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(309, 208);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button1_Click;
            // 
            // FormAddEvaluation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 343);
            Controls.Add(btnSave);
            Controls.Add(txtComment);
            Controls.Add(txtScore);
            Controls.Add(dtpDate);
            Controls.Add(cboEmployee);
            Name = "FormAddEvaluation";
            Text = "FormAddEvaluation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboEmployee;
        private DateTimePicker dtpDate;
        private TextBox txtScore;
        private TextBox txtComment;
        private Button btnSave;
    }
}