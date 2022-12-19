using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;
using SabaSoftwareLock.Model;

namespace SabaSoftwareLock.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            if (!IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    Response.Redirect("~/Lock/Report.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var mp = new Membership.UserMembershipProvider();
            if (mp.ValidateUser(txtLUserName.Text, txtLPasssword.Text))
            {
                HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                {
                    FormsAuthentication.RedirectFromLoginPage(txtLUserName.Text, cbRememberMe.Checked);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(txtLUserName.Text, cbRememberMe.Checked);
                    Response.Redirect("~/Lock/Report.aspx");
                }
            }
            else
            {
                logCustomValidator.ErrorMessage = "نام کاربری یا رمز عبور خود را اشتباه وارد کرده اید.";
                logCustomValidator.IsValid = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                using (var uof = new UnitOfWork())
                {
                    var roleKind = uof.MemberRep.GetAll().Any(x => x.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase)) ? RoleKind.User : RoleKind.Admin;
                    var user = new Member { FirstName = txtName.Text, LastName = txtLastName.Text, UserName = txtUserName.Text, Password = txtPassword.Text, RoleEnum = roleKind, IsOnline = true };
                    uof.MemberRep.Insert(user);
                    uof.SaveChanges();
                }
                HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
                FormsAuthentication.SetAuthCookie(txtUserName.Text, false);
                Response.Redirect("~/Lock/Report.aspx");
            }
            catch (Exception ex)
            {
                regCustomValidator.ErrorMessage = ex.Message;
                regCustomValidator.IsValid = false;
            }
        }
    }
}