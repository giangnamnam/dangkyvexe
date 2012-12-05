<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Lienhe.aspx.cs" Inherits="Admin_Lienhe" %>

<%@ Register src="../Control/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <p style="text-align:center; font-weight: bold; font-size: 150%; color: White;">QUẢN LÝ LIÊN HỆ</p>
        <hr />
        <p>
            <asp:Panel ID="PanelChucNang" runat="server">
                <asp:Button ID="btXoaLienHe" runat="server" Text="Delete select " Width="118px" 
                    Height="30px" onclick="btXoaLienHe_Click" OnClientClick="return confirm('Are you renmove it slected?');" />
                <asp:Button ID="btThongKe" runat="server" Text="Thống kê" Width="112px" 
                    Height="30px" />
               
               <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Report/ReprotLienHe.aspx" Target="_blank">[In Danh Sách]</asp:HyperLink>

               <asp:Label ID="lbThongKe" runat="server" Text="9" CssClass="labelThongKe"></asp:Label>
            </asp:Panel>
           

        &nbsp;</p>

       

        <p>
            <asp:Repeater ID="RepeaterLienHe" runat="server" 
                onitemcommand="RepeaterLienHe_ItemCommand" >
                <HeaderTemplate>
                    <table class="list">
                    <tr style="background-color: #87CEEB;">
                        
                        <th class="cid"><input type="checkbox"></th>
                        <th>Họ tên</th>
                        <th>Địa chỉ</th>
                        <th>Email</th>
                        <th>Điện thoại</th>
                        <th>Tiêu đề</th>
                        <th>Nội dung</th>
                        <th>Print</th>
                        <th>ID</th>
                    </tr>
                </HeaderTemplate>

                <ItemTemplate>
                     <tr class='<%#Container.ItemIndex % 2==0?"white":"xam"%>'>
                       <!-- <td><%#Container.ItemIndex +1%></td>-->
                        <td><input type="checkbox" value='<%#Eval("MaLH")%>' name="Id" ></td>
                        <td><%#Eval("HoTen")%></td>
                        <td><%#Eval("DiaChi")%></td>
                        <td><%#Eval("Email")%></td>
                        <td><%#Eval("DienThoai")%></td>
                        <td><%#Eval("TieuDe")%></td>
                        <td style="text-align:left;"><%#Eval("NoiDung")%></td>
                          <td>
                             <asp:LinkButton ID="LinkButton1" runat="server" CommandName="LienHeUpdateStatus" CommandArgument='<%#Eval("MaLH")+"_"+Eval("Printt")%>'  BorderStyle="None" CssClass='<%#Eval("Printt").ToString()=="False"?"cross":"print" %>'></asp:LinkButton>
                        </td>
                        <td><%#Eval("MaLH")%></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
             <uc1:Pager ID="PagerButtonLienHe" runat="server" />
    </div>
</asp:Content>

