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
    public partial class WichFileAddress : UserControl, IWich
    {
        public WichFileAddress()
        {
            InitializeComponent();

            DShare.OnThemeChanging += (s, e) =>
            {
                radButton1.ThemeName = radTextBox1.ThemeName = (string)s;
            };
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                radTextBox1.Text = openFileDialog1.FileName;
            }
        }

        public string WichValue
        {
            get { return radTextBox1.Text; }
            set { radTextBox1.Text = value; }
        }

        public object Others
        {
            get { return openFileDialog1.Filter; }
            set { openFileDialog1.Filter = (string)value; }
        }
    }
}
