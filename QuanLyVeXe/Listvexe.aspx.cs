using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DAL;

public partial class Listvexe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //   LoadControl();
        }
        if (User.Identity.Name != "")
        {
            MembershipUser m = Membership.GetUser(User.Identity.Name);
            lbAcountDangNhap.Text = "" + m.UserName.ToString();
            LoadControl();
        }
    }
    private void LoadControl()
    {
        RepeaterListVeXe.DataSource = VeXe.VeXe_SlectAcountKH(lbAcountDangNhap.Text);
        RepeaterListVeXe.DataBind();
    }
    protected void btDelte_Click(object sender, EventArgs e)
    {
        string stringId = Request.Form["Id"] ?? "";
        if (stringId != "")
        {
            foreach (string item in stringId.Split(','))
            {
                VeXe.Delete(item);
                LoadControl();
            }
        }
    }
}