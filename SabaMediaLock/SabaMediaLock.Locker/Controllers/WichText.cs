using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Locker.Models;

namespace SabaMediaLock.Locker.Controllers
{
    public partial class WichText : UserControl, IWich
    {
        public WichText()
        {
            InitializeComponent();

            DShare.OnThemeChanging += (s, e) =>
            {
                radTextBox1.ThemeName = (string)s;
            };
        }

        public string WichValue
        {
            get { return radTextBox1.Text; }
            set { radTextBox1.Text = value; }
        }


        public dynamic Others
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
