<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BudgetToOrganizationMap.aspx.cs" Inherits="MISUI.Modules.Budget.BudgetToOrganizationMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../js/chosen.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../js/chosen.jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".chosen-select").chosen();
        });
    </script>
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td colspan="6">
                बजेट शीर्षक:
                <asp:DropDownList CssClass="chosen-select" runat="server" ID="ddlBudgetHead"  />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                मण्त्रालय:
                <asp:DropDownList CssClass="chosen-select" runat="server" ID="ddlMinistry" AutoPostBack="True" OnSelectedIndexChanged="ddlMinistry_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <%-- <td><%=GetLabel("Ministry") %></td>
            <td>
                <asp:CheckBoxList runat="server" ID="chkMinistries" RepeatDirection="Vertical" RepeatLayout="Table"/>
            </td>--%>
            <td>
                <%=GetLabel("Office") %>
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="chosen-select" ID="ddlOffice" AutoPostBack="True" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged" />
                <%--<asp:CheckBoxList runat="server" ID="chkOffices" RepeatDirection="Vertical" RepeatLayout="Table"/>--%>
            </td>
        </tr>
        <tr>
            <td>
                <%=GetLabel("User") %>
            </td>
            <td>
                <asp:CheckBoxList runat="server" ID="chkUsers" RepeatDirection="Vertical" RepeatLayout="Table" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button runat="server" ID="btnMap" Text="Map" CssClass="btn btn-primary" OnClick="btnMap_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
