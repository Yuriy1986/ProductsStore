namespace ProductsStore.WinForms
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.LoginsBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.Login_OK = new System.Windows.Forms.Button();
            this.Login_Cancel = new System.Windows.Forms.Button();
            this.Password_Validation = new System.Windows.Forms.Label();
            this.Login_Validation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // LoginsBox
            // 
            this.LoginsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoginsBox.FormattingEnabled = true;
            this.LoginsBox.Location = new System.Drawing.Point(73, 75);
            this.LoginsBox.Name = "LoginsBox";
            this.LoginsBox.Size = new System.Drawing.Size(121, 21);
            this.LoginsBox.TabIndex = 1;
            this.LoginsBox.SelectedIndexChanged += new System.EventHandler(this.LoginsBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(73, 177);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            // 
            // Login_OK
            // 
            this.Login_OK.Location = new System.Drawing.Point(73, 277);
            this.Login_OK.Name = "Login_OK";
            this.Login_OK.Size = new System.Drawing.Size(75, 23);
            this.Login_OK.TabIndex = 3;
            this.Login_OK.Text = "OK";
            this.Login_OK.UseVisualStyleBackColor = true;
            this.Login_OK.Click += new System.EventHandler(this.Login_OK_Click);
            // 
            // Login_Cancel
            // 
            this.Login_Cancel.Location = new System.Drawing.Point(236, 277);
            this.Login_Cancel.Name = "Login_Cancel";
            this.Login_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Login_Cancel.TabIndex = 4;
            this.Login_Cancel.Text = "Cancel";
            this.Login_Cancel.UseVisualStyleBackColor = true;
            this.Login_Cancel.Click += new System.EventHandler(this.Login_Cancel_Click);
            // 
            // Password_Validation
            // 
            this.Password_Validation.AutoSize = true;
            this.Password_Validation.ForeColor = System.Drawing.Color.Red;
            this.Password_Validation.Location = new System.Drawing.Point(70, 200);
            this.Password_Validation.Name = "Password_Validation";
            this.Password_Validation.Size = new System.Drawing.Size(0, 13);
            this.Password_Validation.TabIndex = 6;
            // 
            // Login_Validation
            // 
            this.Login_Validation.AutoSize = true;
            this.Login_Validation.ForeColor = System.Drawing.Color.Red;
            this.Login_Validation.Location = new System.Drawing.Point(73, 103);
            this.Login_Validation.Name = "Login_Validation";
            this.Login_Validation.Size = new System.Drawing.Size(0, 13);
            this.Login_Validation.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Login_Validation);
            this.Controls.Add(this.Password_Validation);
            this.Controls.Add(this.Login_Cancel);
            this.Controls.Add(this.Login_OK);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoginsBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox LoginsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button Login_OK;
        private System.Windows.Forms.Button Login_Cancel;
        private System.Windows.Forms.Label Password_Validation;
        private System.Windows.Forms.Label Login_Validation;
    }
}

