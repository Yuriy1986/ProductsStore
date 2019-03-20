using ProductsStore.BLL.DTO;
using ProductsStore.BLL.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProductsStore.WinForms
{
    public partial class CreateShipment : Form
    {
        IShipmentService ShipmentService { get; }
        string LoginUser { get; }
        public DTOShipmentsViewModel DtoShipmentsViewModel { get; set; }
        
        public CreateShipment(IShipmentService shipmentService, string loginUser)
        {
            ShipmentService = shipmentService;
            LoginUser = loginUser;
            InitializeComponent();
        }

        private void CompanyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void CityBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void CountryBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void QuantityBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyDigitInTextbox(e);
        }

        private void SumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyDigitOrCommaInTextbox(e);
        }

        private void CompanyBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(CompanyBox, Company_Validation);
        }

        private void CityBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(CityBox, City_Validation);
        }

        private void CountryBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(CountryBox, Country_Validation);
        }

        private void QuantityBox_Validating(object sender, CancelEventArgs e)
        {
            if (QuantityBox.Text == "" || (int.TryParse(QuantityBox.Text, out int number) && number == 0))
                Quantity_Validation.Text = "The quantity is required.";
            else
                Quantity_Validation.Text = "";
        }

        private void SumBox_Validating(object sender, CancelEventArgs e)
        {
            if (SumBox.Text == "" || !decimal.TryParse(SumBox.Text, out decimal number) || number == 0)
                Sum_Validation.Text = "The sum is required.";
            else
                Sum_Validation.Text = "";
        }

        private void CreateShipment_OK_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (Company_Validation.Text == "" && City_Validation.Text == "" && Country_Validation.Text == "" && Quantity_Validation.Text == "" && Sum_Validation.Text == "")
            {
                DtoShipmentsViewModel = new DTOShipmentsViewModel
                {
                    ShipmentDate = DateTime.Now,
                    Company = CompanyBox.Text,
                    City = CityBox.Text,
                    Country = CountryBox.Text,
                    Login=LoginUser,
                    Quantity = Convert.ToInt32(QuantityBox.Text),
                    Sum = Convert.ToDecimal(SumBox.Text),
                };
                 
                var responce = ShipmentService.CreateShipment(DtoShipmentsViewModel);

                if (responce.Responce == null)
                {
                    DtoShipmentsViewModel.Id = responce.Id;
                    DtoShipmentsViewModel.SurnameName = responce.SurnameName;
                    MessageBox.Show("Shipment was added");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                CreateShipment_Validation.Text = responce.Responce;
            }
        }

        private void CreateShipment_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
