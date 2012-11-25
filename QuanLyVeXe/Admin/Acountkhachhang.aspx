<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Acountkhachhang.aspx.cs" Inherits="Admin_Acountkhachhang" %>

<%@ Register src="../Control/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <p style="text-align:center; font-weight: bold; font-size: 150%; color: White;">QUẢN LÝ TÀI KHOẢN</p>
        <hr />

        <p>
            &nbsp;<asp:Panel ID="PanelChucNang" runat="server">
                <asp:Button ID="btXoaLienHe" runat="server" Text="Delete select " Width="118px" 
                    Height="30px" 
                    OnClientClick="return confirm('Are you renmove it slected?');" 
                    onclick="btXoaLienHe_Click" />
                
                <asp:Button ID="btTimKiem" runat="server" Text="Search" Width="112px" 
                    Height="30px" onclick="btTimKiem_Click" />
                    

                <asp:Button ID="btThongKe" runat="server" Text="Thống kê" Width="112px" 
                    Height="30px" />
                <asp:Button ID="btIndanhsach" runat="server" Text="In danh sách" 
                    Height="29px" />
               <asp:Label ID="lbThongKe" runat="server" Text="9" CssClass="labelThongKe"></asp:Label>
            </asp:Panel>
        </p>
        <br>
        <center>
            <asp:Panel ID="PanelTimKiem" runat="server" Visible="false">
                    
                    <asp:TextBox ID="txtTimKiem" runat="server" Height="16px" Width="253px"></asp:TextBox>
                    <asp:Button ID="btTimKiemThat" runat="server" Text="Search" 
                        onclick="btTimKiemThat_Click" />
                    <p>
                        <asp:RadioButton ID="RadioButtonUserName" runat="server" Text="Username" Checked="true" GroupName="timkiem"/>
                        <asp:RadioButton ID="RadioButtonEmail" runat="server" Text="Email" GroupName="timkiem"/>
                        <asp:RadioButton ID="RadioButtonLastActivityDate" runat="server" Text="LastActivityDate" GroupName="timkiem" Visible="false"/>
                    </p>
            </asp:Panel>
            
        </center>

         <b style="color:Orange"> Number of Users Online: <asp:Label id="UsersOnlineLabel" runat="Server" /></b><br />

        <asp:Repeater ID="RepeaterUser" runat="server">
            <HeaderTemplate>
                <table class="list">
                    <tr style="background-color: #87CEEB;">
                        <th class="cid"><input type="checkbox"></th>
                        <th>UserName</th>
                        <th>Email</th>
                        <th>PasswordQuestion</th>
                      <%--  <th>IsApproved</th>
                        <th>IsLockedOut</th>--%>
                        <th>LastLockoutDate</th>
                        <th>CreationDate</th>
                        <th>LastLoginDate</th>
                        <th>LastActivityDate</th>
                        <%--<th>LastPasswordChangedDate</th>--%>
                        <th>IsOnline</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr class='<%#Container.ItemIndex % 2==0?"white":"xam"%>'>
                    <td><input type="checkbox" value='<%#Eval("UserName")%>' name="username" ></td>
                    <td><%#Eval("UserName")%></td>
                    <td><%#Eval("Email")%></td>
                    <td><%#Eval("PasswordQuestion")%></td>
                   <%-- <td><%#Eval("IsApproved")%></td>
                    <td><%#Eval("IsLockedOut")%></td>--%>
                    <td><%#Eval("LastLockoutDate","{0:dd/MM/yyyy}")%></td>
                    <td><%#Eval("CreationDate","{0:dd/MM/yyyy}")%></td>
                    <td><%#Eval("LastLoginDate","{0:dd/MM/yyyy}")%></td>
                    <td><%#Eval("LastActivityDate","{0:dd/MM/yyyy}")%></td>
                    <%--<td><%#Eval("LastPasswordChangedDate","{0:dd/MM/yyyy}")%></td>--%>
                    <td>
                        
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="VeXeUpdateStatus"  BorderStyle="None" CssClass='<%#Eval("IsOnline").ToString()=="False"?"":"onlinee" %>'></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>


        <br />
    <hr />
    <asp:Panel id="NavigationPanel" Visible="false" runat="server">
     <table border="0" cellpadding="3" cellspacing="3">
      <tr>
        <td style="width:100">Page <asp:Label id="CurrentPageLabel" runat="server" />
            of <asp:Label id="TotalPagesLabel" runat="server" /></td>
        <td style="width:60"><asp:LinkButton id="PreviousButton" Text="< Prev"
                            OnClick="PreviousButton_OnClick" runat="server" /></td>
        <td style="width:60"><asp:LinkButton id="NextButton" Text="Next >"
                            OnClick="NextButton_OnClick" runat="server" /></td>
      </tr>
    </table>
  </asp:Panel>

    </div>
  
</asp:Content>

