using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Admin_EditTuyenDi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadControl();
        }
    }

    private void LoadControl()
    {
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
        string stringID = Request.QueryString["Id"] ?? "";
        if (stringID != "")
        {
            TuyenDi data = TuyenDi.TuyenDi_Single(stringID);
            if (data == null)
            {
                Response.Redirect("~/Admin/TuyenDi.aspx");
            }
            lbMaTuyen.Text = data.MaTuyen.ToString();
            txtBenDiBenDen.Text = data.BenDiBenDen;
            DropDownListThoiGian.SelectedValue = data.MaTG.ToString();
            DropDownListLoaiXe.SelectedValue = data.MaXe.ToString();
            txtGiaVe.Text = data.GiaVe.ToString();
            txtSoGheDat.Text = data.SoGheDat.ToString();
            txtPhuThu.Text = data.PhuThu;
            btReset.Visible = false;
        }
        else
        {
            btReset.Visible = true;
        }
    }

    private TuyenDi GetData()
    {
        TuyenDi data = null;
        if (lbMaTuyen.Text != "")
        {
            data = TuyenDi.TuyenDi_Single(lbMaTuyen.Text);
        }
        else
        {
            data = new TuyenDi();
        }
        data.BenDiBenDen = txtBenDiBenDen.Text;
        data.MaTG = Convert.ToInt32(DropDownListThoiGian.SelectedValue);
        data.MaXe = Convert.ToInt32(DropDownListLoaiXe.SelectedValue);
        data.GiaVe = Decimal.Parse(txtGiaVe.Text);
        data.SoGheDat = 0;
        data.PhuThu = txtPhuThu.Text;
        return data;
    }

    private void Reset()
    {
        txtBenDiBenDen.Text = "";
        txtGiaVe.Text = "";
        txtPhuThu.Text = "";
    }


    protected void btReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void btDangKy_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            bool result = false;
            TuyenDi data = GetData();
            if (data.MaTuyen > 0)
            {
                result = TuyenDi.TuyenDi_Update(data);
                if (result)
                {
                    Response.Redirect("~/Admin/TuyenDi.aspx");
                }
            }
            else
            {
                result = TuyenDi.TuyenDi_Add(data);
                if (result)
                {
                    Response.Redirect("~/Admin/TuyenDi.aspx");
                }
            }
        }
    }
}