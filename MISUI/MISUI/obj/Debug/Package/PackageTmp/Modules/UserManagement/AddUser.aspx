<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="MISUI.Modules.UserManagement.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            color: #CC0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered table-condensed table-hover table-responsive">
         <tr>
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td>
             <%=GetLabel("USER ENGLISH NAME") %><span class="style2">* </span> </td>
            <td>
                <asp:TextBox ID="txtNameEng" Height="30px" required runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("USER NEPALI NAME") %><span class="style2">*</span> </td>
            <td>
                <asp:TextBox ID="txtNameNep" Height="30px" onKeypress = "return setUnicode(event,this);" required runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               <%=GetLabel("USERNAME") %><span class="style2">*</span></td>
            <td>
                <asp:TextBox ID="txtUsername" Height="30px" required runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               <%=GetLabel("PASSWORD") %><span class="style2">*</span></td>
            <td>
                <asp:TextBox ID="txtPassword" Height="30px" required runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               <%=GetLabel("CONFIRM PASSWORD") %><span class="style2">*</span></td>
            <td>
                <asp:TextBox ID="txtRePassword" Height="30px" required runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("OFFICE") %><span class="style2">*</span></td>
            <td>
                <asp:DropDownList ID="ddlOffice" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
               <%=GetLabel("ROLE") %></td>
            <td>
                <asp:DropDownList ID="ddlRole" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("USER TYPE") %></td>
            <td>
                <asp:DropDownList ID="ddlUserType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
               <%=GetLabel("MOBILE NUMBER") %></td>
            <td>
                <asp:TextBox ID="txtMobile" Height="30px" required runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
               <%=GetLabel("EMAIL") %></td>
            <td>
                <asp:TextBox ID="txtEmail" Height="30px" required runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable"></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_AddUser" CssClass="btn btn-primary" runat="server"
                    onclick="btn_AddUser_Click" />
                <asp:Button ID="btn_UserList" runat="server" CssClass="btn btn-primary" 
                    onclick="btn_UserList_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
