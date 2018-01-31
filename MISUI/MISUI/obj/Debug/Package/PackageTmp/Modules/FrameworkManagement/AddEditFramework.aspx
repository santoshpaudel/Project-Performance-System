<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditFramework.aspx.cs" Inherits="MISUI.Modules.FrameworkManagement.AddEditFramework" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            color: #CC0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table class="table table-bordered table-responsive table-striped table-condensed">
        <tr>
            <td><%=GetLabel("Framework (English)") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server"  ID="txtFrameworkEngName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("Framework (Nepali)") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" onKeypress = "return setUnicode(event,this);" ID="txtFrameworkNepName"></asp:TextBox></td>
        </tr>
       <tr>
            <td><%=GetLabel("Base Year") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlBaseYear"/></td>
        </tr>
        <tr>
            <td><%=GetLabel("First Year") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlFirstYear"/></td>
        </tr> 
        <tr>
            <td><%=GetLabel("Second Year") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlSecondYear"/></td>
        </tr>
      
        <tr>
            <td><%=GetLabel("Third Year") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlThirdYear"/></td>
        </tr>
       
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Add Framework" ID="btnAddFramework" OnClick="btnAddFramework_Click"/></td>
        </tr>
    </table>
</asp:Content>
