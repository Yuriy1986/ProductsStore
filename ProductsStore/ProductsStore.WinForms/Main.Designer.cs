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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administeringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShipmentsGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteShipmentButton = new System.Windows.Forms.Button();
            this.CreateShipmentButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentsGrid)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChangePasswordToolStripMenuItem_MouseUp);
            // 
            // administeringToolStripMenuItem
            // 
            this.administeringToolStripMenuItem.Name = "administeringToolStripMenuItem";
            this.administeringToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.administeringToolStripMenuItem.Text = "Administering";
            this.administeringToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AdministeringToolStripMenuItem_MouseUp);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ExitToolStripMenuItem_MouseUp);
            // 
            // ShipmentsGrid
            // 
            this.ShipmentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShipmentsGrid.Location = new System.Drawing.Point(0, 25);
            this.ShipmentsGrid.Name = "ShipmentsGrid";
            this.ShipmentsGrid.Size = new System.Drawing.Size(800, 369);
            this.ShipmentsGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DeleteShipmentButton);
            this.panel1.Controls.Add(this.CreateShipmentButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 2;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administeringToolStripMenuItem;
        private System.Windows.Forms.DataGridView ShipmentsGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DeleteShipmentButton;
        private System.Windows.Forms.Button CreateShipmentButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}