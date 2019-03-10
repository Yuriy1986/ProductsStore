namespace ProductsStore.WinForms
{
    partial class CreateShipment
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
            this.CompanyBox = new System.Windows.Forms.TextBox();
            this.Company_Validation = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CityBox = new System.Windows.Forms.TextBox();
            this.City_Validation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CountryBox = new System.Windows.Forms.TextBox();
            this.Country_Validation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.QuantityBox = new System.Windows.Forms.TextBox();
            this.Quantity_Validation = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SumBox = new System.Windows.Forms.TextBox();
            this.Sum_Validation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CreateShipment_Validation = new System.Windows.Forms.TextBox();
            this.CreateShipment_OK = new System.Windows.Forms.Button();
            this.CreateShipment_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CompanyBox
            // 
            this.CompanyBox.Location = new System.Drawing.Point(93, 37);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(200, 20);
            this.CompanyBox.TabIndex = 4;
            this.CompanyBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CompanyBox_KeyPress);
            this.CompanyBox.Validating += new System.ComponentModel.CancelEventHandler(this.CompanyBox_Validating);
            // 
            // Company_Validation
            // 
            this.Company_Validation.AutoSize = true;
            this.Company_Validation.ForeColor = System.Drawing.Color.Red;
            this.Company_Validation.Location = new System.Drawing.Point(90, 60);
            this.Company_Validation.Name = "Company_Validation";
            this.Company_Validation.Size = new System.Drawing.Size(0, 13);
            this.Company_Validation.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Company";
            // 
            // CityBox
            // 
            this.CityBox.Location = new System.Drawing.Point(93, 97);
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(200, 20);
            this.CityBox.TabIndex = 7;
            this.CityBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CityBox_KeyPress);
            this.CityBox.Validating += new System.ComponentModel.CancelEventHandler(this.CityBox_Validating);
            // 
            // City_Validation
            // 
            this.City_Validation.AutoSize = true;
            this.City_Validation.ForeColor = System.Drawing.Color.Red;
            this.City_Validation.Location = new System.Drawing.Point(90, 120);
            this.City_Validation.Name = "City_Validation";
            this.City_Validation.Size = new System.Drawing.Size(0, 13);
            this.City_Validation.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "City";
            // 
            // CountryBox
            // 
            this.CountryBox.Location = new System.Drawing.Point(93, 157);
            this.CountryBox.Name = "CountryBox";
            this.CountryBox.Size = new System.Drawing.Size(200, 20);
            this.CountryBox.TabIndex = 10;
            this.CountryBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CountryBox_KeyPress);
            this.CountryBox.Validating += new System.ComponentModel.CancelEventHandler(this.CountryBox_Validating);
            // 
            // Country_Validation
            // 
            this.Country_Validation.AutoSize = true;
            this.Country_Validation.ForeColor = System.Drawing.Color.Red;
            this.Country_Validation.Location = new System.Drawing.Point(90, 180);
            this.Country_Validation.Name = "Country_Validation";
            this.Country_Validation.Size = new System.Drawing.Size(0, 13);
            this.Country_Validation.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Country";
            // 
            // QuantityBox
            // 
            this.QuantityBox.Location = new System.Drawing.Point(93, 217);
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(200, 20);
            this.QuantityBox.TabIndex = 13;
            this.QuantityBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QuantityBox_KeyPress);
            this.QuantityBox.Validating += new System.ComponentModel.CancelEventHandler(this.QuantityBox_Validating);
            // 
            // Quantity_Validation
            // 
            this.Quantity_Validation.AutoSize = true;
            this.Quantity_Validation.ForeColor = System.Drawing.Color.Red;
            this.Quantity_Validation.Location = new System.Drawing.Point(90, 240);
            this.Quantity_Validation.Name = "Quantity_Validation";
            this.Quantity_Validation.Size = new System.Drawing.Size(0, 13);
            this.Quantity_Validation.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Quantity";
            // 
            // SumBox
            // 
            this.SumBox.Location = new System.Drawing.Point(93, 277);
            this.SumBox.Name = "SumBox";
            this.SumBox.Size = new System.Drawing.Size(200, 20);
            this.SumBox.TabIndex = 16;
            this.SumBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SumBox_KeyPress);
            this.SumBox.Validating += new System.ComponentModel.CancelEventHandler(this.SumBox_Validating);
            // 
            // Sum_Validation
            // 
            this.Sum_Validation.AutoSize = true;
            this.Sum_Validation.ForeColor = System.Drawing.Color.Red;
            this.Sum_Validation.Location = new System.Drawing.Point(90, 300);
            this.Sum_Validation.Name = "Sum_Validation";
            this.Sum_Validation.Size = new System.Drawing.Size(0, 13);
            this.Sum_Validation.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Sum";
            // 
            // CreateShipment_Validation
            // 
            this.CreateShipment_Validation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CreateShipment_Validation.ForeColor = System.Drawing.Color.Red;
            this.CreateShipment_Validation.Location = new System.Drawing.Point(26, 328);
            this.CreateShipment_Validation.Multiline = true;
            this.CreateShipment_Validation.Name = "CreateShipment_Validation";
            this.CreateShipment_Validation.ReadOnly = true;
            this.CreateShipment_Validation.Size = new System.Drawing.Size(329, 72);
            this.CreateShipment_Validation.TabIndex = 18;
            this.CreateShipment_Validation.TabStop = false;
            // 
            // CreateShipment_OK
            // 
            this.CreateShipment_OK.Location = new System.Drawing.Point(78, 426);
            this.CreateShipment_OK.Name = "CreateShipment_OK";
            this.CreateShipment_OK.Size = new System.Drawing.Size(75, 23);
            this.CreateShipment_OK.TabIndex = 19;
            this.CreateShipment_OK.Text = "OK";
            this.CreateShipment_OK.UseVisualStyleBackColor = true;
            this.CreateShipment_OK.Click += new System.EventHandler(this.CreateShipment_OK_Click);
            // 
            // CreateShipment_Cancel
            // 
            this.CreateShipment_Cancel.Location = new System.Drawing.Point(234, 426);
            this.CreateShipment_Cancel.Name = "CreateShipment_Cancel";
            this.CreateShipment_Cancel.Size = new System.Drawing.Size(75, 23);
            this.CreateShipment_Cancel.TabIndex = 20;
            this.CreateShipment_Cancel.Text = "Cancel";
            this.CreateShipment_Cancel.UseVisualStyleBackColor = true;
            this.CreateShipment_Cancel.Click += new System.EventHandler(this.CreateShipment_Cancel_Click);
            // 
            // CreateShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.ControlBox = false;
            this.Controls.Add(this.CreateShipment_Cancel);
            this.Controls.Add(this.CreateShipment_OK);
            this.Controls.Add(this.CreateShipment_Validation);
            this.Controls.Add(this.SumBox);
            this.Controls.Add(this.Sum_Validation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.QuantityBox);
            this.Controls.Add(this.Quantity_Validation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CountryBox);
            this.Controls.Add(this.Country_Validation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CityBox);
            this.Controls.Add(this.City_Validation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.Company_Validation);
            this.Controls.Add(this.label9);
            this.Name = "CreateShipment";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateShipment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CompanyBox;
        private System.Windows.Forms.Label Company_Validation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CityBox;
        private System.Windows.Forms.Label City_Validation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CountryBox;
        private System.Windows.Forms.Label Country_Validation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox QuantityBox;
        private System.Windows.Forms.Label Quantity_Validation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SumBox;
        private System.Windows.Forms.Label Sum_Validation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CreateShipment_Validation;
        private System.Windows.Forms.Button CreateShipment_OK;
        private System.Windows.Forms.Button CreateShipment_Cancel;
    }
}