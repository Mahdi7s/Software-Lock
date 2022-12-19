using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SabaMediaLock.Utilities
{
    public partial class BusyIndicator : UserControl
    {
        public BusyIndicator()
        {
            InitializeComponent();
        }

        public Image BusyImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public new void Show()
        {
            Location = new Point(Parent.Width / 2 - this.Width / 2, Parent.Height / 2 - this.Height / 2);
            pictureBox1.Visible = true;
        }

        public new void Hide()
        {
            pictureBox1.Visible = false;
        }
    }
}
