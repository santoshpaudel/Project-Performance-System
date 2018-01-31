<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBudgetDonar.aspx.cs" Inherits="MISUI.Modules.Budget.AddBudgetDonar" %>
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
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td><%=GetLabel("DONAR ENGLISH NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtDonarEnglishName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("Donar Nepali Name") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" onKeypress = "return setUnicode(event,this);" required ID="txtDonarNepaliName"></asp:TextBox></td>
        </tr> 
         <tr>
            <td><%=GetLabel("Donar Code") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtDonarCode"></asp:TextBox></td>
        </tr>
         <tr>
            <td><%=GetLabel("Donar Type") %><span class="style1">*</span></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlDonarType">
                    <asp:ListItem Value="0">--छान्नुहोस्--</asp:ListItem>
                    <asp:ListItem Value="1">आन्तरिक</asp:ListItem>
                    <asp:ListItem Value="2">वैदेशिक</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable" 
                    ></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Add" ID="btnAddDonar" OnClick="btnAddDonar_Click"/></td>
        </tr>
        </table>
</asp:Content>
