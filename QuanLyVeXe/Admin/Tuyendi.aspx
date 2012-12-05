<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Tuyendi.aspx.cs" Inherits="Admin_Tuyendi" %>

<%@ Register src="../Control/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <p style="text-align:center; font-weight: bold; font-size: 150%; color: White;">QUẢN LÝ TUYẾN ĐI</p>
        <hr />
         <p>
             &nbsp;<asp:Panel ID="PanelChucNang" runat="server">
                <asp:Button ID="btThem" runat="server" Text="Add new " Width="118px" 
                    Height="30px" onclick="btThem_Click" />
                <asp:Button ID="btXoa" runat="server" Text="Delete select" Width="112px" 
                    Height="30px" onclick="btXoa_Click" OnClientClick="return confirm('Are you renmove it slected?');" />
                 <asp:Button ID="btTimKiem" runat="server" Text="Search" Width="112px"
                    Height="30px" onclick="btTimKiem_Click" />
                <asp:Button ID="btThongKe" runat="server" Text="Thống kê" Width="112px"
                    Height="29px" />

                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Report/ReportTuyendi.aspx" Target="_blank">[In Danh Sách]</asp:HyperLink>
           

               <asp:Label ID="lbThongKe" runat="server" Text="9" CssClass="labelThongKe"></asp:Label>
            </asp:Panel>

        </p>

        
         <br/>
        <center>
            <asp:Panel ID="PanelTimKiem" runat="server" Visible="false">
                    <asp:Label ID="Label1" runat="server" Text="Bến đi bến đến: "></asp:Label>
                    <asp:TextBox ID="txtBenDiBenDen" runat="server" Height="16px" Width="227px"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Thời gian: "></asp:Label>
                    <asp:TextBox ID="txtThoiGian" runat="server" Height="16px" Width="82px"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Loại xe: "></asp:Label>
                    <asp:TextBox ID="txtLoaiXe" runat="server" Height="16px" Width="76px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Giá vé: "></asp:Label>
                    <asp:TextBox ID="txtGiaVe" runat="server" Height="16px"></asp:TextBox>
                    <asp:Button ID="btTimKiemThat" runat="server" Text="Search" 
                        onclick="btTimKiemThat_Click"/>
            </asp:Panel>
            
        </center>


        <p>
            <asp:Repeater ID="RepeaterTuyenDi" runat="server" 
                onitemcommand="RepeaterTuyenDi_ItemCommand" >
                <HeaderTemplate>
                    <table class="list">
                    <tr style="background-color: #87CEEB;">
                        <th class="cid"><input type="checkbox" id="checkBoxAll"></th>
                        <th>Bến đi <=> Bến đến</th>
                        <th>Thời gian </th>
                        <th>Loại xe</th>
                        <th>Giá vé</th>
                        <th>Số ghế đặt</th>
                        <th>Phụ thu</th>
                        <th>Print</th>
                        <th>ID</th>
                    </tr>
                </HeaderTemplate>

                <ItemTemplate>
                      <tr class='<%#Container.ItemIndex % 2==0?"white":"xam"%>'>
                        <td><input type="checkbox" name="Id" value='<%#Eval("MaTuyen")%>'></td>
                        <td><a href='EditTuyenDi.aspx?Id=<%#Eval("MaTuyen")%>'><%#Eval("BenDiBenDen")%></a></td>
                        <td><%#Eval("GioXuatBen")%></td>
                        <td><%#Eval("KieuiXe")%></td>
                        <td><%#Eval("GiaVe")%></td>
                        <td><%#Eval("SoGheDat")%></td>
                        <td><%#Eval("PhuThu")%></td>
                         <td>
                             <asp:LinkButton ID="LinkButton1" runat="server" CommandName="TuyenDiUpdateStatus" CommandArgument='<%#Eval("MaTuyen")+"_"+Eval("Printt")%>'  BorderStyle="None" CssClass='<%#Eval("Printt").ToString()=="False"?"cross":"print" %>'></asp:LinkButton>
                        </td>
                        <td style="text-align:center"><%#Eval("MaTuyen")%></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </p>
            <uc1:Pager ID="PagerButtonTuyenDi" runat="server" />
        <p>
            
        </p>
    </div>
</asp:Content>

