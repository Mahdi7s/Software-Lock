using System;
using SabaMediaLock.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Contracts;
using TS7S.Base;

namespace SabaMediaLock.Wrapper.Forms
{
    //For SMS Enabling...

    public partial class EnablingSoftware : UserControl
    {
        public EnablingSoftware()
        {
            InitializeComponent();
        }

        private void EnablingSoftware_Load(object sender, EventArgs e)
        {
            LockSetteings.Settings.DefaultFormsSettings.Where(x => x.FormType == Contracts.FormType.EnablingSoftware)
    .Apply(x => x.Items.Apply(i =>
    {
        if (i.ItemType == ItemType.Form)
        {
            switch (i.PropertyName)
            {
                case "پس زمینه":
                    this.BackgroundImage = FileUtils.LoadImage(i.PropertyValue);
                    break;
            }
        }
    }));
        }
    }
}
