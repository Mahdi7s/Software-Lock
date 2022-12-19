using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Locker.Models;
using SabaMediaLock.Locker.SiteServiceReference;
using SabaMediaLock.Utilities;
using SabaMediaLock.Utilities.Localizations;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;

namespace SabaMediaLock.Locker
{
    public partial class Form1 : Form
    {
        private readonly Controllers.DefaultThemes _defaultThemes = new Controllers.DefaultThemes { Dock = DockStyle.Fill };
        private readonly Controllers.FlashThemes _flashThemes = new Controllers.FlashThemes { Dock = DockStyle.Fill };
        private Rectangle _buttonsBound = Rectangle.Empty;
        private bool _isLookedAtGeneralSettings = false;
        private bool _isPrevClicked = false;

        public Form1()
        {
            InitializeComponent();

            var loginDlg = new LoginDialog { StartPosition = FormStartPosition.CenterParent };
            if (loginDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Init();
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void Init()
        {
            DShare.AppTheme = "TelerikMetroBlue";
            ThemeResolutionService.ApplyThemeToControlTree(this, DShare.AppTheme);
            
            //ThemeResolutionService.GetTheme(themeName);
            //ThemeResolutionService.AllowAnimations = true;
            //ThemeResolutionService.ApplicationThemeName = themeName;

            radWizard1.PageHeaderElement.Title = "قفل مدیای صبا";
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageBoxLoc();
            radWizard1.HelpButton.Visibility = ElementVisibility.Collapsed;

            radWizard1.Next += radWizard1_Next;
            radWizard1.SelectedPageChanged += radWizard1_SelectedPageChanged;
            radWizard1.SelectedPageChanging += radWizard1_SelectedPageChanging;
            radWizard1.Finish += radWizard1_Finish;
            radWizard1.Help += HelpButton_Click;
            radWizard1.Previous += radWizard1_Previous;
            radWizard1.Cancel += radWizard1_Cancel;
            radScrollablePanel2.Controls.Add(_defaultThemes);

            RadMessageBox.Instance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RadMessageBox.Instance.RightToLeftLayout = false;            

            _defaultThemes.Wizard = radWizard1;
            _defaultThemes.PForm = processingForm1;
            processingForm1.Form1 = this;
        }

        private void radWizard1_Finish(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radWizard1_SelectedPageChanging(object sender, Telerik.WinControls.UI.SelectedPageChangingEventArgs e)
        {
            if (e.NextPage == radWizard1.Pages[3])
            {
                radWizard1.CancelButton.Enabled = false;
                radWizard1.NextButton.Enabled = false;
                radWizard1.BackButton.Enabled = false;
                radWizard1.BackButton.Visibility = ElementVisibility.Collapsed;
                return;
            }
            if (e.SelectedPage == radWizard1.Pages[0])
            {
                var isUniqNameValid = IsUniqueNameValid(); //***************

                if (!(e.Cancel = (string.IsNullOrEmpty(txtSoftName.Text) || string.IsNullOrWhiteSpace(txtFilePath.Text) || string.IsNullOrWhiteSpace(txtSoftwareUniqueName.Text) || !isUniqNameValid)))
                {
                    processingForm1.MediaFilePath = txtFilePath.Text;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                    {
                        Msg.ShowCompleteForm("لطفا مکان فایل فلش خود را معیین کنید.", this);
                        OpenMediaPath();
                    }
                    else if(string.IsNullOrWhiteSpace(txtSoftName.Text))
                    {
                        Msg.ShowCompleteForm("لطفا نام برنامه را وارد کنید.", this);
                        txtSoftName.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(txtSoftwareUniqueName.Text))
                    {
                        Msg.ShowCompleteForm("لطفا نام مختصر برنامه را وارد کنید", this);
                        txtSoftwareUniqueName.Focus();
                    }
                    else if (!isUniqNameValid)
                    {
                        Msg.ShowCompleteForm("نام مختصر وارد شده نا معتبر می باشد.", this);
                        txtSoftwareUniqueName.Focus();
                    }
                }
                return;
            }
            else if (e.NextPage == radWizard1.Pages[2])
            {
                if (!_isLookedAtGeneralSettings)
                {
                    if (Msg.Show("آیا مایل به تغییر دادن تنظیمات کلی هستید؟", "تنظیمات کلی", MessageBoxButtons.YesNo, RadMessageIcon.Question, this) == DialogResult.Yes)
                    {
                        tglFlash.ToggleState = ToggleState.On;
                        e.Cancel = true;
                        return;
                    }
                }
                if (DShare.GeneralSettings.cbEncryptResources.Checked && string.IsNullOrWhiteSpace(DShare.GeneralSettings.txtResourcesPath.Text))
                {
                    Msg.ShowCompleteForm("لطفا آدرس شاخه منابع را تعیین کنید.", this);
                    if (!DShare.GeneralSettings.BrowseResouceDir())
                    {
                        DShare.GeneralSettings.cbEncryptResources.Checked = false;
                    }
                }
            }

            if (_isPrevClicked)
            {
                radWizard1.NextButton.Enabled = true;
                _isPrevClicked = false;
            }
            else
            {
                radWizard1.NextButton.Enabled = false;
            }
            processingForm1.OnSelectedPageChanging(sender, e);
        }

        private bool IsUniqueNameValid()
        {
            try
            {
                using (var serviceClient = new SiteServiceClient())
                {
                    return serviceClient.IsSoftwareUniqueNameValid(DShare.Username, DShare.Password, txtSoftwareUniqueName.Text);
                }
            }           
            catch (Exception ex)
            {
                Msg.Show("خطا در برقراری ارتباط با سرور قفل", "خطا", MessageBoxButtons.OK, RadMessageIcon.Error, this);
            }
            return false;
        }

        private void radWizard1_Previous(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {
            _isPrevClicked = true;
        }

        private void radWizard1_SelectedPageChanged(object sender, Telerik.WinControls.UI.SelectedPageChangedEventArgs e)
        {
            if (e.SelectedPage == radWizard1.Pages[2])
            {
                radWizard1.CancelButton.Enabled = false;
                radWizard1.NextButton.Enabled = false;
                return;
            }
            processingForm1.OnSelectedPageChanged(sender, e);
        }

        private void radWizard1_Next(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {

        }

        private void radWizard1_Cancel(object sender, EventArgs e)
        {
            if (Msg.Show("آیا می خواهید از ادامه کار انصراف دهید؟", "انصراف", MessageBoxButtons.YesNo, RadMessageIcon.Question, this) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Clicked...");
        }

        public string MediaFilePath { get; private set; }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void rbUseFlashThemes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radToggleButton2_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                _isLookedAtGeneralSettings = true;

                radScrollablePanel2.Controls.Clear();
                radScrollablePanel2.Controls.Add(_flashThemes);

                tglDefault.IsChecked = false;
            }
        }

        private void radToggleButton1_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == ToggleState.On)
            {
                radScrollablePanel2.Controls.Clear();
                radScrollablePanel2.Controls.Add(_defaultThemes);

                tglFlash.IsChecked = false;
            }
        }

        private void btnOpenMediaPath_Click(object sender, EventArgs e)
        {
            OpenMediaPath();
        }

        private void OpenMediaPath()
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
                if (string.IsNullOrEmpty(txtSoftName.Text))
                {
                    txtSoftName.Text = Path.GetFileNameWithoutExtension(txtFilePath.Text);
                }
            }
        }

        private void txtPassword_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            
        }

        private void btnSelectPIcon_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DShare.AppIconPath = openFileDialog2.FileName;
               picPIcon.Image = Image.FromFile(openFileDialog2.FileName);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void radWizard1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_buttonsBound.Contains(e.Location)) return;
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MovableWinFormBehavior.StartDragging(Handle);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int bottomMargin = 40, leftMargin = radWizard1.CancelButton.Size.Width * (int)4.5;
            _buttonsBound = new Rectangle(0, radWizard1.Height - bottomMargin, leftMargin, radWizard1.CancelButton.Size.Height); 
        }
    }
}
