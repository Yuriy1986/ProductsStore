using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsStore.BLL.DTO;
using ProductsStore.BLL.Interfaces;

namespace ProductsStore.WinForms
{
    public partial class Main : Form
    {
        IUserService UserService { get; }
        IShipmentService ShipmentService { get; }

        bool Admin { get; set; }
        string LoginUser { get; set; }
        
        public Main(IUserService userService, IShipmentService shipmentService)
        {
            UserService = userService;
            ShipmentService = shipmentService;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login login = new Login(UserService);
            if(login.ShowDialog() !=DialogResult.OK)
                this.Close();

            Admin = login.Admin;
            LoginUser = login.LoginUser;
            menuStrip1.Visible = true;
            if (!Admin)
                administeringToolStripMenuItem.Visible = false;

             ShipmentsGrid.DataSource = ShipmentService.GetShipments();
            ShipmentsGrid.AutoSize = true;
            //ShipmentsGrid.Columns[0].Visible = false;
        }

        private void ChangePasswordToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(UserService, LoginUser);
            changePassword.ShowDialog();
        }

        private void AdministeringToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            Administering administering = new Administering(UserService);
            administering.ShowDialog();
        }

        private void CreateShipmentButton_Click(object sender, EventArgs e)
        {
            CreateShipment createShipment = new CreateShipment(ShipmentService, LoginUser);
            createShipment.ShowDialog();
        }
    }
}
