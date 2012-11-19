using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Datve : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTuyenDiTuyenDen();
        }
        if(User.Identity.Name!="")
        {
            pnDangKyVe.Visible = true;
            HyperLinkDangKy.Visible = false;
            Label10.Visible = false;
            HyperLinkDangNhap.Visible = false;
        }
        if (User.Identity.Name == "")
        {
            lbThongBaoStatus.Text = "Khách hàng phải có tài khoản mới đăng ký vé xe được";
            lbThongBaoStatus1.Text= "Chúc quý khác có một ngày may mắn";
            
        }
    }
    private void LoadTuyenDiTuyenDen()
    {
        DropDownListTuyenDiTuyenDen.DataValueField = "MaTuyen";
        DropDownListTuyenDiTuyenDen.DataTextField = "BenDi";
        DropDownListTuyenDiTuyenDen.DataSource = TuyenDi.ListTuyenDi();
        DropDownListTuyenDiTuyenDen.DataBind();
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //btDangKy.Click+=new EventHandler(btDangKy_Click);
    }
    protected void btDangKy_Click(object sender, EventArgs e)
    {
        CaptchaControlDatVe.ValidateCaptcha(txtCapchaDangky.Text.Trim().ToLower());
        if (CaptchaControlDatVe.UserValidated)
        {
            lbResult.Text = "True";
        }
        else
        {
            lbResult.Text = "False";
        }
    }
}