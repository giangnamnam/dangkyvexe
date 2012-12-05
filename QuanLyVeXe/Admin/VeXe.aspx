<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="VeXe.aspx.cs" Inherits="Admin_VeXe" %>

<%@ Register src="../Control/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="javscript/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="javscript/jquery-ui.js" type="text/javascript"></script>
    <script src="javscript/jquery-1.8.0.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <div>
            <p style="text-align:center; font-weight: bold; font-size: 150%; color: White;">QUẢN LÝ VÉ XE</p>
            <hr />
             <p>
                 &nbsp;<asp:Panel ID="PanelChuNang" runat="server">
                    <asp:Button ID="btThem" runat="server" Text="Add new" Height="32px" 
                        Width="114px" onclick="btThem_Click" />
                    <asp:Button ID="btXoa" runat="server" Text="Delete select" Height="32px" Width="113px" 
                        onclick="btXoa_Click" OnClientClick="return confirm('Are you renmove it slected?');" />
                    <asp:Button ID="btTimKiem" runat="server" Text="Search" Height="33px" 
                        Width="108px" onclick="btTimKiem_Click" />
                    <asp:Button ID="btThongKe" runat="server" Text="Thống kê" Height="33px" 
                        Width="111px" />
                    
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Report/ReportVexe.aspx" Target="_blank">[In Danh Sách]</asp:HyperLink>

                    <asp:Label ID="lbThongKe" runat="server" Text="9" CssClass="labelThongKe"></asp:Label>
                </asp:Panel>
            </p>

           <br/>
           <center>
            <asp:Panel ID="PanelTimKiem" runat="server" Visible="false">
                    

                    <asp:Label ID="Label1" runat="server" Text="Địa chỉ:"></asp:Label>
                    <asp:TextBox ID="txtDiaChi" runat="server" Height="16px" Width="227px"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Ngày xuất bến:"></asp:Label>
                    <asp:TextBox ID="txtNgayXuatBen" runat="server" Height="16px" Width="121px"></asp:TextBox>

         

                    <asp:Label ID="Label3" runat="server" Text="Thời gian:"></asp:Label>
                    <asp:TextBox ID="txtThoiGian" runat="server" Height="16px" Width="76px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Tuyến đi:"></asp:Label>
                    <asp:TextBox ID="txtBenDiDen" runat="server" Height="16px" Width="156px"></asp:TextBox>
                    

                    <asp:Button ID="btTimKiemThat" runat="server" Text="Search" 
                        onclick="btTimKiemThat_Click"/>
            </asp:Panel>
            
            </center>
        
      

             <p>
            <asp:Repeater ID="RepeaterVeXe" runat="server" 
                     onitemcommand="RepeaterVeXe_ItemCommand" >
                <HeaderTemplate>
                    <table class="list">
                    <tr style="background-color: #87CEEB;">
                        <th class="cid"><input type="checkbox" id="checkBoxAll"></th>
                        <th>Họ tên</th>
                        <th>Giới tính </th>
                        <th>Tuổi</th>
                        <th>Điạ chỉ</th>
                        <th>Số ĐT</th>
                        <th>Ngày xuất bến</th>
                        <th>Thời gian</th>
                        <th>Tuyến đi</th>
                        <th>Loại xe</th>
                        <th>Gía vé</th>
                        <th>Tên tài khoản</th>
                        <th>Status VX</th>
                        <th>Print</th>
                        <th>ID</th>
                    </tr>
                </HeaderTemplate>

                <ItemTemplate>
                     <tr class='<%#Container.ItemIndex % 2==0?"white":"xam"%>'>
                        <td><input type="checkbox" name="Id" value='<%#Eval("MaVe")%>'></td>
                        <td><a href='EditVeXe.aspx?Id=<%#Eval("MaVe")%>'><%#Eval("HoTen")%></a></td>
                        <td><%#Eval("GioiTinh")%></td>
                        <td><%#Eval("Tuoi")%></td>
                        <td><%#Eval("DiaChi")%></td>
                        <td><%#Eval("SoDT")%></td>
                        <td><%#Eval("NgayXuatBen", "{0:dd/MM/yyyy}")%></td>
                        <td><%#Eval("GioXuatBen")%></td>
                        <td><%#Eval("BenDiBenDen")%></td>
                        <td><%#Eval("KieuiXe")%></td>
                        <td><%#Eval("GiaVe","{0:0,000}")%>VNĐ</td>
                        <td><%#Eval("MaTKKH")%></td>
                        <td>
                             <asp:LinkButton ID="LinkButton1" runat="server" CommandName="VeXeUpdateStatus" CommandArgument='<%#Eval("MaVe")+"_"+Eval("TrangThaiVeXe")%>'  BorderStyle="None" CssClass='<%#Eval("TrangThaiVeXe").ToString()=="False"?"cross":"tick" %>'></asp:LinkButton>
                        </td>

                         <td>
                             <asp:LinkButton ID="LinkButton2" runat="server" CommandName="VeXeUpdateStatusPrint" CommandArgument='<%#Eval("MaVe")+"_"+Eval("Printt")%>'  BorderStyle="None" CssClass='<%#Eval("Printt").ToString()=="False"?"cross":"print" %>'></asp:LinkButton>
                        </td>
                       
                        <td style="text-align:center"><%#Eval("MaVe") %></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </p>
        <p>
            &nbsp;<uc1:Pager ID="PagerButtonVeXe" runat="server" />
      </div>
    
</asp:Content>

