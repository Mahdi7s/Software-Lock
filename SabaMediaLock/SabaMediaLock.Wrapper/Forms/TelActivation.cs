using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SabaMediaLock.Wrapper.Forms
{
    public partial class TelActivation : UserControl, IActivationForm
    {
        public TelActivation()
        {
            InitializeComponent();
        }

        public Action<bool, string> ActivationCallback
        {
            get;
            set;
        }
    }
}
