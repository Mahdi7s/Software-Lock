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
    public partial class ActivationSucceeded : UserControl
    {
        public ActivationSucceeded()
        {
            InitializeComponent();
        }

        private void ActivationSucceeded_Load(object sender, EventArgs e)
        {
            LockSetteings.Settings.DefaultFormsSettings.Where(x => x.FormType == Contracts.FormType.ActivationSucceeded)
    .Apply(x => x.Items.Apply(i =>
    {
        if (i.ItemType == ItemType.Form)
        {
            switch (i.PropertyName)
            {
                case "پس زمینه":
                    this.BackgroundImage = FileUtils.LoadWizImg(i.PropertyValue)??BackgroundImage;
                    break;
            }
        }
        else if (i.ItemType == ItemType.Text)
        {
            switch (i.PropertyName)
            {
                case "متن":
                    lblText.Text = i.PropertyValue;
                    break;
            }
        }
    }));
        }
    }
}
