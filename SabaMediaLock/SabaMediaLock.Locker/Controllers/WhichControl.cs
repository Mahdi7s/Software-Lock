using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using TS7S.Base;

namespace SabaMediaLock.Locker.Controllers
{
    public enum ControlType { Blank, FileAddress, Text }
    public partial class WhichControl : UserControl
    {
        private ControlType _controlType = ControlType.Blank;
        private IWich _wich;

        public WhichControl()
        {
            InitializeComponent();
        }

        public void ApplyTheme(string theme)
        {
            foreach (var ctrl in panel1.Controls)
                if (ctrl is RadControl)
                    ((RadControl)ctrl).ThemeName = theme;
        }

        public ControlType ControlType
        {
            get { return _controlType; }
            set
            {
                _controlType = value;
                OnControlTypeChanged();
            }
        }

        public string WhichValue
        {
            get { return _wich.WichValue; }
            set { _wich.WichValue = value; }
        }

        private void OnControlTypeChanged()
        {
            switch (_controlType)
            {
                case Controllers.ControlType.Text:
                    DisplayControl(new WichText());
                    break;
                case Controllers.ControlType.FileAddress:
                    DisplayControl(new WichFileAddress());
                    break;
                default:
                    this.Controls.Clear();
                    break;
            }
        }

        private void DisplayControl(Control ctrl)
        {
            ctrl.Dock = DockStyle.Fill;
            _wich = (IWich)ctrl;
            panel1.Controls.Clear();
            panel1.Controls.Add(ctrl);
        }
    }
}
