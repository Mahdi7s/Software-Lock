using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace SabaSoftwareLock.Web.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var mp = new Membership.UserMembershipProvider();
            if (mp.ValidateUser(txtUserName.Text, txtPasssword.Text))
            {
                HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, cbRememberMe.Checked);
            }
            else
            {
                CustomValidator1.ErrorMessage = "نام کاربری یا رمز عبور خود را اشتباه وارد کرده اید.";
                CustomValidator1.IsValid = false;
            }
        }
    }
}