using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Utilities;
using SabaMediaLock.Wrapper.Forms;
using Telerik.WinControls;

namespace SabaMediaLock.Wrapper
{
    public partial class EnablingWizard : Form
    {
        private string _faActivationType = "";
        private string _activationResultTitle = "";
        private Rectangle _buttonsBound = Rectangle.Empty;

        public EnablingWizard()
        {
            InitializeComponent();
            Initialize();
            SetupTheme();

            Models.Shares.Wizard = radWizard1;
            Models.Shares.InternetActivationCallback = OnInternetActivation;
            Models.Shares.SmsActivationCallback = OnSmsActivation;
            Models.Shares.TelephoneActivationCallback = OnTelephoneActivation;
        }

        private void Initialize()
        {           
            radWizard1.HelpButton.Visibility = ElementVisibility.Collapsed;

            Icon = SabaMediaLock.Utilities.Others.GetAppIcon();
            radWizard1.PageHeaderElement.Title = "ویزارد فعال سازی برنامه -> انتخاب شیوه فعال سازی";
        }

        private void SetupTheme()
        {
            radWizard1.ThemeName = LockSetteings.Settings.Theme;
        }

        private void OnInternetActivation(bool isActivated, string error)
        {
            OnActivation(isActivated, error);
        }

        private void OnActivation(bool isActivated, string error)
        {
            radWizard1.NextButton.Enabled = true;
            pnlFailOrSuccess.Controls.Clear();
            pnlFailOrSuccess.Controls.Add(isActivated ? (Control)new ActivationSucceeded() { Dock = DockStyle.Fill } : (Control)new ActivationFailed() { Dock = DockStyle.Fill, Error = error });
            _activationResultTitle = isActivated ? "موفق" : "نا موفق";
        }

        private void OnSmsActivation(bool isActivated, string error)
        {
            OnActivation(isActivated, error);
        }

        private void OnTelephoneActivation(bool isActivated, string error)
        {
            throw new NotImplementedException();
        }

        private void radWizard1_Cancel(object sender, EventArgs e)
        {
            if (Msg.Show("آیا از ادامه فعال سازی انصراف می دهید؟", "انصراف", MessageBoxButtons.YesNo, RadMessageIcon.Question, this, LockSetteings.Settings.Theme) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void radWizard1_Finish(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radWizard1_Next(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {

        }

        private void radWizard1_Previous(object sender, Telerik.WinControls.UI.WizardCancelEventArgs e)
        {

        }

        private void radWizard1_SelectedPageChanged(object sender, Telerik.WinControls.UI.SelectedPageChangedEventArgs e)
        {
            radWizard1.NextButton.Enabled = Models.Shares.IsNextEnabled;
            radWizard1.FinishButton.Enabled = Models.Shares.IsFinishEnabled;

            Models.Shares.ResetButtonEnables();

            radWizard1.PageHeaderTextVisibility = Telerik.WinControls.ElementVisibility.Collapsed;
            if (e.SelectedPage == radWizard1.Pages[0])
            {

            }
            else if (e.SelectedPage == radWizard1.Pages[1])
            {
                radWizard1.PageHeaderElement.Title = string.Format("ویزارد فعال سازی برنامه -> فعاسازی {0}", _faActivationType);
            }
            else if (e.SelectedPage == radWizard1.Pages[2])
            {
                radWizard1.PageHeaderElement.Title = string.Format("ویزارد فعال سازی برنامه -> فعاسازی {0}", _activationResultTitle);
            }
        }

        private void radWizard1_SelectedPageChanging(object sender, Telerik.WinControls.UI.SelectedPageChangingEventArgs e)
        {
            if (e.NextPage == radWizard1.Pages[0])
            {
                
            }
            else if (e.NextPage == radWizard1.Pages[1])
            {
                IActivationForm activatingUc = null;
                if (activationType1.SelectedActivationType == "Internet")
                {
                    activatingUc = new InternetActivation() { RightToLeft = System.Windows.Forms.RightToLeft.No };
                    _faActivationType = "اینترنتی";
                }
                else if (activationType1.SelectedActivationType == "Sms")
                {
                    activatingUc = new SmsActivation() { RightToLeft = System.Windows.Forms.RightToLeft.No };
                    _faActivationType = "پیامکی";
                }
                else
                {
                    activatingUc = new TelActivation();                   
                }
                
                var ctrl = activatingUc as Control;
                ctrl.Dock = DockStyle.Fill;
                pnlActivating.Controls.Clear();
                pnlActivating.Controls.Add(ctrl);
            }
            
        }

        private void radWizard1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_buttonsBound.Contains(e.Location)) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MovableWinFormBehavior.StartDragging(Handle);
            }
        }

        private void EnablingWizard_Load(object sender, EventArgs e)
        {
            int bottomMargin = 40, leftMargin = radWizard1.CancelButton.Size.Width * (int)4.5;
            _buttonsBound = new Rectangle(0, radWizard1.Height - bottomMargin, leftMargin, radWizard1.CancelButton.Size.Height); 
        }
    }
}
