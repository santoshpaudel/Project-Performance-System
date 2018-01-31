<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BudgetDonarMap.aspx.cs" Inherits="MISUI.Modules.Budget.BudgetDonarMap" %>
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
            <td><%=GetLabel("BUDGET HEAD NAME") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlBudgetHead"/></td>
        </tr>
        <tr>
            <td><%=GetLabel("DONAR NAME") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlDonar"/></td>
        </tr> 
         <tr>
            <td><%=GetLabel("PAYMENT TYPE") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlPaymentType"/></td>
        </tr> 
        <tr>
            <td><%=GetLabel("FISCAL YEAR") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlFiscalYear"/></td>
        </tr> 
        <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable" 
                    ></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Map" ID="btnAddDonar" OnClientClick="return ValidateForm();" OnClick="btnMapBudgetDonar_Click"/></td>
        </tr>
        </table>
        <script>
            function ValidateForm() {
                var check = true;
                var budgetHeadId = document.getElementById("<%=ddlBudgetHead.ClientID %>").value;
                var donarId = document.getElementById("<%=ddlDonar.ClientID %>").value;
                var paymentTypeId = document.getElementById("<%=ddlPaymentType.ClientID %>").value;
                var fiscalYearId = document.getElementById("<%=ddlFiscalYear.ClientID %>").value;
                if (budgetHeadId == '--Choose Budget Head--') {
                    check = false;
                    alert("Please Select Budget Head!!!");
                    document.getElementById("<%=ddlBudgetHead.ClientID %>").focus();
                }
                else if (donarId == '--Choose Donar--') {
                    check = false;
                    alert("Please Select Donar!!!");
                    document.getElementById("<%=ddlDonar.ClientID %>").focus();
                }
                else if (paymentTypeId == '--Choose Payment Type--') {
                    check = false;
                    alert("Please Select Payment Type!!!");
                    document.getElementById("<%=ddlPaymentType.ClientID %>").focus();
                }
                else if (fiscalYearId == '--Choose Fiscal Year--') {
                    check = false;
                    alert("Please Select Fiscal Year!!!");
                    document.getElementById("<%=ddlFiscalYear.ClientID %>").focus();
                }
                return check;

            }
        </script>
</asp:Content>
