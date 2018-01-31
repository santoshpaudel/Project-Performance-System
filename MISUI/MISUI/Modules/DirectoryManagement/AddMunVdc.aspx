<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMunVdc.aspx.cs" Inherits="MISUI.Modules.DirectoryManagement.AddMunVdc" %>
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
               <%=GetLabel("District") %><span class="style2">*</span></td>
            <td>
                <asp:DropDownList ID="ddlDistrict" runat="server">
                </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("VDC/MUN ENGLISH NAME") %><span class="style2">*</span> </td>
            <td>
                <asp:TextBox ID="txtVMeng" Height="30px" required runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("VDC/MUN NEPALI NAME") %><span class="style2">*</span> </td>
            <td>
                <asp:TextBox ID="txtVMnep" Height="30px" onKeypress = "return setUnicode(event,this);" required runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("VDC/MUN TYPE") %> <span class="style2">*</span></td>
            <td>
                <asp:DropDownList ID="ddlVdcMunType" runat="server">
                    <asp:ListItem Value="0">Choose Type</asp:ListItem>
                    <asp:ListItem Value="1">VDC</asp:ListItem>
                    <asp:ListItem Value="2">MUN</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("VDC/MUN CODE") %> <span class="style2">*</span></td>
            <td>
                <asp:TextBox ID="txtVMcode" Height="30px" required runat="server"></asp:TextBox>
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
                <asp:Button ID="btn_Save" CssClass="btn btn-primary" runat="server" Text="Add" onclick="btn_Save_Click" />
               <%-- <asp:Button ID="btn_Cancel" CssClass="btn btn-warning" runat="server" Text="Cancel" />--%>
                <asp:Button ID="btn_List" runat="server" CssClass="btn btn-primary" Text="List" onclick="btn_List_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
