using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;
using System.Data;
using System.Data.Entity;
using SoftwareSerial.Model;
using Telerik.Web.UI;
using System.IO;
using OfficeOpenXml;

namespace SabaSoftwareLock.Web.Lock
{
    public partial class Report : System.Web.UI.Page
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = _unitOfWork.MemberRep.GetCurrent();
                if (user != null)
                {
                    ddlSoftName.Items.AddRange(user.SoftwareInfoes.Select(x => new RadComboBoxItem(x.SoftwareName, x.SoftwareInfoId.ToString())).ToArray());
                }
            }
        }

        private IEnumerable<UserSerial> ListDataSource
        {
            get
            {
                IEnumerable<UserSerial> retval = null;
                int softwareInfoId;
                if (!int.TryParse(ddlSoftName.SelectedValue, out softwareInfoId))
                {
                    pnlPager.Enabled = false;
                    return retval;
                }
                else pnlPager.Enabled = true;

                if ((!ddlCategory.SelectedValue.Equals("LastEnablingState")) && String.IsNullOrEmpty(txtKey.Text))
                {
                    retval = _unitOfWork.UserSerialRep.Get(filter: x => x.SerialTrackingCode.SoftwareInfoId.Equals(softwareInfoId), includeProperties: "SerialTrackingCode, UserSerialState, SerialTrackingCode.SoftwareInfo, PackageSerial");
                }
                else
                {
                    var searchKey = ddlCategory.SelectedValue.Equals("LastEnablingState") ? cmbCurrentState.SelectedValue : txtKey.Text;
                    retval = _unitOfWork.UserSerialRep.Search(ddlCategory.SelectedValue, searchKey).Include("SerialTrackingCode").Include("SerialTrackingCode.SoftwareInfo").Include("PackageSerial").Where(x => x.SerialTrackingCode.SoftwareInfoId.Equals(softwareInfoId));
                }

                if (retval.Count() > 0)
                {
                    var pagesCount = (int)Math.Ceiling((double)retval.Count()/RadListView1.PageSize);

                    btnFirstPage.Text = "1";
                    btnLastPage.Text = pagesCount.ToString();

                    btnFirstPage.Enabled = true;
                    btnLastPage.Enabled = pagesCount > 1;

                    txtGoToPage.MinValue = 1; 
                    txtGoToPage.MaxValue = pagesCount;
                }
                else
                {
                    btnFirstPage.Text = btnLastPage.Text = string.Empty;

                    pnlPager.Enabled = btnFirstPage.Enabled = btnLastPage.Enabled = false;
                }
                retval = retval.Skip((CurrentPage - 1) * RadListView1.PageSize).Take(RadListView1.PageSize).ToList();                
                return retval;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlSoftName.SelectedItem != null)
            {
                CurrentPage = 1;
                RadListView1.Rebind();
            }
        }

        protected void btnPrev_Click(object sender, ImageClickEventArgs e)
        {
            if (CurrentPage-- <= 1)
            {
                CurrentPage = 1;
                return;
            }

            RadListView1.Rebind();
        }

        protected void btnNext_Click(object sender, ImageClickEventArgs e)
        {
            ++CurrentPage;
            if (ListDataSource != null && ListDataSource.Any())
            {
                RadListView1.Rebind();
            }
            else --CurrentPage;
        }

        private int CurrentPage
        {
            get { return int.Parse(lblCurrPage.Text); }
            set
            {
                if (value >= txtGoToPage.MinValue && value <= txtGoToPage.MaxValue)
                {
                    lblCurrPage.Text = value.ToString();
                    txtGoToPage.Value = value;
                }
            }
        }

        protected void RadListView1_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            RadListView1.DataSource = ListDataSource;
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            int page;
            if (int.TryParse(btnLastPage.Text, out page))
            {
                CurrentPage = page;

                RadListView1.Rebind();
            }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;

            RadListView1.Rebind();
        }

        protected void btnGoTo_Click(object sender, ImageClickEventArgs e)
        {
            if (txtGoToPage.Value.HasValue)
            {
                CurrentPage = (int)txtGoToPage.Value.Value;
                RadListView1.Rebind();
            }
        }

        protected void btnExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Lock Report");
                worksheet.View.RightToLeft = true;

                // Headers 
                worksheet.Cells[1, 1].Value = "سریال روی بسته";
                worksheet.Cells[1, 2].Value = "وضعیت فعلی";
                worksheet.Cells[1, 3].Value = "دفعات استفاده";
                worksheet.Cells[1, 4].Value = "حداکثر دفعات استفاده";
                worksheet.Cells[1, 5].Value = "نام نرم افزار";
                worksheet.Cells[1, 6].Value = "نام مختصر نرم افزار";

                // Data
                var currRow = 2;
                foreach (var userSerial in ListDataSource)
                {
                    worksheet.Cells[currRow, 1].Value = userSerial.PackageSerial.Serial;
                    worksheet.Cells[currRow, 2].Value = userSerial.UserSerialState.LastEnablingState;
                    worksheet.Cells[currRow, 3].Value = userSerial.UsedCount;
                    worksheet.Cells[currRow, 4].Value = userSerial.SerialTrackingCode.SerialUsingCount;
                    worksheet.Cells[currRow, 5].Value = userSerial.SerialTrackingCode.SoftwareInfo.SoftwareName;
                    worksheet.Cells[currRow, 6].Value = userSerial.SerialTrackingCode.SoftwareInfo.SoftwareUniqueName;

                    ++currRow;
                }

                worksheet.Cells.AutoFitColumns(0); // Auto Fit All Columns !


                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", "attachment;filename=report.xlsx");
                Response.Charset = "utf-8";

                package.SaveAs(Response.OutputStream);

                Response.End();
            }
        }
    }

    public class MyComparer : EqualityComparer<ListItem>
    {
        public override bool Equals(ListItem x, ListItem y)
        {
            return !string.IsNullOrEmpty(x.Text) && !string.IsNullOrEmpty(y.Text) && x.Text.Equals(y.Text, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode(ListItem obj)
        {
            obj.Text = obj.Text ?? string.Empty;

            return obj.Text.GetHashCode();
        }
    }
}