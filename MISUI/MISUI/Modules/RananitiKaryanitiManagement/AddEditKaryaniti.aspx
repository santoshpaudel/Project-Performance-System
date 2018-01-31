<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditKaryaniti.aspx.cs" Inherits="MISUI.Modules.RananitiKaryanitiManagement.AddEditKaryaniti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../../assets/js/bootstrap.js"></script>
    <link href="../../js/chosen.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/chosen.jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".chosen-select").chosen();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <table class="table table-bordered table-responsive table-striped table-condensed">
        <tr>
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td><%=GetLabel("Rananiti") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" CssClass="chosen-select" ID="ddlRananiti"></asp:DropDownList>
        </tr>
        <tr>
            <td><%=GetLabel("Karyaniti (In Nepali)") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" required ID="txtKaryanitiNepaliName" onKeypress = "return setUnicode(event,this);"></asp:TextBox></td>
        </tr> 
        
        <tr>
            <td><%=GetLabel("Karyaniti (In English)") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" required ID="txtKaryanitiEnglishName"></asp:TextBox></td>
        </tr> 
                
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Add Karyaniti" ID="btnAddKaryaniti" OnClick="btnAddKaryaniti_Click"/></td>
        </tr>
    </table>


</asp:Content>
