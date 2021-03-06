﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        bool AnswerClose { get; set; } = false;

        public Main(IUserService userService, IShipmentService shipmentService)
        {
            UserService = userService;
            ShipmentService = shipmentService;
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login login = new Login(UserService);
            if (login.ShowDialog() != DialogResult.OK)
                this.Close();

            GroupBox.Visible = true;
            ShipmentsGrid.Visible = true;
            MainPanel.Visible = true;
            AnswerClose = true;
            Admin = login.Admin;
            LoginUser = login.LoginUser;
            menuStrip1.Visible = true;
            if (!Admin)
                administeringToolStripMenuItem.Visible = false;
            ShipmentsGrid.EnableHeadersVisualStyles = false;
            ShipmentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ShipmentsGrid.DataSource = ShipmentService.GetShipments();
            SetupGrid();
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

        private void ExitToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AnswerClose)
            {
                if (!AnswerBeforeClose())
                    e.Cancel = true;
            }
        }

        private bool AnswerBeforeClose()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
                return true;
            return false;
        }

        private void SetupGrid()
        {
            ShipmentsGrid.Columns["ShipmentDate"].HeaderText = "Date";
            ShipmentsGrid.Columns["SurnameName"].HeaderText = "Surname name";
            ShipmentsGrid.Columns["Id"].Visible = false;
            ShipmentsGrid.Columns["Login"].Visible = false;
        }

        private void CreateShipmentButton_Click(object sender, EventArgs e)
        {
            CreateShipment createShipment = new CreateShipment(ShipmentService, LoginUser);
            if (createShipment.ShowDialog() == DialogResult.OK)
            {
                var shipmentsGridItems = (List<DTOShipmentsViewModel>)ShipmentsGrid.DataSource;
                shipmentsGridItems.Add(createShipment.DtoShipmentsViewModel);
                ShipmentsGrid.DataSource = null;
                ShipmentsGrid.DataSource = shipmentsGridItems;
                SetupGrid();
                if (ShipmentsGrid.RowCount == 1)
                    UpdateShipmentsButton.PerformClick();
                ShipmentsGrid.CurrentCell = ShipmentsGrid.Rows[ShipmentsGrid.RowCount - 1].Cells["Sum"];
            }
        }

        private void DeleteShipmentButton_Click(object sender, EventArgs e)
        {
            if (ShipmentsGrid.RowCount != 0)
            {
                // Delete shipment can only owner (manager).
                if (ShipmentsGrid.CurrentRow.Cells["Login"].Value.ToString() == LoginUser)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete shipment", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        int idCurrent = int.Parse(ShipmentsGrid.CurrentRow.Cells["Id"].Value.ToString());
                        if (ShipmentService.DeleteShipment(idCurrent))
                        {
                            var shipmentsGridItems = (List<DTOShipmentsViewModel>)ShipmentsGrid.DataSource;
                            shipmentsGridItems.RemoveAt(shipmentsGridItems.FindIndex(x => x.Id == idCurrent));
                            ShipmentsGrid.DataSource = null;
                            ShipmentsGrid.DataSource = shipmentsGridItems;
                            SetupGrid();
                            if (ShipmentsGrid.RowCount != 0)
                                ShipmentsGrid.CurrentCell = ShipmentsGrid.Rows[0].Cells["Sum"];
                            MessageBox.Show("Shipment deleted");
                        }
                    }
                }
            }
        }

        private void UpdateShipments_Click(object sender, EventArgs e)
        {
            if (ShipmentsGrid.RowCount != 0)
            {
                ShipmentsGrid.DataSource = null;
                ShipmentsGrid.DataSource = ShipmentService.GetShipments();
                SetupGrid();
                ShipmentsGrid.CurrentCell = ShipmentsGrid.Rows[0].Cells["Sum"];
            }
        }

        #region Groupbox
        private void DateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Grouping();
        }

        private void CompanyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Grouping();
        }

        private void CityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Grouping();
        }

        private void CountryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Grouping();
        }

        private void SurnameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Grouping();
        }

        private void Grouping()
        {
            if (ShipmentsGrid.RowCount != 0)
            {
                if (DateCheckBox.Checked || CompanyCheckBox.Checked || CityCheckBox.Checked || CountryCheckBox.Checked || SurnameCheckBox.Checked)
                {
                    GroupButton.Visible = true;
                    CancelGroupButton.Visible = true;
                    MainPanel.Enabled = false;
                }
                else
                {
                    GroupButton.Visible = false;
                    CancelGroupButton.Visible = false;
                    MainPanel.Enabled = true;

                    UpdateShipmentsButton.PerformClick();
                }
            }
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            GroupButton.Visible = false;
            DTOGroupingShipsmentsViewModel dtoGroupingShipsmentsViewModel = new DTOGroupingShipsmentsViewModel
            {
                Date = DateCheckBox.Checked,
                Company = CompanyCheckBox.Checked,
                City = CityCheckBox.Checked,
                Country = CountryCheckBox.Checked,
                SurnameName = SurnameCheckBox.Checked
            };

            ShipmentsGrid.DataSource = null;
            var responce = ShipmentService.GetShipments(dtoGroupingShipsmentsViewModel);
            ShipmentsGrid.DataSource = responce;

            if (responce.First().ShipmentDate.ToString() == "01.01.0001 0:00:00")
                ShipmentsGrid.Columns["ShipmentDate"].Visible = false;
            if (responce.First().Company == null)
                ShipmentsGrid.Columns["Company"].Visible = false;
            if (responce.First().City == null)
                ShipmentsGrid.Columns["City"].Visible = false;
            if (responce.First().Country == null)
                ShipmentsGrid.Columns["Country"].Visible = false;
            if (responce.First().SurnameName == null)
                ShipmentsGrid.Columns["SurnameName"].Visible = false;

            SetupGrid();
        }

        private void CancelGroupButton_Click(object sender, EventArgs e)
        {
            DateCheckBox.Checked = false;
            CompanyCheckBox.Checked = false;
            CityCheckBox.Checked = false;
            CountryCheckBox.Checked = false;
            SurnameCheckBox.Checked = false;

            GroupButton.Visible = false;
            CancelGroupButton.Visible = false;

            MainPanel.Enabled = true;

            UpdateShipmentsButton.PerformClick();
        }
        #endregion
    }
}