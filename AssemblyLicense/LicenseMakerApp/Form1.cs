using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using AssemblyLicense.ExeInfoCatcher;
using AssemblyLicense.Model;
using AssemblyLicense.Provider;

namespace LicenseMakerApp
{
    public partial class Form1 : Form
    {
        private SignedExeInfo _signedExeInfo;
        private string[] _assemblies;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectAssemblies_Click(object sender, EventArgs e)
        {
            _assemblies = GetFilesName();
        }

        private string[] GetFilesName()
        {
            using(var openDlg = new OpenFileDialog(){ Multiselect = true})
            {
                if(openDlg.ShowDialog() == DialogResult.OK)
                {
                    return openDlg.FileNames;
                }
            }
            return null;
        }

        private void btnSelectExe_Click(object sender, EventArgs e)
        {
            _signedExeInfo = new SignedExeInfo(Assembly.LoadFrom(GetFilesName().First()));
        }

        private void btnMakeLix_Click(object sender, EventArgs e)
        {            
            string destinationPath = Application.StartupPath;
            LicenseFileMaker.CreateLicenseFile(_signedExeInfo, destinationPath,
                                               _assemblies.Select(x => Assembly.LoadFrom(x).FullName).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _signedExeInfo = Catcher.GetSignedExeInfo(GetFilesName().First());
        }
    }
}
