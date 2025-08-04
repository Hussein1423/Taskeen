using PresentationLayer.RoleClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskeenLogicLayer;
using TaskeenLogicLayer.DTOs;
using TaskeenLogicLayer.Helpers;
using TaskeenLogicLayer.Services;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            gtxtbUser.TextChanged += gtxtb_TextChanged;
            gtxtbPassword.TextChanged += gtxtb_TextChanged;

        }

        private async void gbtnLogin_Click(object sender, EventArgs e)
        {
            AuthResultDto result = await AuthenticationService.Login(gtxtbUser.Text, gtxtbPassword.Text);
            if (result.IsSuccess == true)
            {
                if (chkbRemember.Checked)
                {
                    RegistryHelper.SaveCredentials(gtxtbUser.Text, EncryptionHelper.Encrypt(gtxtbPassword.Text));
                }
                else
                {
                    RegistryHelper.ClearCredentials();
                }

                var userRole = CurrentUserSession.Role;
                var formToShow = UserFormFactory.GetFormByRole(userRole);

                if (formToShow != null)
                {
                    this.Hide(); // إخفاء الفورم الحالي
                    formToShow.Show();
                }
                else
                {
                    MessageBox.Show("Unknown role: " + userRole);
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        ErrorProvider errorProvider1 = new ErrorProvider();
        private void gtxtbUser_Validated(object sender, EventArgs e)
        {
            
            if (gtxtbUser.Text.Length < 4)
            {
                errorProvider1.SetError(gtxtbUser, "Username cannot be less than 4.");
                gtxtbUser.Focus();
            }
            else
            {
                errorProvider1.SetError(gtxtbUser, string.Empty);
            }
        }

        private void gtxtbPassword_Validated(object sender, EventArgs e)
        {
            if (gtxtbPassword.Text.Length < 8)
            {
                errorProvider1.SetError(gtxtbPassword, "Password cannot be less than 8.");
                gtxtbPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(gtxtbPassword, string.Empty);
            }
        }

        private void ValidateForm()
        {
            bool isUsernameValid = gtxtbUser.Text.Length >= 4;
            bool isPasswordValid = gtxtbPassword.Text.Length >= 8;

            gbtnLogin.Enabled = isUsernameValid && isPasswordValid &&
                                string.IsNullOrEmpty(errorProvider1.GetError(gtxtbUser)) &&
                                string.IsNullOrEmpty(errorProvider1.GetError(gtxtbPassword));
        }


        private void gtxtb_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }
    }
}
