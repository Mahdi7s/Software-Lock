using System;
using System.Windows.Forms;
using SoftwareSerial.Client;
using SoftwareSerial.Client.SerialServiceReference;
using SoftwareSerial.Contracts;
using SoftwareSerial.DataModel;
using SoftwareSerial.Server;

namespace SoftwareSerialClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbSerialLen.SelectedIndex = 0;
            cmbSerialLen.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblHardwareSerial.Text = SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate("softwareName");            
            var tempSerial = SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate("softwareName");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var serialLen = cmbSerialLen.SelectedItem == "26" ? SerialLengthEnum.Len26 : SerialLengthEnum.Len13;

            SoftwareSerialClient.Initialize(txtWcfAddress.Text, "mySoftware", serialLen, "password", Hardware.CPU, Hardware.HardDisk);
            SoftwareSerialServer.Initialize(nameOrConnectionString: "SoftwareSerialDbConStr",
                                           dbInitializationType: DbInitializationType.CreateIfNotExists, password: "password");
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            var valRes =
                SoftwareSerialClient.Shared.ValidateSerial(txtSoftName.Text, txtPackageSerial.Text, lblHardwareSerial.Text);
            var retval = valRes.Validation.ToString();

            if(valRes.Validation == SoftwareSerial.Model.UserSerialValidationResult.IsValid)
            {
                if(SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate(txtSoftName.Text, lblHardwareSerial.Text, valRes.EnablingSerial))
                {
                    retval = "Your App Is Activated Successfuly.";
                }
                //else
                //{
                //    retval = "Are you a hacker ?!";
                //}
                
            }
            lblSerialValidationState.Text = retval; // only when this is "Your App Is Activated Successfuly." this is correct.
        }

        void tst()
        {
            var valdationRes = SoftwareSerialClient.Shared.ValidateSerial("softwareName", "packageSerial", tempSerial);
            if (valdationRes.Validation == SoftwareSerial.Model.UserSerialValidationResult.IsValid)
            {
                if(SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate("softwareName", tempSerial, valdationRes.EnablingSerial))
                {
                    // Your Application is Activated Successfuly
                    // save in registery
                    SoftwareSerialClient.Shared.RegistryManager.InitializeRegValue(Hardware.CPU, "password", "packageName");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // You should use the commented codes in server side for sms validation...

            //if (SoftwareSerialServer.Shared.ValidateUserSerial(txtPackageSerial.Text, lblHardwareSerial.Text) == UserSerialValidationResult.IsValid)
            //{
                txtGenerateEnablingSerial.Text =
                    SoftwareSerialServer.Shared.AutoEnablingSerialMaker.Generate(txtSoftName.Text, lblHardwareSerial.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Sms to his/her mobile!: a thing is not correct!");
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblSmsValidation.Text =
                SoftwareSerialClient.Shared.AutoEnablingSerialValidtor.Validate(txtSoftName.Text,lblHardwareSerial.Text,
                                                                                txtGenerateEnablingSerial.Text.ToUpper()).ToString();
        }
    }
}
