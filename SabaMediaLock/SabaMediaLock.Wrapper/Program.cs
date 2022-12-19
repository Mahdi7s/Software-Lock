using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SabaMediaLock.Utilities.Localizations;
using Telerik.WinControls;

namespace SabaMediaLock.Wrapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AssemblyLicense.ExeInfoCatcher.Catcher.Catch();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageBoxLoc();
            LockSetteings.LoadSettings();
            
            Application.Run(new MainForm());
        }
    }
}
