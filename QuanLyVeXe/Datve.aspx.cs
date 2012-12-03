using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Web.Security;

public partial class Datve : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTuyenDiTuyenDen();
        }
        if (User.Identity.Name != "")
        {
            pnDangKyVe.Visible = true;
            HyperLinkDangKy.Visible = false;
            Label10.Visible = false;
            HyperLinkDangNhap.Visible = false;

            MembershipUser m = Membership.GetUser(User.Identity.Name);
            lbUsername.Text = "" + m.UserName.ToString();
        }
        if (User.Identity.Name == "")
        {
            lbThongBaoStatus.Text = "Khách hàng phải có tài khoản mới đăng ký vé xe được";
            lbThongBaoStatus1.Text = "Chúc quý khác có một ngày may mắn";

        }
    }
    private void LoadTuyenDiTuyenDen()
    {
        DropDownListTuyenDiTuyenDen.DataValueField = "MaTuyen";
        DropDownListTuyenDiTuyenDen.DataTextField = "BenDiBenDen";
        DropDownListTuyenDiTuyenDen.DataSource = TuyenDi.ListTuyenDi();
        DropDownListTuyenDiTuyenDen.DataBind();

        //
        DropDownListLoaiXe.DataValueField = "MaXe";
        DropDownListLoaiXe.DataTextField = "KieuiXe";
        DropDownListLoaiXe.DataSource = LoaiXe.LoaiXe_DropDownList();
        DropDownListLoaiXe.DataBind();

        //
        DropDownListThoiGian.DataValueField = "MaTG";
        DropDownListThoiGian.DataTextField = "GioXuatBen";
        DropDownListThoiGian.DataSource = ThoiGian.ThoiGian_DropDownList();
        DropDownListThoiGian.DataBind();


        //
        string stringId = Request.QueryString["Id"] ?? "";
        if (stringId != "")
        {
            //Lay ve xe theo ID
            VeXe data = VeXe.VeXe_Single(stringId);
            if (data == null)
            {
                Response.Redirect("~/Datve.aspx");
            }
            //Dua du lieu vao fomr de cap nhat
            lbMaVe.Text = data.MaVe.ToString();
            txtHoVaTen.Text = data.HoTen;
            //string gt = "";
            if (data.GioiTinh == "Nam")
            {
                RadioButtonNam.Checked = true;
            }
            else
            {
                RadioButtonNu.Checked = true;
            }
            //gt = data.GioiTinh;
            txtTuoi.Text = data.Tuoi.ToString();
            txtDiaChi.Text = data.DiaChi;
            txtSoDT.Text = data.SoDT;
            txtNgayThangXuatBen.Text = data.NgayXuatBen.ToShortDateString();
            CheckBoxTrangThaiVeXe.Checked = data.TrangThaiVeXe;
            DropDownListThoiGian.SelectedValue = data.MaTG.ToString();
            DropDownListTuyenDiTuyenDen.SelectedValue = data.MaTuyen.ToString();
            DropDownListLoaiXe.SelectedValue = data.MaXe.ToString();
            lbUsername.Text = data.MaTKKH;
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //btDangKy.Click+=new EventHandler(btDangKy_Click);
    }
    //Lay du lieu de cap nhat
    private VeXe GetData()
    {
        VeXe data = null;
        if (lbMaVe.Text != "")
        {
            data = VeXe.VeXe_Single(lbMaVe.Text);
        }
        else
        {
            data = new VeXe();
        }
        data.HoTen = txtHoVaTen.Text;
        string gt = "";
        if (RadioButtonNam.Checked)
        {
            gt = "Nam";
        }
        else
        {
            gt = "Nữ";
        }
        data.GioiTinh = gt;
        data.Tuoi = int.Parse(txtTuoi.Text);
        data.DiaChi = txtDiaChi.Text;
        data.SoDT = txtSoDT.Text;
        data.NgayXuatBen = DateTime.Parse(txtNgayThangXuatBen.Text);
        data.TrangThaiVeXe = CheckBoxTrangThaiVeXe.Checked;
        data.MaTG = Convert.ToInt32(DropDownListThoiGian.SelectedValue);
        data.MaTuyen = Convert.ToInt32(DropDownListTuyenDiTuyenDen.SelectedValue);
        data.MaXe = Convert.ToInt32(DropDownListLoaiXe.SelectedValue);
        data.MaTKKH = lbUsername.Text;
        return data;

    }
    protected void btDangKy_Click(object sender, EventArgs e)
    {
        CaptchaControlDatVe.ValidateCaptcha(txtCapchaDangky.Text.Trim().ToLower());
        if (CaptchaControlDatVe.UserValidated)
        {
            if (Page.IsValid)
            {
                bool result = false;
                VeXe data = GetData();
                if (data.MaVe > 0)
                {
                    result = VeXe.Update(data);
                    if (result)
                    {
                        Response.Redirect("~/Listvexe.aspx");
                    }
                }
                else
                {
                    result = VeXe.Add(data);
                    if (result)
                    {
                        Response.Redirect("~/Listvexe.aspx");
                    }
                }
            }
        }
        else
        {
            lbResult.Text = "Nhập sai mã bảo vệ";
        }
    }

    //ResetForm
    private void ResetForm()
    {
        txtHoVaTen.Text = "";
        RadioButtonNam.Checked = true;
        txtTuoi.Text = "";
        txtDiaChi.Text = "";
        txtSoDT.Text = "";
        txtNgayThangXuatBen.Text = "";
        CheckBoxTrangThaiVeXe.Checked = false;
        DropDownListThoiGian.SelectedValue = "0";
        DropDownListLoaiXe.SelectedValue = "0";
        DropDownListTuyenDiTuyenDen.SelectedValue = "0";
    }
}