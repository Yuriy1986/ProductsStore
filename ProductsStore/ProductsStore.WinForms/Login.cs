using System;
using System.Windows.Forms;
using ProductsStore.BLL.DTO;
using ProductsStore.BLL.Interfaces;

namespace ProductsStore.WinForms
{
    public partial class Login : Form
    {
        IUserService UserService { get; }

        public bool Admin { get; set; } = false;
        public string LoginUser { get; set; }

        public Login(IUserService userService)
        {
            UserService = userService;
            WindowState = FormWindowState.Normal;
            var userList = UserService.GetAllLogins();
            InitializeComponent();
            Text = "Login";
            LoginsBox.DataSource = userList;
            LoginsBox.SelectedItem = null;
        }

        private void Login_OK_Click(object sender, EventArgs e)
        {
            bool check = true;
            //1. CreateAdmin (only when creating a database) !!! 
            //UserService.CreateAdmin();
            if (PasswordBox.Text.Trim() == "")
            {
                Password_Validation.Text = "Password is required";
                check = false;
            }

            if (LoginsBox.SelectedItem == null)
            {
                Login_Validation.Text = "Login is required";
                check = false;
            }

            if (check)
                CheckLogin();
        }

        private void CheckLogin()
        {
            DTOLoginViewModel dtoLoginViewModel = new DTOLoginViewModel
            {
                Login = LoginsBox.Text,
                Password = PasswordBox.Text
            };
            var responce = UserService.Login(dtoLoginViewModel);
            if (responce == "user" || responce == "admin")
            {
                if (responce == "admin")
                    Admin = true;
                LoginUser = LoginsBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            Password_Validation.Text = responce;
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordBox.Text.Trim() != "")
                Password_Validation.Text = "";
            else
                Password_Validation.Text = "Password is required";
        }

        private void LoginsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoginsBox.SelectedItem != null)
                Login_Validation.Text = "";
        }

        private void Login_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
