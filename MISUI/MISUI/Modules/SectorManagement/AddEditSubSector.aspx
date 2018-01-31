<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditSubSector.aspx.cs" Inherits="MISUI.Modules.SectorManagement.AddEditSubSector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered table-responsive table-striped table-condensed">
         <tr>
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td><%=GetLabel("SUB SECTOR ENGLISH NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtSubSectorEngName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("SUB SECTOR NEPALI NAME")%><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" onKeypress = "return setUnicode(event,this);" required ID="txtSubSectorNepName"></asp:TextBox></td>
        </tr> 
         <tr>
            <td><%=GetLabel("Sub Sector Code") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtSubSectorCode"></asp:TextBox></td>
        </tr>
         <tr>
            <td><%=GetLabel("Sector") %><span class="style1">*</span></td>
            <td><asp:DropDownList ID="ddlSector" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable" 
                    ></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text=" " ID="btnAddSubsector" OnClientClick="return ValidateDropdown();" OnClick="btnAddSubSector_Click"/></td>
        </tr>
        </table>
        <script type="text/javascript">
            function ValidateDropdown() {
                var check = false;
                var sectorId = document.getElementById("<%=ddlSector.ClientID %>").value;
                if (sectorId > 0) {
                    check = true;

                } else {
                    
                    alert("Please Select Sector!!!");
                }
                return check;

            }
         </script>
   
</asp:Content>
