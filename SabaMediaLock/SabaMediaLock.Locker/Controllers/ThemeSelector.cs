using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SabaMediaLock.Locker.Models;

namespace SabaMediaLock.Locker.Controllers
{
    public partial class ThemeSelector : UserControl
    {
        private List<RadToggleButton> Buttons = new List<RadToggleButton>();
        private int _stylesChangedCount = 0;

        public ThemeSelector()
        {
            InitializeComponent();

            foreach (var btn in tableLayoutPanel1.Controls)
            {
                if(btn is RadToggleButton)
                {
                    var btnC = (RadToggleButton)btn;
                    Buttons.Add(btnC);
                    btnC.Click += btn_Click;
                }
            }
        }

        public Panel ParentPanel { get; set; }
        public UserControl UcToTheming { get; set; }

        private void btn_Click(object sender, EventArgs e)
        {
            var button = ((RadToggleButton)sender);
            var name = button.Name;
            
            foreach (var btn in Buttons)
            {
                if (btn.Name != name)
                    btn.IsChecked = false;
            }

            //((dynamic)UcToTheming).ApplyTheme(button.ThemeName);
            DShare.ThemeChanging(button.ThemeName);
            SetStyle(ParentPanel, button.ThemeName);
        }

        private void SetStyle(Panel pnl, string styleName)
        {
            foreach (var item in pnl.Controls)
            {
                if (item is RadControl)
                {
                    ((RadControl)item).ThemeName = styleName;
                }
                else if (item is Panel)
                {
                    SetStyle((Panel)item, styleName);
                }
            }
        }

        public string SelectedTheme
        {
            get
            {
                var btn = Buttons.FirstOrDefault(x => x.IsChecked);
                if (string.IsNullOrEmpty(btn.Name)) return null;
                return btn.ThemeName;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        public event EventHandler OnStylesLoaded = delegate{ };
        private void btnBreeze_StyleChanged(object sender, EventArgs e)
        {
            if (++_stylesChangedCount >= 11)
            {
                OnStylesLoaded(this, EventArgs.Empty);
            }
        }
    }
}
