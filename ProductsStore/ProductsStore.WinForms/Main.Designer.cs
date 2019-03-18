namespace ProductsStore.WinForms
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administeringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShipmentsGrid = new System.Windows.Forms.DataGridView();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.UpdateShipmentsButton = new System.Windows.Forms.Button();
            this.DeleteShipmentButton = new System.Windows.Forms.Button();
            this.CreateShipmentButton = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.CancelGroupButton = new System.Windows.Forms.Button();
            this.GroupButton = new System.Windows.Forms.Button();
            this.SurnameCheckBox = new System.Windows.Forms.CheckBox();
            this.CountryCheckBox = new System.Windows.Forms.CheckBox();
            this.CityCheckBox = new System.Windows.Forms.CheckBox();
            this.CompanyCheckBox = new System.Windows.Forms.CheckBox();
            this.DateCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentsGrid)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.administeringToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChangePasswordToolStripMenuItem_MouseUp);
            // 
            // administeringToolStripMenuItem
            // 
            this.administeringToolStripMenuItem.Name = "administeringToolStripMenuItem";
            this.administeringToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.administeringToolStripMenuItem.Text = "Administering";
            this.administeringToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AdministeringToolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExitToolStripMenuItem_MouseUp);
            // 
            // ShipmentsGrid
            // 
            this.ShipmentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipmentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipmentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ShipmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShipmentsGrid.Location = new System.Drawing.Point(0, 75);
            this.ShipmentsGrid.MultiSelect = false;
            this.ShipmentsGrid.Name = "ShipmentsGrid";
            this.ShipmentsGrid.ReadOnly = true;
            this.ShipmentsGrid.Size = new System.Drawing.Size(800, 325);
            this.ShipmentsGrid.TabIndex = 1;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.UpdateShipmentsButton);
            this.MainPanel.Controls.Add(this.DeleteShipmentButton);
            this.MainPanel.Controls.Add(this.CreateShipmentButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel.Location = new System.Drawing.Point(0, 400);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 50);
            this.MainPanel.TabIndex = 2;
            // 
            // UpdateShipmentsButton
            // 
            this.UpdateShipmentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.UpdateShipmentsButton.Location = new System.Drawing.Point(340, 15);
            this.UpdateShipmentsButton.Name = "UpdateShipmentsButton";
            this.UpdateShipmentsButton.Size = new System.Drawing.Size(120, 23);
            this.UpdateShipmentsButton.TabIndex = 2;
            this.UpdateShipmentsButton.Text = "Update shipments";
            this.UpdateShipmentsButton.UseVisualStyleBackColor = true;
            this.UpdateShipmentsButton.Click += new System.EventHandler(this.UpdateShipments_Click);
            // 
            // DeleteShipmentButton
            // 
            this.DeleteShipmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteShipmentButton.Location = new System.Drawing.Point(480, 15);
            this.DeleteShipmentButton.Name = "DeleteShipmentButton";
            this.DeleteShipmentButton.Size = new System.Drawing.Size(120, 23);
            this.DeleteShipmentButton.TabIndex = 1;
            this.DeleteShipmentButton.Text = "Delete shipment";
            this.DeleteShipmentButton.UseVisualStyleBackColor = true;
            this.DeleteShipmentButton.Click += new System.EventHandler(this.DeleteShipmentButton_Click);
            // 
            // CreateShipmentButton
            // 
            this.CreateShipmentButton.Location = new System.Drawing.Point(200, 15);
            this.CreateShipmentButton.Name = "CreateShipmentButton";
            this.CreateShipmentButton.Size = new System.Drawing.Size(120, 23);
            this.CreateShipmentButton.TabIndex = 0;
            this.CreateShipmentButton.Text = "Create shipment";
            this.CreateShipmentButton.UseVisualStyleBackColor = true;
            this.CreateShipmentButton.Click += new System.EventHandler(this.CreateShipmentButton_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.CancelGroupButton);
            this.GroupBox.Controls.Add(this.GroupButton);
            this.GroupBox.Controls.Add(this.SurnameCheckBox);
            this.GroupBox.Controls.Add(this.CountryCheckBox);
            this.GroupBox.Controls.Add(this.CityCheckBox);
            this.GroupBox.Controls.Add(this.CompanyCheckBox);
            this.GroupBox.Controls.Add(this.DateCheckBox);
            this.GroupBox.Location = new System.Drawing.Point(0, 25);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(800, 50);
            this.GroupBox.TabIndex = 3;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Select columns for grouping";
            // 
            // CancelGroupButton
            // 
            this.CancelGroupButton.Location = new System.Drawing.Point(627, 17);
            this.CancelGroupButton.Name = "CancelGroupButton";
            this.CancelGroupButton.Size = new System.Drawing.Size(75, 23);
            this.CancelGroupButton.TabIndex = 6;
            this.CancelGroupButton.Text = "Cancel";
            this.CancelGroupButton.UseVisualStyleBackColor = true;
            this.CancelGroupButton.Visible = false;
            this.CancelGroupButton.Click += new System.EventHandler(this.CancelGroupButton_Click);
            // 
            // GroupButton
            // 
            this.GroupButton.Location = new System.Drawing.Point(497, 17);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(75, 23);
            this.GroupButton.TabIndex = 5;
            this.GroupButton.Text = "Group";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Visible = false;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // SurnameCheckBox
            // 
            this.SurnameCheckBox.AutoSize = true;
            this.SurnameCheckBox.Location = new System.Drawing.Point(332, 21);
            this.SurnameCheckBox.Name = "SurnameCheckBox";
            this.SurnameCheckBox.Size = new System.Drawing.Size(99, 17);
            this.SurnameCheckBox.TabIndex = 4;
            this.SurnameCheckBox.Text = "Surname Name";
            this.SurnameCheckBox.UseVisualStyleBackColor = true;
            this.SurnameCheckBox.CheckedChanged += new System.EventHandler(this.SurnameCheckBox_CheckedChanged);
            // 
            // CountryCheckBox
            // 
            this.CountryCheckBox.AutoSize = true;
            this.CountryCheckBox.Location = new System.Drawing.Point(252, 21);
            this.CountryCheckBox.Name = "CountryCheckBox";
            this.CountryCheckBox.Size = new System.Drawing.Size(62, 17);
            this.CountryCheckBox.TabIndex = 3;
            this.CountryCheckBox.Text = "Country";
            this.CountryCheckBox.UseVisualStyleBackColor = true;
            this.CountryCheckBox.CheckedChanged += new System.EventHandler(this.CountryCheckBox_CheckedChanged);
            // 
            // CityCheckBox
            // 
            this.CityCheckBox.AutoSize = true;
            this.CityCheckBox.Location = new System.Drawing.Point(172, 21);
            this.CityCheckBox.Name = "CityCheckBox";
            this.CityCheckBox.Size = new System.Drawing.Size(43, 17);
            this.CityCheckBox.TabIndex = 2;
            this.CityCheckBox.Text = "City";
            this.CityCheckBox.UseVisualStyleBackColor = true;
            this.CityCheckBox.CheckedChanged += new System.EventHandler(this.CityCheckBox_CheckedChanged);
            // 
            // CompanyCheckBox
            // 
            this.CompanyCheckBox.AutoSize = true;
            this.CompanyCheckBox.Location = new System.Drawing.Point(92, 21);
            this.CompanyCheckBox.Name = "CompanyCheckBox";
            this.CompanyCheckBox.Size = new System.Drawing.Size(70, 17);
            this.CompanyCheckBox.TabIndex = 1;
            this.CompanyCheckBox.Text = "Company";
            this.CompanyCheckBox.UseVisualStyleBackColor = true;
            this.CompanyCheckBox.CheckedChanged += new System.EventHandler(this.CompanyCheckBox_CheckedChanged);
            // 
            // DateCheckBox
            // 
            this.DateCheckBox.AutoSize = true;
            this.DateCheckBox.Location = new System.Drawing.Point(12, 21);
            this.DateCheckBox.Name = "DateCheckBox";
            this.DateCheckBox.Size = new System.Drawing.Size(49, 17);
            this.DateCheckBox.TabIndex = 0;
            this.DateCheckBox.Text = "Date";
            this.DateCheckBox.UseVisualStyleBackColor = true;
            this.DateCheckBox.CheckedChanged += new System.EventHandler(this.DateCheckBox_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ShipmentsGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Accounting program";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentsGrid)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administeringToolStripMenuItem;
        private System.Windows.Forms.DataGridView ShipmentsGrid;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button DeleteShipmentButton;
        private System.Windows.Forms.Button CreateShipmentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.CheckBox DateCheckBox;
        private System.Windows.Forms.CheckBox CountryCheckBox;
        private System.Windows.Forms.CheckBox CityCheckBox;
        private System.Windows.Forms.CheckBox CompanyCheckBox;
        private System.Windows.Forms.Button CancelGroupButton;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.CheckBox SurnameCheckBox;
        private System.Windows.Forms.Button UpdateShipmentsButton;
    }
}