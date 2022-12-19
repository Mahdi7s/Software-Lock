using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftwareSerial.Client;
using TS7S.Base.Threading;
using SabaMediaLock.Contracts;
using SabaMediaLock.Utilities;
using TS7S.Base;

namespace SabaMediaLock.Wrapper.Forms
{
    public partial class InternetActivation : UserControl, IActivationForm
    {
        public InternetActivation()
        {
            InitializeComponent();
            StyleUp();

            Models.Shares.IsNextEnabled = false;
            ActivationCallback = Models.Shares.InternetActivationCallback;
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            btnActivate.Enabled = false;
            pnlConnectingAndActivating.Visible = true;

            ThreadHelper.RunAsync<bool>(() =>
            {
                    var tempSerial = SoftwareSerial.Client.SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate(LockSetteings.Settings.SoftwareUniqueName);
                    var res = SoftwareSerial.Client.SoftwareSerialClient.Shared.ValidateSerial(LockSetteings.Settings.SoftwareUniqueName, txtPackageSerial.Text, tempSerial);

                    if (res.Validation == SoftwareSerial.Model.UserSerialValidationResult.IsValid)
                    {
                        if (SoftwareSerial.Client.SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate(LockSetteings.Settings.SoftwareUniqueName, tempSerial, res.EnablingSerial))
                        {
                            SoftwareSerial.Client.SoftwareSerialClient.Shared.RegistryManager.InitializeRegValue(Hardware.CPU, LockSetteings.Settings.Password, "1");
                            return true;
                        }
                    }
                return false;
            }, (aRes) =>
            {
                ActivationCallback(aRes.Result, aRes.Error != null ? aRes.Error.Message : string.Empty);
                pnlConnectingAndActivating.Visible = false;
                Models.Shares.Wizard.SelectNextPage();
            });
        }

        public Action<bool, string> ActivationCallback
        {
            get;
            set;
        }

        private void txtPackageSerial_TextChanged(object sender, EventArgs e)
        {
            btnActivate.Enabled = !string.IsNullOrWhiteSpace(txtPackageSerial.Text);
        }

        private void InternetActivation_Load(object sender, EventArgs e)
        {
            
        }

        private void StyleUp()
        {
            LockSetteings.Settings.DefaultFormsSettings.Where(x => x.FormType == Contracts.FormType.InternetActivation).SelectMany(x => x.Items).Apply(i =>
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
                            btnActivate.Text = i.PropertyValue;
                            break;
                        case "عکس":
                            btnActivate.Image = FileUtils.LoadWizImg(i.PropertyValue) ?? btnActivate.Image;
                            break;
                    }
                }
            });
        }
    }
}
