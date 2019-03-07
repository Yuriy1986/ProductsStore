namespace ProductsStore.WinForms
{
    partial class ChangePassword
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
            this.ChangePass_Cancel = new System.Windows.Forms.Button();
            this.ChangePass_OK = new System.Windows.Forms.Button();
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OldPasswordBox = new System.Windows.Forms.TextBox();
            this.ChangePassword_Validation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ChangePass_Cancel
            // 
            this.ChangePass_Cancel.Location = new System.Drawing.Point(236, 277);
            this.ChangePass_Cancel.Name = "ChangePass_Cancel";
            this.ChangePass_Cancel.Size = new System.Drawing.Size(75, 23);
            this.ChangePass_Cancel.TabIndex = 10;
            this.ChangePass_Cancel.Text = "Cancel";
            this.ChangePass_Cancel.UseVisualStyleBackColor = true;
            this.ChangePass_Cancel.Click += new System.EventHandler(this.ChangePass_Cancel_Click);
            // 
            // ChangePass_OK
            // 
            this.ChangePass_OK.Location = new System.Drawing.Point(73, 277);
            this.ChangePass_OK.Name = "ChangePass_OK";
            this.ChangePass_OK.Size = new System.Drawing.Size(75, 23);
            this.ChangePass_OK.TabIndex = 9;
            this.ChangePass_OK.Text = "OK";
            this.ChangePass_OK.UseVisualStyleBackColor = true;
            this.ChangePass_OK.Click += new System.EventHandler(this.ChangePass_OK_Click);
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Location = new System.Drawing.Point(73, 177);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.PasswordChar = '*';
            this.NewPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.NewPasswordBox.TabIndex = 8;
            this.NewPasswordBox.TextChanged += new System.EventHandler(this.NewPasswordBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "New password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Old password";
            // 
            // OldPasswordBox
            // 
            this.OldPasswordBox.Location = new System.Drawing.Point(73, 72);
            this.OldPasswordBox.Name = "OldPasswordBox";
            this.OldPasswordBox.PasswordChar = '*';
            this.OldPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.OldPasswordBox.TabIndex = 13;
            this.OldPasswordBox.TextChanged += new System.EventHandler(this.OldPasswordBox_TextChanged);
            // 
            // ChangePassword_Validation
            // 
            this.ChangePassword_Validation.BackColor = System.Drawing.SystemColors.Control;
            this.ChangePassword_Validation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChangePassword_Validation.ForeColor = System.Drawing.Color.Red;
            this.ChangePassword_Validation.Location = new System.Drawing.Point(45, 203);
            this.ChangePassword_Validation.Multiline = true;
            this.ChangePassword_Validation.Name = "ChangePassword_Validation";
            this.ChangePassword_Validation.ReadOnly = true;
            this.ChangePassword_Validation.Size = new System.Drawing.Size(294, 68);
            this.ChangePassword_Validation.TabIndex = 14;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.ChangePassword_Validation);
            this.Controls.Add(this.OldPasswordBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChangePass_Cancel);
            this.Controls.Add(this.ChangePass_OK);
            this.Controls.Add(this.NewPasswordBox);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ChangePass_Cancel;
        private System.Windows.Forms.Button ChangePass_OK;
        private System.Windows.Forms.TextBox NewPasswordBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OldPasswordBox;
        private System.Windows.Forms.TextBox ChangePassword_Validation;
    }
}