<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MISUI.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>NPC || PPIS</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="css/loginCss.css" rel="stylesheet" />
    <script type='text/javascript' src='~/js/plugins/jquery/jquery-1.10.2.min.js'></script>
    <style type="text/css">
        .style1
        {
            color: #CC3300;
        }
        .row
        {
            background-color: gainsboro;
        }
        .bdy
        {
            background-color: gainsboro;
        }
    </style>
</head>
<body class="bdy">
    <div class="container" style="margin-top: 50px">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall" style="border-radius: 5px; box-shadow: 0 0 25px #000;">
                    <h1 class=" text-center login-title">
                        <span>Project Performance Information System</span><br />
                        <br />
                        आयोजना कार्य सम्पादन सू्चना प्रणाली
                    </h1>
                    <img class="img img-responsive img-rounded" style="display: block; margin-left: auto;
                        margin-right: auto;" src="images/NPC_banner2.png" />
                    <%-- <i class="fa fa-user fa-5x" style="color: #498BF4; margin-left: 150px; "></i>--%>
                    <form id="Form1" runat="server" class="form-signin">
                    <asp:TextBox ID="txtUsername" required class="form-control" placeholder="Username"
                        autofocus runat="server" />
                    <br />
                    <asp:TextBox TextMode="password" ID="txtPassword" required class="form-control" placeholder="Password"
                        runat="server" />
                    <asp:DropDownList runat="server" class="form-control" ID="ddlFiscalYear" />
                    <br />
                    <asp:Button runat="server" Text="Sign In" OnClientClick="return ValidateForm();"
                        CssClass="btn btn-lg btn-primary btn-block" ID="btnSignIn" type="submit" OnClick="btnSignIn_Click">
                    </asp:Button>
                    <div>
                        <asp:Label runat="server" ID="lblMsg" ForeColor="red" CssClass="col-lg-offset-2 text-warning"></asp:Label>
                    </div>
                    <div>
                        <h1 class=" text-center login-download">
                            <a runat="server" id="lnkDownloadFile">
                                <img src="images/download.png" style="height: 30px; width: 30px" alt="User Manual for PPIS"/>
                            </a>&nbsp; USER MANUAL</h1>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script>
    function ValidateForm() {
        var check = true;
        var fiscalYearId = document.getElementById("<%=ddlFiscalYear.ClientID %>").value;
        if (fiscalYearId == '-- आ.व. छान्नुहोस्--') {
            check = false;
            alert("Please Select Fiscal Year!!!");
            document.getElementById("<%=ddlFiscalYear.ClientID %>").focus();
        }
        return check;

    }
</script>
</html>
