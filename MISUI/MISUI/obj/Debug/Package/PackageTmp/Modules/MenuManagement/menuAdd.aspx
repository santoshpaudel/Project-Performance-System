<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menuAdd.aspx.cs" Inherits="MISUI.Modules.MenuManagement.menuAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
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
            <td><%=GetLabel("MENU ENGLISH NAME") %><span class="style1">*</span></td>
            <td>
                <asp:TextBox runat="server" Height="30px" required ID="txtMenuEnglishName"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td><%=GetLabel("MENU NEPALI NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" onKeypress = "return setUnicode(event,this);" required ID="txtMenuNepaliName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("MENU PATH") %></td>
            <td><asp:TextBox runat="server" Height="30px"  ID="txtMenuPath"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" ID="btnAddMenu" CssClass="btn btn-primary"  Text="Add Menu" OnClick="btnAddMenu_Click"/></td>
        </tr>
    </table>

</asp:Content>


