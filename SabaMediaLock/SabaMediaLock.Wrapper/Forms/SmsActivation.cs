using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftwareSerial.Client;
using TS7S.Base;
using TS7S.Base.Threading;
using SabaMediaLock.Contracts;
using SabaMediaLock.Utilities;
using System.Diagnostics;

namespace SabaMediaLock.Wrapper.Forms
{
    public partial class SmsActivation : UserControl, IActivationForm
    {
        public SmsActivation()
        {
            InitializeComponent();
            StyleUp();

            Models.Shares.IsNextEnabled = false;
            ActivationCallback = Models.Shares.SmsActivationCallback;

            TempSerial = SoftwareSerial.Client.SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate(LockSetteings.Settings.SoftwareUniqueName);
        }

        public string TempSerial
        {
            get { return txtTempSerial.Text; }
            set { txtTempSerial.Text = value; }
        }

        public Action<bool, string> ActivationCallback
        {
            get; set;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ThreadHelper.RunAsync(() =>
            {
                if (SoftwareSerial.Client.SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate(LockSetteings.Settings.SoftwareUniqueName, TempSerial, txtEnablingSerial.Text))
                {
                    SoftwareSerial.Client.SoftwareSerialClient.Shared.RegistryManager.InitializeRegValue(Hardware.CPU, LockSetteings.Settings.Password, "1");
                    return true;
                }
                return false;
            }, (x) =>
                {
                    ActivationCallback(x.Result, x.Error != null ? x.Error.Message : null);
                    Models.Shares.Wizard.SelectNextPage();
                });
        }

        private void txtEnablingSerial_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtEnablingSerial_TextChanged(object sender, EventArgs e)
        {
            radButton1.Enabled = !string.IsNullOrWhiteSpace(txtEnablingSerial.Text);
        }

        private void SmsActivation_Load(object sender, EventArgs e)
        {
            
        }

        private void StyleUp()
        {
            LockSetteings.Settings.DefaultFormsSettings.Where(x => x.FormType == Contracts.FormType.SmsActivation).SelectMany(x => x.Items).Apply(i =>
            {
                if (i.ItemType == ItemType.Form)
                {
                    switch (i.PropertyName)
                    {
                        case "پس زمینه":
                            this.BackgroundImage = FileUtils.LoadWizImg(i.PropertyValue) ?? BackgroundImage;
                            break;
                    }
                }
                if (i.ItemType == ItemType.Button)
                {
                    switch (i.PropertyName)
                    {
                        case "متن":
                            radButton1.Text = i.PropertyValue;
                            break;
                        case "عکس":
                            radButton1.Image = FileUtils.LoadWizImg(i.PropertyValue) ?? radButton1.Image;
                            break;
                    }
                }
            });
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPackageSerial_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPackageSerial.Text))
            {
                lblToSendMsg.Text = string.Empty;
                return;
            }

            lblToSendMsg.Text = string.Format("{0}#{1}#{2}", txtPackageSerial.Text, txtTempSerial.Text, LockSetteings.Settings.SoftwareUniqueName);
        }
    }
}
