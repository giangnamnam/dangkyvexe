﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Banggiave : System.Web.UI.Page
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
        RepeatervBangGiaVe.DataSource = TuyenDi.ListTuyenDi();
        RepeatervBangGiaVe.DataBind();
    }
}