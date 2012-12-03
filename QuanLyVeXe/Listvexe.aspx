<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.master" AutoEventWireup="true" CodeFile="Listvexe.aspx.cs" Inherits="Listvexe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .chu
        {
            border-bottom:1px solid #CCC;
           font-weight:bold;
            color: #555;
        }
        .chu1
        {
           border-bottom:1px solid #CCC; 
          color: #555;
        }
        tr
        {
            display: table-row;
            vertical-align: inherit;
            border-color: inherit;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="section">
                    <div class="tag-title-wrap clearfix">
                        <h4 class="tag-title">
                            DANH SÁCH VÉ XE ĐĂNG KÝ</h4>
                    </div>

                    <ul class="columns-2 clearfix">
                        <li class="col2">
                            <div class="testimonial-wrapper clearfix">
         <p>
                <asp:Label ID="lbAcountDangNhap" runat="server" Text="" Visible="false"></asp:Label>  
         <center>
                       
               <%--  <asp:Label ID="Label2" runat="server" Text="Note: Nếu muốn cập nhật lại thông tin vé bạn có thể ấn trực tiếp vào VÉ XE muốn cập nhật hoặc nhấp vào tên khách hàng đăng ký." ForeColor="#FF3300"></asp:Label> 
                 <br />
                    <asp:Label ID="Label3" runat="server" Text="Muốn xóa vé xe các bạn chỉ việc CHECK vào checkbox và nhấn Delete." ForeColor="#FF3300"></asp:Label> 
                 <br />
                 <br />--%>

                    <p style="padding-left: 470px;">
                        <asp:Button ID="btDelte" runat="server" Text="Delete" Font-Size="Small" 
                            onclick="btDelte_Click" />
                    </p>
                 
                <br />
                <br />
             </center>
                <asp:Repeater ID="RepeaterListVeXe" runat="server">
                <HeaderTemplate>
                    <table width="100%" cellspacing="0" cellpadding="8" >
                    <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                  
                    <tr>      
                       <td>
                           <a href="Datve.aspx?Id=<%#Eval("MaVe") %>">
                                <asp:Label ID="Label1" runat="server" Text="VÉ XE: " ForeColor="Blue" Font-Size="Large"><%#Container.ItemIndex+1%></asp:Label>
                           </a>
                        </td>
                        <td>
                            <input type="checkbox" name="Id" value='<%#Eval("MaVe")%>'>
                            
                        </td>
                    </tr>
                    <tr>
                         <td class="chu">Họ tên</td>
                           <td class="chu1"><a href='DatVe.aspx?Id=<%#Eval("MaVe")%>'><%#Eval("HoTen")%></a></td>
                     </tr>
                     <tr>  
                        <td class="chu">Giới tính </td>
                        <td class="chu1"><%#Eval("GioiTinh")%></td>
                     </tr>
                     <tr>
                        <td class="chu">Tuổi</td>
                        <td class="chu1"><%#Eval("Tuoi")%></td>
                     </tr>
                     <tr>
                         <td class="chu">Điạ chỉ</td>
                        <td class="chu1"><%#Eval("DiaChi")%>i</td>
                     </tr>
                     <tr>
                        <td class="chu">Số ĐT</td>
                        <td class="chu1"><%#Eval("SoDT")%></td>
                     </tr>
                     <tr>
                        <td class="chu">Ngày xuất bến</td>
                        <td class="chu1"><%#Eval("NgayXuatBen", "{0:dd/MM/yyyy}")%></td>
                    </tr>
                     <tr>
                        <td class="chu">Thời gian</td>
                        <td class="chu1"><%#Eval("GioXuatBen")%></td>
                     </tr>
                     <tr>
                         <td class="chu">Tuyến đi</td>
                        <td class="chu1"><%#Eval("BenDiBenDen")%></td>
                    </tr> 
                    <tr> 
                        <td class="chu">Loại xe</td>
                        <td class="chu1"><%#Eval("KieuiXe")%></td>
                    </tr>          
                    <tr>
                        <td class="chu">Gía vé</td>
                        <td class="chu1"><%#Eval("GiaVe","{0:0,000}")%> VNĐ</td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </p>

                            </div>
                        </li>
              
                    </ul>    
        </div><!-- END .section -->


</asp:Content>

