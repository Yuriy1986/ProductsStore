using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsStore.WinForms
{
    public class Validation
    {
        public static void OnlyLetterInTextbox(KeyPressEventArgs e)
        {
            char s = e.KeyChar;
            if (Char.IsDigit(s) || Char.IsSymbol(s) || Char.IsSeparator(s) || Char.IsPunctuation(s))
                e.Handled = true;
        }

        public static void OnlyDigitInTextbox(KeyPressEventArgs e)
        {
            char s = e.KeyChar;
            if (Char.IsLetter(s) || Char.IsSymbol(s) || Char.IsSeparator(s) || Char.IsPunctuation(s))
                e.Handled = true;
        }

        public static void OnlyDigitOrCommaInTextbox(KeyPressEventArgs e)
        {
            char s = e.KeyChar;
            if (Char.IsLetter(s) || Char.IsSymbol(s) || Char.IsSeparator(s) || (Char.IsPunctuation(s) && s != ',' && s != '.'))
                e.Handled = true;
        }

        public static void ValidationInputs(TextBox textBox, Label validLabel)
        {
            if (textBox.Text.Trim() == "")
            {
                if (textBox.Name == "ResetPasswordBox")
                    validLabel.Text = "The password is required.";
                else if (textBox.Name.IndexOf("BoxEdit") != -1)
                    validLabel.Text = "The " + textBox.Name.Replace("BoxEdit", " ") + "is required.";
                else
                    validLabel.Text = "The " + textBox.Name.Replace("Box", " ") + "is required.";
                return;
            }

            if (textBox.Text.Length > 30)
            {
                if (textBox.Name == "ResetPasswordBox")
                    validLabel.Text = "The password must be no more 30 characters long.";
                else if (textBox.Name.IndexOf("BoxEdit") != -1)
                    validLabel.Text = "The " + textBox.Name.Replace("BoxEdit", " ") + "must be no more 30 characters long.";
                else
                    validLabel.Text = "The " + textBox.Name.Replace("Box", " ") + "must be no more 30 characters long.";
                return;
            }

            else
                validLabel.Text = "";
        }
    }
}
