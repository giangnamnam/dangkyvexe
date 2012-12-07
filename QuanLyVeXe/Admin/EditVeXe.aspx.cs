using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Admin_EditVeXe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTuyenDiTuyenDen();
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
        string bendibenden = DropDownListTuyenDiTuyenDen.SelectedItem.Text;
        string thoigian = DropDownListThoiGian.SelectedValue;
        string maxe = DropDownListLoaiXe.SelectedValue;
        int resultCount = 0;

        CaptchaControlDatVeAdmin.ValidateCaptcha(txtCapchaDangky.Text.Trim().ToLower());
        if (CaptchaControlDatVeAdmin.UserValidated)
        {
            if (Page.IsValid)
            {
                bool result = false;
                VeXe data = GetData();
                if (data.MaVe > 0)
                {
                    if (TuyenDi.TuyenDi_SelectWhereSoKhop(bendibenden, thoigian, maxe) != 0)
                    {
                        result = VeXe.Update(data);
                        if (result && resultCount > 0)
                        {
                            //Response.Redirect("~/Listvexe.aspx");
                            PanelThongTinVe.Visible = true;
                            lbSoLuongVeWhere.Visible = true;
                            resultCount = VeXe.VeXe_CountWhere(txtNgayThangXuatBen.Text, DropDownListThoiGian.SelectedValue.ToString(), DropDownListTuyenDiTuyenDen.SelectedValue.ToString(), DropDownListLoaiXe.SelectedValue.ToString());
                            // lbSoLuongVeWhere.Text = "<script>alert(" + resultCount+")</script>";
                            lbBenDiBenDen.Text = DropDownListTuyenDiTuyenDen.SelectedItem.Text;
                            lbNgayXuatBen.Text = data.NgayXuatBen.ToShortDateString().ToString();
                            lbThoiGian.Text = DropDownListThoiGian.SelectedItem.Text; ;
                            lbLoaiXe.Text = DropDownListLoaiXe.SelectedItem.Text;
                            lbSoLuongVeWhere.Text = "" + resultCount;
                            ResetForm();
                            lbTuyenDiTonTai.Text = "";
                            HyperLinkBangGiaVe.Text = "";
                            lbHetVe.Text = "";
                        }
                        else
                        {
                            lbHetVe.Text = "Chuyến đi quý khách vừa chọn đã hết vé.";
                        }
                    }
                    else
                    {
                        lbTuyenDiTonTai.Text = "Tuyến đi không tồn tại. Xin qúy khách vui lòng xem lại ";
                        HyperLinkBangGiaVe.Text = "bảng giá vé";
                        lbHetVe.Text = "";
                    }
                }
                else
                {
                    if (TuyenDi.TuyenDi_SelectWhereSoKhop(bendibenden, thoigian, maxe) != 0)
                    {
                        result = VeXe.Add(data);
                        if (result && resultCount > 0)
                        {
                            //Response.Redirect("~/Listvexe.aspx");
                            PanelThongTinVe.Visible = true;
                            lbSoLuongVeWhere.Visible = true;
                            resultCount = VeXe.VeXe_CountWhere(txtNgayThangXuatBen.Text, DropDownListThoiGian.SelectedValue.ToString(), DropDownListTuyenDiTuyenDen.SelectedValue.ToString(), DropDownListLoaiXe.SelectedValue.ToString());
                            // lbSoLuongVeWhere.Text = "<script>alert(" + resultCount+")</script>";
                            lbBenDiBenDen.Text = DropDownListTuyenDiTuyenDen.SelectedItem.Text;
                            lbNgayXuatBen.Text = data.NgayXuatBen.ToShortDateString().ToString();
                            lbThoiGian.Text = DropDownListThoiGian.SelectedItem.Text; ;
                            lbLoaiXe.Text = DropDownListLoaiXe.SelectedItem.Text;
                            lbSoLuongVeWhere.Text = "" + resultCount;
                            ResetForm();
                            lbTuyenDiTonTai.Text = "";
                            HyperLinkBangGiaVe.Text = "";
                            lbHetVe.Text = "";
                        }
                        else
                        {
                            lbHetVe.Text = "Chuyến đi quý khách vừa chọn đã hết vé.";
                        }
                    }
                    else
                    {
                        lbTuyenDiTonTai.Text = "Tuyến đi không tồn tại. Xin qúy khách vui lòng xem lại ";
                        HyperLinkBangGiaVe.Text = "bảng giá vé";
                        lbHetVe.Text = "";
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
        txtCapchaDangky.Text = "";
    }

}