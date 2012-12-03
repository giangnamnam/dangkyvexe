<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.master" AutoEventWireup="true" CodeFile="Banggiave.aspx.cs" Inherits="Banggiave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    table
    {
        border-color: Gray;
        border-spacing: 2px;
        font: normal 11pt Tahoma;
    }
    th
    {
        font-weight: bold;
        text-align:center;
    }
    
    .oh
    {
         border-bottom:1px solid #CCC; 
         border-top:1px solid #CCC;
         border-left: 1px solid #CCC;
         border-right: 1px solid #CCC; ; 
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="section">
                    <div class="tag-title-wrap clearfix">
                        <h4 class="tag-title">
                           BẢNG GIÁ VÉ</h4>
                    </div>

                    <ul class="columns-2 clearfix">
                        <li class="col2">
                            <div class="testimonial-wrapper clearfix">
                           
                                 <p>
            <asp:Repeater ID="RepeatervBangGiaVe" runat="server" >
                <HeaderTemplate>
                    <table class="list" cellpadding="10" cellspacing="0" border="0" width="100%">
                    <tr style="background-color: #80B600;">
                        <th>Bến đi <=> Bến đến</th>
                        <th>Thời gian </th>
                        <th>Loại xe</th>
                        <th>Giá vé</th>
                        <th>Phụ thu</th>
                    </tr>
                </HeaderTemplate>

                <ItemTemplate>
                      <tr class='<%#Container.ItemIndex % 2==0?"white":"xam"%>'>
                        <td class="oh"><%#Eval("BenDiBenDen")%></td>
                        <td class="oh"><%#Eval("GioXuatBen")%></td>
                        <td class="oh"><%#Eval("KieuiXe")%></td>
                        <td style="color:Red" class="oh"><%#Eval("GiaVe","{0:0,000}")%></td>
                        <td class="oh"><%#Eval("PhuThu")%></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </p>
                            
                       
                            </div>
                        </li>
              
                    </ul>    
        </div><!-- END .section -->
</asp:Content>

