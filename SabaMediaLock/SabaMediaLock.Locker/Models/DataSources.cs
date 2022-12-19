using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using Telerik.WinControls.UI;
using TS7S.Base.IO;
using System.IO;

namespace SabaMediaLock.Locker.Models
{
    [Serializable]
    public class GridRowData
    {
        [Browsable(false)]
        public int Id { get; set; }

        [DisplayName("نام فرم")]
        public string Form { get; set; }
        [Browsable(false)]
        public string FormKey { get; set; }

        [DisplayName("نام آیتم")]
        public string Item { get; set; }
        [Browsable(false)]
        public string ItemKey { get; set; }
        [Browsable(false)]
        public string ItemType { get; set; }

        [DisplayName("نام صفت")]
        public string Property { get; set; }
        [Browsable(false)]
        public string PropertyKey { get; set; }

        [DisplayName("مقدار")]
        public string Value { get; set; }
        [Browsable(false)]
        public string ValueKey { get; set; }
    }

    public class DataSources
    {
        private int _rowsCount = 0;
        private readonly RadGridView _gridView;

        private readonly string _wizThemePath = Path.Combine(Path.GetDirectoryName(typeof(DataSources).Assembly.Location), "WizTheme.dat");

        public DataSources(RadGridView gridView)
        {
            _gridView = gridView;
            GridDataSource = new List<GridRowData>();

            Forms = new List<Tuple<string, string>>(new[] { 
                    new {k = "ActivationSucceeded", v="فعال سازی موفق"},
                    new {k = "ActivationFailed", v="فعال سازی نا موفق"},
                    new {k="SmsActivation", v="فعال سازی پیامکی"},
                    new {k="InternetActivation", v="فعال سازی اینترنتی"},
                    new {k="ActivationType", v="شیوه فعال سازی"},
                }.Select(x => new Tuple<string, string>(x.k, x.v)));

            FormItems = new List<Tuple<string, string, string>>(new[]{

                    new {v="استایل کلی", dp="ActivationSucceeded", t = "Form"},
                    new {v="متن", dp="ActivationSucceeded", t = "Text"},                   

                    new {v="استایل کلی", dp="ActivationFailed", t = "Form"},
                    new {v="متن", dp="ActivationFailed", t = "Text"},
                    //new {v="نمایش اطلاعات بیشتر", dp="ActivationFailed", t="Button"},

                    new {v="استایل کلی", dp="SmsActivation", t = "Form"},
                    new {v="دکمه فعال سازی", dp="SmsActivation", t="Button"},

                    new {v="استایل کلی", dp="InternetActivation", t = "Form"},
                    new {v="دکمه فعال سازی", dp="InternetActivation", t="Button"},

                    new {v="استایل کلی", dp="ActivationType", t = "Form"},
                    new{v="فعال سازی پیامکی",dp="ActivationType", t="RadioButton"},
                    new{v="فعال سازی اینترنتی",dp="ActivationType",t="RadioButton"},
                    //new{v="فعال سازی تلفنی",dp="ActivationType",t="RadioButton"}

                }.Select(x => new Tuple<string, string, string>(x.dp, x.t, x.v)));

            Properties = new List<Tuple<string, string>>(new[]{
                    new{t="Form", p="پس زمینه"},

                    new{t="Text", p="متن"},

                    new{t="Button", p ="متن"},
                    new{t="Button", p="عکس"},

                    new{t="RadioButton", p= "متن"}
                }.Select(x => new Tuple<string, string>(x.t, x.p)));
        }

        public List<Tuple<string, string>> Forms { get; set; }
        public List<Tuple<string, string, string>> FormItems { get; set; }
        public List<Tuple<string, string>> Properties { get; set; }

        public List<GridRowData> GridDataSource { get; set; }

        public bool AddRow(GridRowData row)
        {
            if (!GridDataSource.Any(x => x.Form.Equals(row.Form) && x.FormKey.Equals(row.FormKey) && x.ItemKey.Equals(row.ItemKey) && x.Property.Equals(row.Property)))
            {
                row.Id = _rowsCount++;
                GridDataSource.Add(row);
                _gridView.DataSource = GridDataSource;

                return true;
            }
            return false;
        }

        public void Load()
        {
            if (File.Exists(_wizThemePath))
            {
                GridDataSource = ObjectSerializer<List<GridRowData>>.DeserializeBinary(_wizThemePath);
                _gridView.DataSource = GridDataSource;
            }
        }

        public void Save()
        {
            ObjectSerializer<List<GridRowData>>.SerializeBinary(_wizThemePath, GridDataSource, FileMode.Create);
        }

        public void DeleteRow(GridViewRowInfo row)
        {
            GridDataSource = GridDataSource.Where(x => !x.Id.Equals(((GridRowData)row.DataBoundItem).Id)).ToList();
            _gridView.DataSource = GridDataSource.ToList();
        }

        public IEnumerable<Tuple<string, string, string>> GetFormItems(string parentVal)
        {
            return this.FormItems.Where(x => x.Item1.Equals(parentVal)).ToList();
        }

        public IEnumerable<Tuple<string, string>> GetProperties(string itemType)
        {
            return this.Properties.Where(x => x.Item1.Equals(itemType)).ToList();
        }
    }
}
