using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AssemblyLicense.License;
using LicensedAssembly;

namespace LicensedAssemblyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var testClass = new AClassOfALicensedAsm();
            //testClass.CanYouUseThisMethod();
            //var tst2 = new AnotherClassOfALicensedAsm();
            try
            {
                var atts = typeof (AClassOfALicensedAsm).Assembly.GetCustomAttributes(
                    typeof (LicensedAssemblyAttribute), false);
            }
            catch
            {
                
            }
        }
    }
}
