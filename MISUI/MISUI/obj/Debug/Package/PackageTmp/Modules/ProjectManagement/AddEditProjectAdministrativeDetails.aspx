<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddEditProjectAdministrativeDetails.aspx.cs" Inherits="MISUI.Modules.ProjectManagement.AddEditProjectAdministrativeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <script>
       $(function () {
           $('a').each(function () {
               if ($(this).prop('href') == window.location.href) {
                   $(this).addClass('btn btn-danger');
               }
           });
       });
    </script>
    
    <ul class="pagination">
        <li><a id="prFstLnk" runat="server">खण्ड १</a></li>
        <li><a id="prSecLnk" runat="server">खण्ड २</a></li>
        <li><a id="prThdLnk" runat="server">खण्ड ३</a></li>
        <li><a id="prFrtLnk" runat="server">खण्ड ४</a></li>
    </ul>
    <table class="table table-striped table-condensed table-responsive">
        <%--<tr>
            <td colspan="6">
                बजेट शीर्षक:
                <asp:DropDownList runat="server" ID="ddlBudgetHead" AutoPostBack="True" OnSelectedIndexChanged="ddlBudgetHead_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                आयोजना:
                <asp:DropDownList runat="server" ID="ddlProject" AutoPostBack="True"  OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" />
                
            </td>
        </tr>--%>
        <tr>
            <td>
                <a href="javascript: history.go(-1)">Go Back</a>
            </td>
        </tr>
        <tr>
            <td>
                ३०
            </td>
            <td colspan="5">
                आयोजना कार्यान्वयनमा आवश्यक पर्ने जनशक्ति व्यवस्था:
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                क. भइरहेको जनशक्तिबाट हुने/नहुने:
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rbdExistingJanashakti" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">हुने</asp:ListItem>
                    <asp:ListItem Value="2">नहुने</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                ख. थप चाहिने जनशक्ति विवरण (संख्या):
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" ID="txtThapJanashakti" onKeypress="return setUnicode(event,this);"
                    onchange="unicodeToEngNumber(this)" placeholder="संख्या"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" placeholder="कैफियत" onKeypress="return setUnicode(event,this);"
                    ID="txtJanaShaktiKaifiyat" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                ग. थप चाहिने जनशक्ति सम्बन्धमा सामान्य प्रशासन मण्त्रालयको राय:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtMinistryRaaya"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ३१
            </td>
            <td colspan="5">
                आयोजनाको अनुगमन तथा मूल्याङ्कन गर्ने संस्थागत व्यवस्था:
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                क. अनुगमन तथा मूल्याङ्कनका लागि छुट्टाइएको रकम:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                    ID="txtChuttayiyekoRakam"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                ख. दातृ संस्थाबाट गरिने अनुगमन तथा मूल्याङ्कनको विवरण:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtDaatriBibaran"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                ग. नेपाल सरकारबाट गरिने अनुगमन तथा मूल्याङ्कनको विवरण:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtNepalSarkarBibaran"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="1">
                घ. मन्त्रालयबाट गरिने आन्तरिक अनुगमनको विवरण:
            </td>
            <td colspan="4">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtMantralayaBibaran"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ३२
            </td>
            <td colspan="5">
                आयोजनाका लागि आवश्यक प्रमुख भौतिक सामाग्रीहरु:
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Button runat="server" ID="btnAddBhautikSamagri" Text="+थप्नुहोस्" CssClass="btn btn-warning"
                    OnClick="btnAddBhautikSamagri_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table-striped table-condensed table-responsive table-bordered">
                    <asp:Repeater ID="rptBhautikSamagri" runat="server" OnItemDataBound="rptBhautikSamagri_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <th>
                                    सामाग्रीको नाम
                                </th>
                                <th>
                                    इकाइ
                                </th>
                                <th>
                                    परिमाण
                                </th>
                                <th>
                                    अनुमानित मूल्य रु.
                                </th>
                                <th>
                                    कैफियत
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="samagri">
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtItemName"
                                        Text='<%# Eval("ITEM_NAME") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlUnit" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtQuantity" Text='<%# Eval("QUANTITY") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtAnumanitRakam" Text='<%# Eval("ANUMANIT_RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtSamagriKaifiyat" Text='<%# Eval("SAMAGRI_KAIFIYAT") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.samagri').remove();"
                                        EnableViewState="True" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                ३३
            </td>
            <td colspan="5">
                आयोजनाको दिगोपन र सम्पन्न भएपछि सञ्चालन (Phase-out Plan) सम्बन्धी व्यवस्था:
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtPhaseOutPlan"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <a href="javascript: history.go(-1)">Go Back</a>
            </td>
            <td colspan="5">
                <asp:Button runat="server" ID="btnAddAdminDetails" CssClass="btn btn-primary" OnClick="btnAddAdminDetails_Click"
                    Text="Save & Continue"></asp:Button>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $("#MainContent_ddlBudgetHead").change(function () {
            var id = $("#MainContent_ddlBudgetHead").val();
            //LoadProjectByBudgetHead();
        });

        function LoadProjectByBudgetHead() {
            //load another dropdown
            var budgetHeadId = $("#MainContent_ddlBudgetHead").val();

            $("#MainContent_ddlProject").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindProjectByBudgetHead",
                data: "{budgetHeadId:'" + budgetHeadId + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindProjectDdl(msg.d);
                }
            });
            function BindProjectDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlProject").append($("<option></option>").val(this['ComboId']).html(this['Name']));
                });
            }
        }
        $("#MainContent_ddlProject").change(function () {
            var id = $("#MainContent_ddlProject").val();
            $("#MainContent_hidProjectId").val(id);
        });

    </script>
</asp:Content>
