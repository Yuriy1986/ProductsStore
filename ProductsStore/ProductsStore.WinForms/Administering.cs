using ProductsStore.BLL.DTO;
using ProductsStore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ProductsStore.WinForms
{
    public partial class Administering : Form
    {
        IUserService UserService { get; }

        DTOEditViewModel ManagerInformation { get; set; }

        /// <summary>
        /// Administrator can enter any password (without reliability checking)!!! In registration and reset password
        /// </summary>

        public Administering(IUserService userService)
        {
            UserService = userService;
            InitializeComponent();
            RoleBox.Items.AddRange(new string[] { "admin", "user" });
            RoleBox.SelectedItem = "user";
            var userList = UserService.GetAllLogins();
            LoginsBox.DataSource = userList;
            LoginsBox.SelectedItem = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Administering_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AnswerBeforeClose())
                e.Cancel = true;
        }

        private bool AnswerBeforeClose()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to continue", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
                return true;
            return false;
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void SurnameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void PatronymicBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        // Register.
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            if (Name_Validation.Text == "" && Surname_Validation.Text == "" && Patronymic_Validation.Text == "" && Login_Validation.Text == "" && Password_Validation.Text == "" && ConfirmPassword_Validation.Text == "")
            {
                DTORegisterViewModel dtoRegisterViewModel = new DTORegisterViewModel()
                {
                    Name = NameBox.Text,
                    Surname = SurnameBox.Text,
                    Patronymic = PatronymicBox.Text,
                    Login = LoginBox.Text,
                    Password = PasswordBox.Text,
                    Role = RoleBox.Text
                };

                var responce = UserService.Register(dtoRegisterViewModel);
                if (responce == null)
                {
                    MessageBox.Show("Registration successful");
                    NameBox.Text = "";
                    SurnameBox.Text = "";
                    PatronymicBox.Text = "";
                    LoginBox.Text = "";
                    PasswordBox.Text = "";
                    ConfirmPasswordBox.Text = "";
                    RoleBox.SelectedItem = "user";
                    Register_Validation.Text = "";
                    return;
                }
                Register_Validation.Text = responce;
            }
        }

        private void NameBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(NameBox, Name_Validation);
        }

        private void SurnameBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(SurnameBox, Surname_Validation);
        }

        private void PatronymicBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(PatronymicBox, Patronymic_Validation);
        }

        private void LoginBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(LoginBox, Login_Validation);
        }

        private void PasswordBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(PasswordBox, Password_Validation);
        }

        private void ConfirmPasswordBox_Validating(object sender, CancelEventArgs e)
        {
            if (ConfirmPasswordBox.Text != PasswordBox.Text)
                ConfirmPassword_Validation.Text = "The password and confirmation password do not match.";
            else
                ConfirmPassword_Validation.Text = "";
        }

        // Edit/Delete.
        #region Edit.
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LoginsBox.Text == "")
            {
                Logins_Validation.Text = "Select Login";
                return;
            }

            ResetPasswordButton.Visible = false;
            DeleteButton.Visible = false;
            Logins_Validation.Text = "";
            EditPanel.Visible = true;
            LoginsBox.Enabled = false;
            EditButton.Visible = false;

            ManagerInformation = UserService.GetInformation(LoginsBox.Text);

            NameBoxEdit.Text = ManagerInformation.Name;
            SurnameBoxEdit.Text = ManagerInformation.Surname;
            PatronymicBoxEdit.Text = ManagerInformation.Patronymic;
            LoginBoxEdit.Text = ManagerInformation.Login;
            if (RoleEditBox.Items.Count == 0)
                RoleEditBox.Items.AddRange(new string[] { "admin", "user" });
            RoleEditBox.SelectedItem = ManagerInformation.Role;
            NameBoxEdit_Validation.Text = "";
            SurnameBoxEdit_Validation.Text = "";
            PatronymicBoxEdit_Validation.Text = "";
            LoginBoxEdit_Validation.Text = "";
            Edit_Validation.Text = "";
        }

        private void NameBoxEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void SurnameBoxEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void PatronymicBoxEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyLetterInTextbox(e);
        }

        private void EditButton_OK_Click(object sender, EventArgs e)
        {
            if (NameBoxEdit_Validation.Text == "" && SurnameBoxEdit_Validation.Text == "" && PatronymicBoxEdit_Validation.Text == "" && LoginBoxEdit_Validation.Text == "")
            {
                if (NameBoxEdit.Text == ManagerInformation.Name && SurnameBoxEdit.Text == ManagerInformation.Surname &&
                    PatronymicBoxEdit.Text == ManagerInformation.Patronymic && LoginBoxEdit.Text == ManagerInformation.Login && RoleEditBox.Text == ManagerInformation.Role)
                {
                    Edit_Validation.Text = "User wasn`t edited";
                    return;
                }
                DTOEditViewModel dtoEditViewModel = new DTOEditViewModel
                {
                    Name = NameBoxEdit.Text,
                    Surname = SurnameBoxEdit.Text,
                    Patronymic = PatronymicBoxEdit.Text,
                    Login = ManagerInformation.Login,
                    Role = RoleEditBox.Text
                };
                if (LoginBoxEdit.Text != ManagerInformation.Login)
                    dtoEditViewModel.NewLogin = LoginBoxEdit.Text;

                string responce = UserService.EditUser(dtoEditViewModel);
                if (responce == null)
                {
                    MessageBox.Show("User edited");

                    if (LoginBoxEdit.Text != ManagerInformation.Login)
                    {
                        var loginsBoxItems = (List<string>)LoginsBox.DataSource;
                        LoginsBox.DataSource = null;
                        loginsBoxItems[loginsBoxItems.IndexOf(ManagerInformation.Login)] = LoginBoxEdit.Text;
                        LoginsBox.DataSource = loginsBoxItems;
                    }
                     EditButton_Cancel.PerformClick();

                    return;
                }
                Edit_Validation.Text = responce;
            }
        }

        private void EditButton_Cancel_Click(object sender, EventArgs e)
        {
            EditButton.Visible = true;
            DeleteButton.Visible = true;
            EditPanel.Visible = false;
            ResetPasswordButton.Visible = true;
            LoginsBox.Enabled = true;
        }

        private void NameBoxEdit_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(NameBoxEdit, NameBoxEdit_Validation);
        }

        private void SurnameBoxEdit_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(SurnameBoxEdit, SurnameBoxEdit_Validation);
        }

        private void PatronymicBoxEdit_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(PatronymicBoxEdit, PatronymicBoxEdit_Validation);
        }

        private void LoginBoxEdit_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(LoginBoxEdit, LoginBoxEdit_Validation);
        }
        #endregion

        #region Delete.
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (LoginsBox.Text == "")
            {
                Logins_Validation.Text = "Select Login";
                return;
            }

            Logins_Validation.Text = "";

            DialogResult result = MessageBox.Show("Are you sure you want to delete user`s "+ LoginsBox.Text, "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                var responce = UserService.DeleteUser(LoginsBox.Text);
                if(responce==null)
                {
                    MessageBox.Show("Close this window and reset program.");
                    return;
                }
                MessageBox.Show(responce);

                var loginsBoxItems = (List<string>)LoginsBox.DataSource;
                var loginDeleted = LoginsBox.Text;
                LoginsBox.DataSource = null;
                loginsBoxItems.Remove(loginDeleted);
                LoginsBox.DataSource = loginsBoxItems;
                LoginsBox.SelectedItem = null;
            }
        }
        #endregion

        #region ResetPassword.
        private void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            if (LoginsBox.Text == "")
            {
                Logins_Validation.Text = "Select Login";
                return;
            }

            EditButton.Visible = false;
            DeleteButton.Visible = false;
            ResetPasswordPanel.Visible = true;
            Logins_Validation.Text = "";
            ResetPasswordBox.Text = "";
            ConfirmResetPasswordBox.Text = "";
            ResetPassword_Validation.Text = "";
            ResetPasswordButton.Visible = false;
            LoginsBox.Enabled = false;
        }

        private void ResetPasswordButton_Cancel_Click(object sender, EventArgs e)
        {
            EditButton.Visible = true;
            DeleteButton.Visible = true;
            ResetPasswordPanel.Visible = false;
            ResetPasswordButton.Visible = true;
            LoginsBox.Enabled = true;
        }

        private void ResetPasswordButtonOK_Click(object sender, EventArgs e)
        {
            ResetPasswordBox.Focus();
            ConfirmResetPasswordBox.Focus();
            ResetPasswordButtonOK.Focus();

            if (ResetPassword_Validation.Text == "")
            {
                DTOChangePasswordAdminViewModel dTOChangePasswordAdminViewModel = new DTOChangePasswordAdminViewModel
                {
                    Login = LoginsBox.Text,
                    Password = ResetPasswordBox.Text
                };

                var responce = UserService.ResetPassword(dTOChangePasswordAdminViewModel);
                if (responce == null)
                {
                    MessageBox.Show("Password is reset");
                    ResetPasswordButton_Cancel.PerformClick();
                    return;
                }
                MessageBox.Show(responce);
            }
        }

        private void ResetPasswordBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidationInputs(ResetPasswordBox, ResetPassword_Validation);
        }

        private void ConfirmResetPasswordBox_Validating(object sender, CancelEventArgs e)
        {
            if (ResetPasswordBox.Text == "")
                return;
            if (ConfirmResetPasswordBox.Text != ResetPasswordBox.Text)
                ResetPassword_Validation.Text = "The password and confirmation password do not match.";
            else
                ResetPassword_Validation.Text = "";
        }
        #endregion
    }
}
