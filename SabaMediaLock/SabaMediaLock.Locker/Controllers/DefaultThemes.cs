using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using SabaMediaLock.Locker.Models;
using Telerik.WinControls.UI;
using TS7S.Base.Threading;
using System.Threading;
using SabaMediaLock.Utilities;

namespace SabaMediaLock.Locker.Controllers
{
    public partial class DefaultThemes : UserControl
    {
        private readonly DataSources _dataSources;
        private RadWizard _radWizard = null;
        

        public DefaultThemes()
        {
            InitializeComponent();            
            themeSelector1.ParentPanel = tableLayoutPanel1;
            themeSelector1.UcToTheming = whichControl1;

            _dataSources = new DataSources(radGridView1);
            _dataSources.Load();

            radGridView1.DataSource = _dataSources.GridDataSource;
            ddlWhichForm.DataSource = _dataSources.Forms;

            CheckNextEnablity();
        }
        public ProcessingForm PForm { get; set; }
        public RadWizard Wizard
        {
            get { return _radWizard; }
            set
            {
                _radWizard = value;
                _radWizard.SelectedPageChanged += _radWizard_SelectedPageChanged;
            }
        }

        private void _radWizard_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.SelectedPage == _radWizard.Pages[1])
            {
                CheckNextEnablity();
                PForm.GridDatas = GridDatas;                
            }
            else if (e.SelectedPage == _radWizard.Pages[2])
            {
                _dataSources.Save();
            }
        }

        public bool UseDefaultTheme { get; set; }
        public List<GridRowData> GridDatas { get { return _dataSources.GridDataSource; } }
        public string SelectedTheme { get; set; }

        private void radGridView1_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            //btnDel.Enabled =  radGridView1.SelectedRows.Count > 0;
        }

        private void ddlWhichForm_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (e.Position >= 0)
            {
                var ds = _dataSources.GetFormItems(((Tuple<string, string>)ddlWhichForm.Items[e.Position].Value).Item1);
                ddlItem.DataSource = ds;
                if (ddlItem.DataSource == null || ds.Count() <= 0)
                {
                    EmptyCombo(ddlItem);
                    EmptyCombo(ddlProp);
                    whichControl1.WhichValue = null;
                }
            }
            else
            {
                EmptyCombo(ddlItem);
                EmptyCombo(ddlProp);
                whichControl1.WhichValue = null;
            }
        }

        private void ddlItem_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (e.Position >= 0)
            {
                var ds = _dataSources.GetProperties(((Tuple<string, string, string>)ddlItem.Items[e.Position].Value).Item2);
                ddlProp.DataSource = ds;
                if (ddlProp.DataSource == null || ds.Count() <= 0)
                {
                    EmptyCombo(ddlProp);
                    whichControl1.WhichValue = null;
                }
            }
            else
            {
                EmptyCombo(ddlProp);
                whichControl1.WhichValue = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlItem.SelectedItem != null && ddlWhichForm.SelectedItem != null && ddlProp.SelectedItem != null && !string.IsNullOrEmpty(whichControl1.WhichValue))
            {
                var form = ddlWhichForm.SelectedValue as Tuple<string, string>;
                var item = ddlItem.SelectedValue as Tuple<string,string,string>;
                var prop = ddlProp.SelectedValue as Tuple<string, string>;

                if (_dataSources.AddRow(new GridRowData { Form = form.Item2, FormKey = form.Item1, Item = item.Item3, ItemType = item.Item2, ItemKey = item.Item1, Property = prop.Item2, PropertyKey = prop.Item1, Value = whichControl1.WhichValue }))
                {
                    radGridView1.DataSource = _dataSources.GridDataSource.ToList();

                    CheckNextEnablity();
                }
            }
            else
            {
                RadMessageBox.Show(this, "لطفا تمام فیلدها را پر کنید.", "اخطار", MessageBoxButtons.OK , RadMessageIcon.Exclamation);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var selectedRow = radGridView1.SelectedRows.FirstOrDefault();
            if (selectedRow != null)
            {
                _dataSources.DeleteRow(selectedRow);

                CheckNextEnablity();
            }
        }

        private void EmptyCombo(RadDropDownList ddl)
        {
            var dm = ddl.DisplayMember;
            var vm = ddl.ValueMember;
            ddl.DataSource = null;
            ddl.DisplayMember = dm;
            ddl.ValueMember = vm;
        }

        private void CheckNextEnablity()
        {
            //if(Wizard != null)
            //Wizard.NextButton.Enabled = (_dataSources.GridDataSource != null && _dataSources.GridDataSource.Any());
        }

        private void DefaultThemes_Load(object sender, EventArgs e)
        {
            var bi = new BusyIndicator { Parent = PForm };
            this.Controls.Add(bi);
            
            bi.Show();
            radPanel1.Visible = tableLayoutPanel1.Visible = true;
        }

        private void themeSelector1_Load(object sender, EventArgs e)
        {
            radPanel1.Visible = true;
        }

        private void themeSelector1_OnStylesLoaded(object sender, EventArgs e)
        {
            radPanel1.Visible = true;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ddlProp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(ddlProp.SelectedItem == null) return;
            var prop = (string)ddlProp.SelectedItem.DisplayValue;
            switch (prop)
            {
                case "پس زمینه":
                case "عکس":
                    whichControl1.ControlType = ControlType.FileAddress;
                    break;
                case "متن":
                    whichControl1.ControlType = ControlType.Text;
                    break;
            }
        }
    }
}
