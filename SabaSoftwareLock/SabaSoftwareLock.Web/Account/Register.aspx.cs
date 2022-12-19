using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Web.Security;
using SabaSoftwareLock.Model;
using SabaSoftwareLock.DataModel;

namespace SabaSoftwareLock.Web.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                CustomValidator1.ErrorMessage = ex.Message;
                CustomValidator1.IsValid = false;
            }
        }
    }
}