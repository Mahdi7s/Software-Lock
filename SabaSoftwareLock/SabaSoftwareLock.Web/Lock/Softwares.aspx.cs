using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;
using SoftwareSerial.Model;
using SoftwareSerial.Server;

namespace SabaSoftwareLock.Web.Lock
{
    public partial class Softwares : System.Web.UI.Page
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            var mem = _unitOfWork.MemberRep.GetCurrent();
            if (mem != null)
            {
                RadGrid1.DataSource = mem.SoftwareInfoes.ToList();
            }
        }

        protected void btnApply_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoftName.Text))
            {
                RadNotification1.Title = "تکمیل فرم";
                RadNotification1.Text = "نام کامل برنامه را وارد نمایید.";
                RadNotification1.Show();

                return;
            }

            var softInfo = GetSelectedSoftwareInfo();
            if (softInfo != null)
            {
                _unitOfWork.SoftwareInfoRep.Attach(softInfo);
                if (IsSoftUniqNameValid(txtSoftUniqueName.Text, softInfo))
                {
                    softInfo.SoftwareName = txtSoftName.Text;
                    softInfo.SoftwareUniqueName = txtSoftUniqueName.Text;

                    _unitOfWork.SoftwareInfoRep.Update(softInfo);
                    _unitOfWork.SaveChanges();

                    txtSoftName.Text = txtSoftUniqueName.Text = string.Empty;
                    RadGrid1.Rebind();
                }
                else
                {
                    RadNotification1.Title = "تکمیل فرم";
                    RadNotification1.Text = "نام مختصر وارد شده منحصر به فرد نمی باشد.";
                    RadNotification1.Show(); 
                }
            }
            else
            {
                RadNotification1.Title = "ویرایش";
                RadNotification1.Text = "لطفا ردیفی که می خواهید ویرایش کنید را انتخاب کنید";
                RadNotification1.Show();
            }
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            var softInfo = GetSelectedSoftwareInfo();
            if (softInfo != null)
            {
                var mem = _unitOfWork.MemberRep.GetCurrent();
                if (!mem.SoftwareInfoes.Any(x => x.SoftwareInfoId.Equals(softInfo.SoftwareInfoId))) return;

                softInfo = _unitOfWork.SoftwareInfoRep.GetByID(softInfo.SoftwareInfoId);
                if (!softInfo.SerialTrackingCodes.Any())
                {
                    _unitOfWork.SoftwareInfoRep.Delete(softInfo);
                    _unitOfWork.SaveChanges();

                    txtSoftName.Text = txtSoftUniqueName.Text = string.Empty;

                    RadGrid1.Rebind();
                }
                else
                {
                    delNotification.Show();
                }                
            }
        }

        private SoftwareInfo GetSelectedSoftwareInfo()
        {
            if (RadGrid1.SelectedItems != null && RadGrid1.SelectedItems.Count > 0)
            {
                var selectedRow = RadGrid1.SelectedItems[0];
                var item = RadGrid1.MasterTableView.Items[selectedRow.ItemIndex];

                return new SoftwareInfo { SoftwareInfoId = int.Parse(item["SoftwareInfoId"].Text), SoftwareName = item["SoftwareName"].Text, SoftwareUniqueName = item["SoftwareUniqueName"].Text };
            }
            return null;
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoftName.Text))
            {
                RadNotification1.Title = "تکمیل فرم";
                RadNotification1.Text = "نام کامل برنامه را وارد نمایید.";
                RadNotification1.Show();

                return;
            }

            if (!IsSoftNameValid(txtSoftName.Text))
            {
                RadNotification1.Title = "اخطار";
                RadNotification1.Text = "نام نرم افزار وارد شده وجود دارد.";
                RadNotification1.Show();

                return;
            }

            InsertSoftware();

            txtSoftName.Text = txtSoftUniqueName.Text = string.Empty;

            RadGrid1.Rebind();
        }

        private void InsertSoftware()
        {
            var mem = _unitOfWork.MemberRep.GetCurrent();
            var nSoftINfo = new SoftwareInfo { SoftwareName = txtSoftName.Text, /*SoftwareUniqueName = txtSoftUniqueName.Text*/ };
            mem.SoftwareInfoes.Add(nSoftINfo);
            if (!string.IsNullOrWhiteSpace(nSoftINfo.SoftwareUniqueName))
            {
                if (IsSoftUniqNameValid(nSoftINfo.SoftwareUniqueName))
                {
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    RadNotification1.Title = "تکمیل فرم";
                    RadNotification1.Text = "نام مختصر وارد شده منحصر به فرد نمی باشد.";
                    RadNotification1.Show();
                }
            }
            else
            {
                _unitOfWork.SaveChanges();
                SetAndSaveUniqueName(nSoftINfo);
            }
        }

        private bool IsSoftUniqNameValid(string softUniqName, SoftwareInfo softInfo = null)
        {
            softInfo = softInfo ?? GetSelectedSoftwareInfo();
            var retval = ((softInfo != null && softInfo.SoftwareUniqueName.Equals(softUniqName)) || (!string.IsNullOrWhiteSpace(softUniqName) && !_unitOfWork.SoftwareInfoRep.GetAll().Any(x => x.SoftwareUniqueName.Equals(softUniqName))));

            if (!retval)
            {
                RadNotification1.Title = "اخطار";
                RadNotification1.Text = "نام مختصر وارد شده معتبر نمی باشد.";
                RadNotification1.Show();
            }
            return retval;
        }

        /// <summary>
        /// checks the software name is ok for current user
        /// </summary>
        /// <param name="softName"></param>
        /// <returns></returns>
        private bool IsSoftNameValid(string softName)
        {
            var mem = _unitOfWork.MemberRep.GetCurrent();
            return !string.IsNullOrWhiteSpace(softName) && !mem.SoftwareInfoes.Any(x => x.SoftwareName.Equals(softName));
        }


        /// <summary>
        /// save softInfo before calling this method
        /// </summary>
        /// <param name="softInfo"></param>
        private void SetAndSaveUniqueName(SoftwareInfo softInfo)
        {
            if (string.IsNullOrWhiteSpace(softInfo.SoftwareUniqueName))
            {
                softInfo.SoftwareUniqueName = softInfo.SoftwareInfoId.ToString().ToBase36();
                _unitOfWork.SoftwareInfoRep.Update(softInfo);
                _unitOfWork.SaveChanges();
            }
        }

        protected void btnValidateUniqName_Click(object sender, ImageClickEventArgs e)
        {
            if (IsSoftUniqNameValid(txtSoftUniqueName.Text))
            {
                txtSoftUniqueName.CssClass = "validName";
            }
            else
            {
                txtSoftUniqueName.CssClass = "invalidName";
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            var softInfo = GetSelectedSoftwareInfo();
            if (softInfo != null)
            {
                var toDel = _unitOfWork.SoftwareInfoRep.GetForDeleteByID(softInfo.SoftwareInfoId);
                _unitOfWork.SoftwareInfoRep.DeleteWithAllSerials(toDel);
                _unitOfWork.SaveChanges();

                RadGrid1.Rebind();
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {

        }
    }
}