using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;

namespace SabaSoftwareLock.Web.Admin
{
    public partial class Members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            using (var uof = new UnitOfWork())
            {
                RadGrid1.DataSource = uof.MemberRep.GetAll(); //.Skip(RadGrid1.CurrentPageIndex*RadGrid1.PageSize).Take(RadGrid1.PageSize);
            }
        }

        protected void RadGrid1_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            txtEncPass.Text = txtSmplPass.Text.ToSha();
        }
    }
}