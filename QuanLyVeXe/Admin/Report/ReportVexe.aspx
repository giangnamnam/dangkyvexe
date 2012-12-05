<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportVexe.aspx.cs" Inherits="Admin_Report_ReportVexe" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <rsweb:ReportViewer ID="ReportViewerVeXe" runat="server"  Width="1350px" 
            Height="670px" Font-Names="Verdana" Font-Size="8pt" 
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Admin\ReportVeXe.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DangKyVeXeFix1ConnectionString %>" 
            SelectCommand="SELECT VeXe.HoTen, VeXe.GioiTinh, VeXe.Tuoi, VeXe.DiaChi, VeXe.SoDT, VeXe.NgayXuatBen, ThoiGian.GioXuatBen, TuyenDi.BenDiBenDen, LoaiXe.KieuiXe, TuyenDi.GiaVe FROM VeXe INNER JOIN ThoiGian ON VeXe.MaTG = ThoiGian.MaTG INNER JOIN TuyenDi ON VeXe.MaTuyen = TuyenDi.MaTuyen INNER JOIN LoaiXe ON VeXe.MaXe = LoaiXe.MaXe WHERE (VeXe.Printt = 'True')">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
