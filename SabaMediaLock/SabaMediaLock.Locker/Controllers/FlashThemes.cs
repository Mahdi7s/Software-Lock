using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using SabaMediaLock.Locker.Models;
using Telerik.WinControls;

namespace SabaMediaLock.Locker.Controllers
{
    public partial class FlashThemes : UserControl
    {
        public FlashThemes()
        {
            InitializeComponent();
            DShare.GeneralSettings = this;

            ThemeResolutionService.ApplyThemeToControlTree(this, "TelerikMetroBlue");
        }

        private void txtWindowHeight_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
        }

        private void txtWindowHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || ((int)e.KeyChar) == 8)
                e.Handled = false;
            else e.Handled = true;
        }

        private void btnBrowseResouceDir_Click(object sender, EventArgs e)
        {
            BrowseResouceDir();
        }

        public bool BrowseResouceDir()
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtResourcesPath.Text = folderBrowserDialog1.SelectedPath;
                return true;
            }
            return false;
        }

        private void cbEncryptFlash_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            btnBrowseResouceDir.Enabled = (cbEncryptResources.Checked);            
        }
    }
}