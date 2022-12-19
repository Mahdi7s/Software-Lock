using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Wrapper.Forms;

namespace SabaMediaLock.Wrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Choose Activation Type Form":
                    DisplayForm(new ActivationType());
                    break;
                case "Enabling Serial Form":
                    DisplayForm(new EnablingSoftware());
                    break;
                case "Temprary Serial Form":
                    //DisplayForm(new TempSerial());
                    break;
                case "Activation Succeeded Form":
                    DisplayForm(new ActivationSucceeded());
                    break;
                case "Activation Faild Form":
                    DisplayForm(new ActivationFailed());
                    break;
                case "Internet Activation Form":
                    DisplayForm(new InternetActivation());
                    break;
            }
        }

        private void DisplayForm(Control form)
        {
            form.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
        }
    }
}
