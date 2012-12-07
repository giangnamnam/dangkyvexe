<%@ Page Title="" Language="C#" MasterPageFile="~/Skin.master" AutoEventWireup="true" CodeFile="Datve.aspx.cs" Inherits="Datve" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <style type="text/css">
        .style1
        {
           float: right;
           text-align: center;   
        }
        b
        {
            font-weight: bold;
            color: #999;
        }
        .oh
        {
             border-bottom:1px solid #CCC; 
             border-top:1px solid #CCC;
             border-left:1px solid #CCC;
             border-right: 1px solid #CCC;
        }
        .baterror
        {
            color:Red;
        }
        .labelTonTai
        {
            text-align:center;
            color:Red;
            font-weight:lighter;
            font-size: 15px;
        }
    </style>
    <link href="css/clander/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="js/jsclander/jquery-1.8.0.js" type="text/javascript"></script>
   <script src="js/jsclander/jquery-ui.js" type="text/javascript"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server"> 
   
     <div class="section">
                    <div class="tag-title-wrap clearfix">
                        <h4 class="tag-title">
                           ĐẶT VÉ</h4>
                    </div>

                    <ul class="columns-2 clearfix">
                        <li class="col2">
                            <div class="testimonial-wrapper clearfix">
                            <center>
                                <p><asp:Label ID="lbThongBaoStatus" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label></p>
                                    <br />
                                <p><asp:Label ID="lbThongBaoStatus1" runat="server" Text="" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label></p>
                                <br />

                               <br />


                              

                                <p>
                                    <asp:HyperLink ID="HyperLinkDangNhap" runat="server" NavigateUrl="~/Dangnhap.aspx">Đăng nhập</asp:HyperLink>
                                    <asp:Label ID="Label10" runat="server" Text="|"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkDangKy" runat="server" NavigateUrl="~/Dangky.aspx">Đăng ký</asp:HyperLink>
                                </p>
                             </center>
                           <asp:PlaceHolder runat="server" ID="pnDangKyVe" Visible="false">
                           <table border="0" width="100%" cellspacing="7">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbMaVe" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="lbUsername" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:CheckBox ID="CheckBoxTrangThaiVeXe" runat="server" Visible="false" />

                                        </td>
                                    </tr>
                                    <tr>
                                            <p style="text-align:center;color: Red;font-weight:bold;"><asp:Label ID="Label4" runat="server" Text="Label">Quý khách vui lòng điền đầy đủ thông tin để đăng ký vé.</asp:Label></p>
                                           
                                    </tr>
                                    <tr>
                                        <td class="style1">  
                                               <asp:Label ID="Label1" runat="server">Họ và tên:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtHoVaTen" runat="server" Width="247px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorHoVaTen" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="txtHoVaTen"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label2" runat="server" Text="Giới tính: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonNam" runat="server" Text="Nam" Checked="true" GroupName="gioitinh"/>
                                            <asp:RadioButton ID="RadioButtonNu" runat="server" Text="Nữ" GroupName="gioitinh"/>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Tuoi" runat="server" Text="Tuổi : "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTuoi" runat="server" Width="92px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTuoi" runat="server" ErrorMessage="*" CssClass="baterror" ControlToValidate="txtTuoi" SetFocusOnError="True" ValidationExpression="^\d{2}$"></asp:RegularExpressionValidator>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="txtTuoi"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label5" runat="server" Text="Điạ chỉ: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiaChi" runat="server" Width="247px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDiaChi" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="txtDiaChi"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label3" runat="server" Text="Số ĐT: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSoDT" runat="server" Width="228px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDT" runat="server" ErrorMessage="*" ControlToValidate="txtSoDT" CssClass="baterror" SetFocusOnError="True" ValidationExpression="^0[1-9]{1}[0-9]{8,9}$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="txtSoDT"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>

                                    

                                     
                                    <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label7" runat="server" Text="Ngày xuất bến: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNgayThangXuatBen" runat="server" Width="228px"></asp:TextBox>
                                            
                                            <script type="text/javascript">
                                                $('#<% = txtNgayThangXuatBen.ClientID%>').datepicker();
                                            </script>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="baterror" SetFocusOnError="true" ControlToValidate="txtNgayThangXuatBen"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>

                                     <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label6" runat="server" Text="Tuyến đi: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListTuyenDiTuyenDen" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">----Tuyến đi <=> Tuyến đến----</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTuyenDi" runat="server" ErrorMessage="*" CssClass="baterror" ControlToValidate="DropDownListTuyenDiTuyenDen" InitialValue="0" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>


                                     <tr>
                                        <td class="style1"> 
                                            <asp:Label ID="Label8" runat="server" Text="Thời gian: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListThoiGian" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">----Thời gian xuất bến----</asp:ListItem>
                                            </asp:DropDownList>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorThoiGian" runat="server" ErrorMessage="*" CssClass="baterror" ControlToValidate="DropDownListThoiGian" InitialValue="0" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>

                                    <tr>
                                         <td class="style1"> 
                                            <asp:Label ID="Label11" runat="server" Text="Loại xe: "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListLoaiXe" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Value="0">----Loại xe----</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLoaiXe" runat="server" ErrorMessage="*" CssClass="baterror" ControlToValidate="DropDownListLoaiXe" InitialValue="0" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        
                                        </td>
                                    </tr>
                                   

                                     <tr>
                                        <td class="style1">
                                            <asp:Label ID="Label9" runat="server" Text="Nhập mã: "></asp:Label>
                                        </td>
                                        <td>
                                        
                                            <cc1:CaptchaControl ID="CaptchaControlDatVe" runat="server" CaptchaBackgroundNoise="Medium" CaptchaLineNoise="Low"/>
                                            <asp:TextBox ID="txtCapchaDangky" runat="server" Width="177px"></asp:TextBox>
                                            <asp:Label ID="lbResult" runat="server" Text="" Font-Bold="True" 
                                                ForeColor="#FF3300"></asp:Label>
                                        </td>
                                        
                                    </tr>

                                    

                                    <tr>
                                        <td></td>
                                        <td style="padding-left:50px;">
                                            <asp:Button ID="btDangKy" runat="server" Text="Đăng ký" BorderStyle="Dashed" 
                                                Font-Bold="True" ForeColor="#000066" onclick="btDangKy_Click" />
                                        </td>
                                    </tr>
                                </table>
                              
                               
                               <img src="imageqc/Linetitle1.jpg" width="600px"/>
                               <br />
                               <br />
                               <asp:Panel ID="PanelThongTinVe" runat="server" Visible="false">
                              
                           
                                <table style="text-align:center" cellpadding="10" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td class="oh" style="font-weight:bold; background-color: #CCC;">
                                            Bến đi <=> Bến đến
                                        </td>
                                        <td class="oh" style="font-weight:bold; background-color: #CCC;">
                                            Ngày xuất bên
                                        </td>
                                        <td class="oh" style="font-weight:bold; background-color: #CCC;">
                                            Thời gian
                                        </td>
                                        <td class="oh" style="font-weight:bold; background-color: #CCC;">
                                            Loại xe
                                        </td>
                                        <td class="oh" style="font-weight:bold; background-color: #CCC;">
                                            Chỗ trống
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="oh">  
                                            <asp:Label ID="lbBenDiBenDen" runat="server" Text="" ></asp:Label>
                                        </td>
                                        
                                        <td class="oh">
                                        
                                            <asp:Label ID="lbNgayXuatBen" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="oh">
                                            <asp:Label ID="lbThoiGian" runat="server" Text=""></asp:Label>
                                        </td>
                                        
                                        <td class="oh">
                                            <asp:Label ID="lbLoaiXe" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="oh">   
                                            <asp:Label ID="lbSoLuongVeWhere" runat="server" Text="" Visible="false">1</asp:Label>
                                        </td>
                                        
                                    </tr>
                                
                                </table>
                              
                                 <br />
                         
                                <img src="imageqc/Linetitle1.jpg" width="600px"/>
                                </asp:Panel>

                                <asp:Label ID="lbTuyenDiTonTai" runat="server" Text="" CssClass="labelTonTai"></asp:Label>

                                 <asp:HyperLink ID="HyperLinkBangGiaVe" runat="server" NavigateUrl="~/Banggiave.aspx" Target="_blank" Font-Overline="False" Font-Underline="True" ForeColor="#FF3300" Font-Bold="True"></asp:HyperLink>


                                <br />
                                <br /> 
                                <table border="0" width="100%">
                                    <tr>
                                        <td><u>Lưu ý:</u></td>
                                    </tr>
                                    <tr>
                                        <td><b>Họ tên:</b> Là tên của quý khách để đăng ký vé xe.</td>
                                    </tr>
                                    <tr>
                                        <td><b>Địa chỉ:</b>Ghi rõ số nhà,quận huyện, thành phố, tỉnh thành. Quý khách đang lưu trú.</td>
                                    </tr>
                                    <tr>
                                        <td><b>Số ĐT:</b> Số điện thoại quý khách để công ty sẽ liên lạc.</td>
                                    </tr>
                                    <tr>
                                        <td><b>Ngày xuất bến:</b> Ngày xuất bến của quý khách.</td>
                                    </tr>
                                    <tr>
                                        <td><b>Tuyến đi:</b> Địa điểm bắt đầu và địa điểm muốn đến của quý khách.</td>
                                    </tr>
                                    <tr>
                                        <td><b>Thời gian:</b> Thời gian muốn xuất bến.</td>
                                    </tr>
                                </table>

                                <center>
                                    <p style="color: Red">Sau 2 tiếng kể từ khi đăng ký vé xe công ty sẽ liên lạc lại với quý khách.</p>
                                </center>


                             </asp:PlaceHolder>
                             
                            </div>
                        </li>
              
                    </ul>
                    
        </div><!-- END .section -->
        
</asp:Content>

