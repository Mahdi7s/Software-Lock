using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;
using SoftwareSerial.Model;
using SoftwareSerial.Server;
using Telerik.Web.UI;

namespace SabaSoftwareLock.Web.Lock
{
    public partial class CreatePackageSerial : System.Web.UI.Page
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SoftwareSerial.DataModel.UnitOfWork.Initialize(_unitOfWork);
                var user = _unitOfWork.MemberRep.GetCurrent();
                if (user != null)
                {
                    lblCharge.Text = user.Charge.ToString();
                    cmbSoftName.DataSource = user.SoftwareInfoes.ToList();
                    cmbSoftName.DataBind();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label7.Visible = lblTrackingCode.Visible = false;

            var count = int.Parse(txtCount.Text);
            var usingCount = int.Parse(txtUsingCount.Text);
            if (cmbSoftName.SelectedItem == null)
            {
                CustomValidator1.ErrorMessage = "لطفا نام نرم افزار را انتخاب نمایید.";
                CustomValidator1.IsValid = false;
                return;
            }
            if (txtSerialLen.Value < 4 || txtSerialLen.Value > 24)
            {
                return;
            }

            var softInfo = _unitOfWork.SoftwareInfoRep.GetByID(int.Parse(cmbSoftName.SelectedValue));
            var softUniqName = softInfo.SoftwareUniqueName;

            decimal packSerialPrice;
            var canCount = CheckCharge(count, usingCount, out packSerialPrice);
            if (canCount > 0)
            {
                if (canCount < count)
                {
                    CustomValidator1.ErrorMessage = string.Format("شما می توانید حداکثر {0} سریال تولید کنید.", canCount);
                    CustomValidator1.IsValid = false;
                    return;
                }

                SerialTrackingCode trackingCode;
                int serialLen = int.Parse(txtSerialLen.Text);

                var packageManager = new PackageSerialManager();
                var serials = packageManager.GenerateSerials(softUniqName, usingCount, count, out trackingCode, serialLen, () => { return true; });

                if (string.IsNullOrEmpty(trackingCode.SoftwareInfo.SoftwareUniqueName))
                {
                    trackingCode.SoftwareInfo.SoftwareUniqueName = trackingCode.SoftwareInfo.SoftwareInfoId.ToString().ToBase36();
                    _unitOfWork.SoftwareInfoRep.Update(trackingCode.SoftwareInfo);
                    _unitOfWork.SaveChanges();
                }

                var user = _unitOfWork.MemberRep.GetCurrent();
                if (user != null)
                {
                    user.Charge -= (count * packSerialPrice);
                    lblCharge.Text = user.Charge.ToString();

                    _unitOfWork.SaveChanges();
                }

                lblTrackingCode.Text = trackingCode.SerialTrackingCodeId.ToString();
                Label7.Visible = lblTrackingCode.Visible = true;

                RadListView1.DataSource = serials;
                RadListView1.DataBind();
            }
            else
            {
                CustomValidator1.ErrorMessage = "شارژ شما برای تولید سریال کافی نیست";
                CustomValidator1.IsValid = false;
            }
        }

        private int CheckCharge(int count, int usingCount, out decimal packSerialPrice)
        {
            using (var uof = new UnitOfWork())
            {
                var setting = uof.SettingRep.GetSetting();
                packSerialPrice = setting.PackageSerialPrice;
                var userCharge = uof.MemberRep.GetCurrent().Charge;

                if (!setting.IsUsingSinglePrice)
                {
                    var priceDetail = setting.PriceDetails.FirstOrDefault(x => x.From <= count && x.To >= count);
                    if (priceDetail != null)
                    {
                        packSerialPrice = priceDetail.Price;
                    }
                    else
                    {
                        return -1;
                    }
                }

                if (userCharge < (decimal)packSerialPrice)
                {
                    return -1;
                }
                if (packSerialPrice <= 0) return -1;
                return (int)(userCharge / (decimal)(packSerialPrice*usingCount));
            }
        }
    }
}