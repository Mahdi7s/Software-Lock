using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;
using SabaSoftwareLock.Web.Models;
using Telerik.Web.UI;

namespace SabaSoftwareLock.Web.Admin
{
    public partial class Settings : System.Web.UI.Page
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var setting = _unitOfWork.SettingRep.GetSetting();
                txtPackageSerialPrice.Text = setting.PackageSerialPrice.ToString();

                if (setting.PriceDetails != null && setting.PriceDetails.Count() >= 0)
                {
                    var items = setting.PriceDetails.Select(x => new RadListBoxItem(x.From.ToString() + " + " + x.To.ToString() + " = " + x.Price.ToString()));
                    foreach (var im in items)
                    {
                        RadListBox1.Items.Add(im);
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var setting = _unitOfWork.SettingRep.GetSetting();
            if (RadioButton1.Checked)
            {
                setting.IsUsingSinglePrice = true;
                setting.PackageSerialPrice = decimal.Parse(txtPackageSerialPrice.Text);
            }
            else
            {
                setting.IsUsingSinglePrice = false;
                setting.PriceDetails.AddRange(RadListBox1.Items.Select(x =>
                {
                    var text = x.Text.Replace(" ", "");
                    var splits = text.Split('-', '=');
                    var price = new PriceDetail { From = int.Parse(splits[0]), To = int.Parse(splits[1]), Price = decimal.Parse(splits[2]) };
                    return price;
                }));
            }
            _unitOfWork.SettingRep.Update(setting);
            _unitOfWork.SaveChanges();

            Response.Redirect("~/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var item = txtFrom.Text + " - " + txtTo.Text + " = " + txtPrice.Text;
            RadListBox1.Items.Add(new RadListBoxItem(item));
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = RadioButton2.Checked;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Panel1.Visible = RadioButton2.Checked;
        }
    }
}