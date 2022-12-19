using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SabaMediaLock.Utilities
{
    public static class Msg
    {
        public static DialogResult Show(string text, string header, MessageBoxButtons button, RadMessageIcon icon, Control parent = null, string themeName = "TelerikMetroBlue")
        {
            RadMessageBox.SetThemeName(themeName);
            return RadMessageBox.Show(parent, text, header, button, icon, MessageBoxDefaultButton.Button1,  RightToLeft.Yes);
        }

        public static void ShowCompleteForm(string msg, Control parent = null)
        {
            Show(msg, "تکمیل فرم", MessageBoxButtons.OK, RadMessageIcon.Exclamation, parent);
        }
    }
}
