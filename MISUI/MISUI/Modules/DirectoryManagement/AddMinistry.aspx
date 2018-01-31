<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMinistry.aspx.cs" Inherits="MISUI.Modules.DirectoryManagement.AddMinistry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            color: #CC0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-responsive table-striped">
        <tr>
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td ><%=GetLabel("MINISTRY ENGLISH NAME") %><span class="style2">* </span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtMinistryEnglishName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("Ministry Nepali NAME") %><span class="style2">* </span></td>
            <td><asp:TextBox runat="server" Height="30px" onKeypress = "return setUnicode(event,this);" required ID="txtMinistryNepaliName"></asp:TextBox></td>
        </tr> 
        <tr>
            <td><%=GetLabel("minstry code") %><span class="style2">* </span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtCode"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" ID="btnAddMinistry"  OnClick="btnAddMinistry_Click"/></td>
        </tr>
    </table>
</asp:Content>