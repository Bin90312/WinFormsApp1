namespace WinFormsApp1
{
    partial class FormEmployee
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
            dtpBirthDate = new DateTimePicker();
            txtSalary = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtFullName = new TextBox();
            SuspendLayout();
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(268, 26);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(205, 27);
            dtpBirthDate.TabIndex = 1;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(512, 26);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(125, 27);
            txtSalary.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(141, 189);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(471, 189);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button1_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(50, 26);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(170, 27);
            txtFullName.TabIndex = 5;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 328);
            Controls.Add(txtFullName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtSalary);
            Controls.Add(dtpBirthDate);
            Name = "FormEmployee";
            Text = "FormEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtpBirthDate;
        private TextBox txtSalary;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtFullName;
    }
}