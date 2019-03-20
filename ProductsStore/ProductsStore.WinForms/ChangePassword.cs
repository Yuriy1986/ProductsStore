using ProductsStore.BLL.DTO;
using ProductsStore.BLL.Interfaces;
using System;
using System.Windows.Forms;

namespace ProductsStore.WinForms
{
    public partial class ChangePassword : Form
    {
        IUserService UserService { get; }

        string LoginUser { get; }

        bool RunValidation { get; set; } = false;

        public ChangePassword(IUserService userService, string loginUser)
        {
            UserService = userService;
            LoginUser = loginUser;
            InitializeComponent();
        }

        private void ChangePass_OK_Click(object sender, EventArgs e)
        {
            RunValidation = true;

            if (OldPasswordBox.Text.Trim() == "" || NewPasswordBox.Text.Trim() == "")
            {
                ChangePassword_Validation.Text = "Passwords are required";
                return;
            }

            if (OldPasswordBox.Text == NewPasswordBox.Text)
            {
                ChangePassword_Validation.Text = "Passwords are same";
                return;
            }

            if (OldPasswordBox.Text.Length > 60 || NewPasswordBox.Text.Length > 60)
            {
                ChangePassword_Validation.Text = "Passwords must be no more 60 characters long.";
                return;
            }

            CheckPasswords();
        }

        private void CheckPasswords()
        {
            DTOChangePasswordViewModel dtoChangePasswordViewModel = new DTOChangePasswordViewModel()
            {
                Login = LoginUser,
                OldPassword = OldPasswordBox.Text,
                NewPassword = NewPasswordBox.Text
            };

            string errors = UserService.ChangePassword(dtoChangePasswordViewModel);
            if(errors== null)
            {
                MessageBox.Show("Password is changed");
                Close();
            }
            ChangePassword_Validation.Text = errors;
        }

        private void ChangePass_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OldPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (RunValidation)
                Validation();
        }

        private void NewPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (RunValidation)
                Validation();
        }

        private void Validation()
        {
            if (OldPasswordBox.Text.Trim() == "" || NewPasswordBox.Text.Trim() == "")
            {
                ChangePassword_Validation.Text = "Passwords are required";
                return;
            }
            else if (ChangePassword_Validation.Text == "Passwords are required" && OldPasswordBox.Text.Trim() != "" && NewPasswordBox.Text.Trim() != "")
            {
                ChangePassword_Validation.Text = "";
                return;
            }

            if (OldPasswordBox.Text == NewPasswordBox.Text)
            {
                ChangePassword_Validation.Text = "Passwords are same";
                return;
            }
            else if (ChangePassword_Validation.Text == "Passwords are same" && OldPasswordBox.Text != NewPasswordBox.Text)
            {
                ChangePassword_Validation.Text = "";
                return;
            }

            if (OldPasswordBox.Text.Length > 60 || NewPasswordBox.Text.Length > 60)
            {
                ChangePassword_Validation.Text = "Passwords must be no more 60 characters long.";
                return;
            }
            else if (ChangePassword_Validation.Text == "Passwords must be no more 60 characters long." && OldPasswordBox.Text.Length <=60 && NewPasswordBox.Text.Length<=60)
            {
                ChangePassword_Validation.Text = "";
                return;
            }
        }
    }
}
