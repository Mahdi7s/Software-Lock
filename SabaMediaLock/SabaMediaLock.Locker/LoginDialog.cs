using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Locker.Models;
using SabaMediaLock.Locker.SiteServiceReference;
using Telerik.WinControls;

namespace SabaMediaLock.Locker
{
    public partial class LoginDialog : Form
    {
        private int _invalidCounter = 0;

        public LoginDialog()
        {
            InitializeComponent();

            DShare.AppTheme = "TelerikMetroBlue";
            ThemeResolutionService.ApplyThemeToControlTree(this, DShare.AppTheme);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            try
            {
                lblError.ForeColor = Color.Gray;
                lblError.Text = "لطفا چند لحظه صبر کنید...";
                lblError.Visible = true;
                using (var serviceClient = new SiteServiceClient())
                {
                    if (serviceClient.CanLogin(txtUsername.Text, txtPassword.Text))
                    {
                        DShare.Username = txtUsername.Text;
                        DShare.Password = txtPassword.Text;
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        GoToInvalidMode();
                    }
                }
            }
            catch (EndpointNotFoundException ex) // we can't access service
            {
                GoToInvalidMode(false);
            }
            catch (Exception ex)
            {
                GoToInvalidMode(false);
            }
        }

        private void GoToInvalidMode(bool userPassInvalid = true)
        {
            if (++_invalidCounter >= 3) DialogResult = System.Windows.Forms.DialogResult.No;

            DShare.Username = DShare.Password = string.Empty;
            txtUsername.Text = txtPassword.Text = string.Empty;

            txtUsername.BackColor = Color.OrangeRed;
            txtPassword.BackColor = Color.OrangeRed;

            lblError.ForeColor = Color.Red;
            if (userPassInvalid)
            {
                lblError.Text = "نام کاربری یا کلمه عبور نادرست می باشد";
            }
            else
            {
                lblError.Text = "خطا در برقراری ارتباط با سرور قفل";
            }
            lblError.Visible = true;

            txtUsername.Focus();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text));
        }
    }
}
