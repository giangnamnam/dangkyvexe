<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditTuyenDi.aspx.cs" Inherits="Admin_EditTuyenDi" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
       .style1
       {
           text-align: right;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <p style="text-align:center; font-weight: bold; font-size: 150%; color: White;">CẬP NHẬT THÔNG TIN TUYẾN ĐI</p>
        <hr />


        <p>
            <table border="0" width="50%" cellspacing="10">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbMaTuyen" runat="server" Text="" Visible="false"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                            <p style="text-align:center;color: Red;font-weight:bold;"><asp:Label ID="Label4" runat="server" Text="Label">Vui lòng điền đầy đủ thông tin tuyến đi.</asp:Label></p>
                                           
                                    </tr>
                                    <tr>
                                        <td class="style1">  
                                               <asp:Label ID="Label1" runat="server">Bến đi <=> Bến đến: </asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBenDiBenDen" runat="server" Width="247px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBenDiBenDen" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="txtBenDiBenDen"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label2" runat="server" Text="Thời gian: "></asp:Label>
                                        </td>
                                        <td>
                                             <asp:DropDownList ID="DropDownListThoiGian" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">---Thời gian---</asp:ListItem>
                                            </asp:DropDownList>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="DropDownListThoiGian"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Tuoi" runat="server" Text="Loại xe: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListLoaiXe" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">---Loại xe---</asp:ListItem>
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="DropDownListLoaiXe"></asp:RequiredFieldValidator>
                                        

                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label5" runat="server" Text="Giá vé: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGiaVe" runat="server" Width="89px" Height="16px"></asp:TextBox>
                                        </td>
                                    </tr>

                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label6" runat="server" Text="Số ghế đặt: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSoGheDat" runat="server" Width="89px" Height="16px" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>


                                     <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label3" runat="server" Text="Phụ thu: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhuThu" runat="server" Width="89px" Height="16px"></asp:TextBox>
                                        </td>
                                    </tr>



                                 

                                    <tr>
                                        <td></td>
                                        <td style="padding-left:50px;">

                                            <asp:Button ID="btDangKy" runat="server" Text="Add new" BorderStyle="Dashed" 
                                                Font-Bold="True" ForeColor="#000066" Height="25px" Width="75px" 
                                                onclick="btDangKy_Click"/>

                                            <asp:Button ID="btReset" runat="server" Text="Reset" BorderStyle="Dashed" 
                                                Font-Bold="True" ForeColor="#000066" Height="25px" Width="75px" 
                                                onclick="btReset_Click" /> 
                                        </td>
                                    </tr>
                                </table>
        </p>
    </div>
</asp:Content>

