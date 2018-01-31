<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MISUI.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <strong><%=GetLabel("Change password")%> (<span class="style1">*</span> <%=GetLabel("Compulsary")%>)</strong>
    <hr/>
    <div class="row">
        <div class="col-sm-3">
            <%=GetLabel("Enter old password") %><span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass="" TextMode="Password" required ID="txtOldPassword"></asp:TextBox>
        </div>
    </div>
    <hr/>
     <div class="row">
        <div class="col-sm-3">
             <%=GetLabel("Enter new password") %> <span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass="form-box" TextMode="Password" required ID="txtNewPassword"></asp:TextBox>
        </div>
    </div>
    <hr/>
     <div class="row">
        <div class="col-sm-3">
             <%=GetLabel("Confirm new password")%> <span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass="form-box" TextMode="Password" required ID="txtConfirmNewPassword"></asp:TextBox>
        </div>
    </div>
    <hr/>
     <div class="row">
        <div class="col-sm-3">
           
        </div>
         <div class="col-sm-3">
           <asp:Button runat="server" ID="btnChangePassword" CssClass="btn btn-primary" Text="Change" OnClientClick="return ValidatePassword();" OnClick="btnChangePassword_Click"/>
        </div>
    </div>
    
    <script type="text/javascript">
        function ValidateForm() {

            var check = true;
            var newPassword = document.getElementById("<%=txtNewPassword.ClientID %>").value;
            var confirmNewPassword = document.getElementById("<%=txtNewPassword.ClientID %>").value;
            if (newPassword != confirmNewPassword) {
                check = false;
                alert("नयाँ पासवर्ड मिलेन!");
                document.getElementById("<%=txtNewPassword.ClientID %>").focus();
            }
            return check;
           
        }
    </script>

</asp:Content>
