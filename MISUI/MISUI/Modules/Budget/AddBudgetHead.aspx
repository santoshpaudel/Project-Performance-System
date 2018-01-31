<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBudgetHead.aspx.cs" Inherits="MISUI.Modules.Budget.AddBudgetHead" %>
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
            <td><%=GetLabel("Budget Head ENGLISH NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtBudgetHeadEnglishName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("Budget Head Nepali Name") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" onKeypress = "return setUnicode(event,this);" required ID="txtBudgetHeadNepaliName"></asp:TextBox></td>
        </tr> 
         <tr>
            <td><%=GetLabel("Budget Head Code") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtBudgetCode"></asp:TextBox></td>
        </tr> 
        <tr>
            <td><%=GetLabel("Fiscal Year") %><span class="style1">*</span></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlFiscalYear"/>
            </td>
        </tr> 
        <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable"></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Add Budget Head" OnClientClick="return ValidateForm();"  ID="btnAddBudgetHead" OnClick="btnAddBudgetHead_Click"/></td>
        </tr>
        </table>
        
         <script type="text/javascript">
             function ValidateForm() {
                 var check = false;
                 var fiscalYearId = document.getElementById("<%=ddlFiscalYear.ClientID %>").value;
                 if (fiscalYearId > 0) {
                     check = true;

                 } else {
                     fiscalYearId.focus();
                     alert("Please Select Fiscal Year!!!");
                 }
                 return check;

             }
         </script>

</asp:Content>
