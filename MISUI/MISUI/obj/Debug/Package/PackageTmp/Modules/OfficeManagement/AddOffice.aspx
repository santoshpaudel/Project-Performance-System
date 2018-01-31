<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOffice.aspx.cs" Inherits="MISUI.Modules.OfficeManagement.AddOffice" %>
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
            <td><%=GetLabel("OFFICE ENGLISH NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" required ID="txtOfficeEnglishName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("OFFICE NEPALI NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" required ID="txtOfficeNepaliName" onKeypress = "return setUnicode(event,this);"></asp:TextBox></td>
        </tr> 
        <tr>
            <td><%=GetLabel("OFFICE TYPE") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlOfficeType"></asp:DropDownList>
                
            </td>
        </tr>
        <%--<tr>
            <td><%=GetLabel("MINISTRY") %></td>
            <td><asp:DropDownList runat="server" ID="ddlMinistry"></asp:DropDownList></td>
        </tr> --%>

        <tr>
            <td><%=GetLabel("DISTRICT") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" ID="ddlDistrict"></asp:DropDownList>
                
            </td>
        </tr>
        <tr>
            <td><%=GetLabel("VDC/MUNICIPALITY") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlVdcMun"></asp:DropDownList>
               
            </td>
        </tr>
         <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable"></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Add Office" ID="btnAddOffice" OnClick="btnAddOffice_Click"/></td>
        </tr>
    </table>
</asp:Content>