using System;
using System.Drawing;
using SabaMediaLock.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Contracts;
using Telerik.WinControls.UI;
using TS7S.Base;

namespace SabaMediaLock.Wrapper.Forms
{
    public partial class ActivationType : UserControl
    {
        public ActivationType()
        {
            InitializeComponent();
        }

        public string SelectedActivationType
        {
            get{ return tableLayoutPanel2.Controls.OfType<RadRadioButton>().First(x=>x.IsChecked).Name.Substring(2);}
        }

        private void ActivationType_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            LockSetteings.Settings.DefaultFormsSettings.Where(x => x.FormType == Contracts.FormType.ActivationType)
                .Apply(x => x.Items.Apply(i => {
                    if (i.ItemType == ItemType.Form)
                    {
                        switch (i.PropertyName)
                        {
                            case "پس زمینه":
                                this.BackgroundImage = FileUtils.LoadWizImg(i.PropertyValue) ?? BackgroundImage;
                                break;
                        }
                    }
                    else if (i.ItemType == ItemType.RadioButton)
                    {
                        switch (i.PropertyName)
                        {
                            case "متن":
                                switch (i.ItemName)
                                {
                                    case "فعال سازی پیامکی": rbSms.Text = i.PropertyValue; break;
                                    case "فعال سازی اینترنتی": rbInternet.Text = i.PropertyValue; break;
                                    case "فعال سازی تلفنی": rbTel.Text = i.PropertyValue; break;
                                }
                                break;
                        }
                    }
                }));
        }

        private void rbTel_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }
    }
}
