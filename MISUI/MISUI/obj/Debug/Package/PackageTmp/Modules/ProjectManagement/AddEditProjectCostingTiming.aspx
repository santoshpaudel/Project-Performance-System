<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="AddEditProjectCostingTiming.aspx.cs" Inherits="MISUI.Modules.ProjectManagement.AddEditProjectCostingTiming" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../../js/chosen.min.css" rel="stylesheet" type="text/css" />
    <script src="../../js/chosen.jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".chosen-select").chosen();
        });
    </script>
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
        <%-- <tr>
            <td colspan="6">
                बजेट शीर्षक:
                <asp:DropDownList runat="server" ID="ddlBudgetHead" AutoPostBack="True" OnSelectedIndexChanged="ddlBudgetHead_SelectedIndexChanged"/>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                आयोजना:
                <asp:DropDownList runat="server" ID="ddlProject" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="true"/>
                <asp:HiddenField runat="server" ID="hidProjectId"/>
            </td>
        </tr>--%>
        <tr>
            <td>
                <a href="javascript: history.go(-1)">Go Back</a>
            </td>
        </tr>
        <tr>
            <td>
                २५
            </td>
            <td colspan="5">
                <strong>आयोजनाको कार्यान्वयन हुने क्षेत्र र छनौट गर्दा अपनाइएका आधारहरु: </strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-bordered table-condensed table-responsive">
                    <tr>
                        <td>
                            <tr>
                                <td colspan="2">
                                    <strong>क) कार्यान्वयन क्षेत्र</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    जिल्ला संख्या:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtDistrictNumber"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    निर्वाचन क्षेत्र संख्या:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtElectionAreaNumber"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    गाविस/न.पा. संख्या:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtVdcMunNumber"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    विवरण:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" TextMode="MultiLine"
                                        ID="txtBibaran"></asp:TextBox>
                                </td>
                            </tr>
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <td colspan="2">
                                <strong>ख) छनौटका आधार</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                    ID="txtChanautAadhar"></asp:TextBox>
                            </td>
                        </tr>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                २६
            </td>
            <td colspan="5">
                <strong>श्रोतगत आयोजनाको कुल बजेट बांडफांड </strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Button runat="server" ID="btnAddAayojanaBadfad" Text="+थप्नुहोस्" CssClass="btn btn-warning"
                    OnClick="btnAddAayojanaBadfad_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table-striped table-condensed table-responsive table-bordered">
                    <asp:Repeater ID="rptAayojanaBadfad" runat="server" OnItemDataBound="rptAayojanaBadfad_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <th>
                                    श्रोत
                                </th>
                                <th>
                                    भुक्तानि प्रकार
                                </th>
                                <th>
                                    रकम
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="srot">
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlShrot" />
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlBhuktaniPrakar" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtRakam" Text='<%# Eval("RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.srot').remove();"
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
                २७
            </td>
            <td colspan="5">
                <strong>आयोजनाको सम्भाव्यता अध्ययन</strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-condensed table-responsive">
                    <tr>
                        <td>
                            क.
                        </td>
                        <td colspan="2">
                            आर्थिक प्राविधिक सम्भाव्यता अध्ययन भएको छ, छैन?
                        </td>
                        <td>
                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbdSambhaabyataAdhyan">
                                <asp:ListItem Value="1">छ</asp:ListItem>
                                <asp:ListItem Value="2">छैन</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtRemarks"
                                placeholder="कैफियत"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ख.
                        </td>
                        <td colspan="2">
                            आर्थिक प्राविधिक सम्भाव्यता अध्ययन भएको वर्ष
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                ID="txtAdhyanYear" placeholder="अध्ययन भएको वर्ष"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ग.
                        </td>
                        <td colspan="2">
                            आर्थिक प्राविधिक सम्भाव्यता अध्ययनको निष्कर्ष
                        </td>
                        <td colspan="2">
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" TextMode="MultiLine"
                                ID="txtNiskarsha" placeholder="अध्ययनको निष्कर्ष"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                २८
            </td>
            <td colspan="5">
                <strong>आयोजनाको आर्थिक तथा वित्तीय विश्लेषण</strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-condensed table-responsive">
                    <tr>
                        <td>
                            क.
                        </td>
                        <td colspan="2">
                            लागत फिर्ता अवधि (Pay-back Period)
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                ID="txtPayBackPeriod"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                placeholder="कैफियत" ID="txtPaybackPeriodRemarks"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ख.
                        </td>
                        <td colspan="2">
                            लाभ-लागत अनुपात (Benefit Cost Ratio)
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                ID="txtBenefitCostRatio"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                placeholder="कैफियत" ID="txtBenefitCostRatioRemarks"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ग.
                        </td>
                        <td colspan="2">
                            वित्तीय प्रतिफल दर (Financial Internal Rate of Return-FIRR)
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                ID="txtFirr"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                placeholder="कैफियत" ID="txtFirrRemarks"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            घ.
                        </td>
                        <td colspan="2">
                            आर्थिक प्रतिफल दर (Economic Internal Rate of Return-EIRR)
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                ID="txtEirr"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                placeholder="कैफियत" ID="txtEirrRemarks"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ङ.
                        </td>
                        <td colspan="2">
                            खुद वर्तमान मूल्य (Net Present Value-NPV)
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                ID="txtNpv"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                placeholder="कैफियत" ID="txtNPVRemarks"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            च.
                        </td>
                        <td colspan="2">
                            लागत प्रभावकारिता अध्ययन (Cost Effectiveness Analysis)
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtCostEffectiveness"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                                placeholder="कैफियत" ID="txtCostEffectivenessRemarks"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            छ.
                        </td>
                        <td colspan="2">
                            सम्भाव्यता अध्ययन गर्ने निकाय
                        </td>
                        <td colspan="2">
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtKaryanoyanNikaaya"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                २९
            </td>
            <td colspan="2">
                <strong>वातावरणीय प्रभाव मूल्याङ्कनको सङ्क्षिप्त विवरण (IEE र EIA)</strong>
            </td>
            <td>
                <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rbdEnvironmentalBibaran">
                    <asp:ListItem Value="1">भएको</asp:ListItem>
                    <asp:ListItem Value="2">नभएको</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="MultiLine" onKeypress="return setUnicode(event,this);"
                    ID="txtEnvironmentalBibaranRemarks" placeholder="भए विवरण/नभए कारण हाल्नुहोस्"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:FileUpload runat="server" ID="FileIeeiReport" AllowMultiple="true"/>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Label runat="server" ForeColor="red" ID="lblFileWarning">नयाँ फाइल ब्राउज गरी अपलोड गर्दा पूराना फाइलहरु हट्नेछन्।</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:GridView ID="grdUploadedFiles" runat="server" CssClass="table table-bordered table-striped table-responsive"
                    OnRowCommand="grdUploadedFiles_RowCommand" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FILENAME" HeaderText="File Name" />
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/img/view.png" ToolTip="View File"
                                    Width="20" Height="20" CommandName="View" CommandArgument='<%#Eval("FILENAME") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <a href="javascript: history.go(-1)">Go Back</a>
            </td>
            <td colspan="5">
                <asp:Button runat="server" Text="Save & Continue" CssClass="btn btn-primary" ID="btnSaveProjectCostingTiming"
                    OnClick="btnSaveProjectCostingTiming_Click" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">

        $(document).ready(function () {

            val = $('[id*=rbdSambhaabyataAdhyan]').find('input:checked').val();

            if (val == 1) {
                $('[id*=txtRemarks]').removeAttr("disabled");
                $('[id*=txtAdhyanYear]').removeAttr("disabled");
                $('[id*=txtNiskarsha]').removeAttr("disabled");
                var initial_remarks = $('[id*=txtRemarks]').val();
                var initial_adhyanyear = $('[id*=txtAdhyanYear]').val();
                var initial_niskarsha = $('[id*=txtNiskarsha]').val();
            } else {
                $('[id*=txtRemarks]').attr('disabled', 'true');
                $('[id*=txtAdhyanYear]').attr('disabled', 'true');
                $('[id*=txtNiskarsha]').attr('disabled', 'true');
                $('[id*=txtRemarks]').val("उपयोगी नभएको");
            }

            
            $('#MainContent_rbdSambhaabyataAdhyan').on('change', function () {
                debugger;
                val1 = $('[id*=rbdSambhaabyataAdhyan]').find('input:checked').val();
                
                if (val1 == 1) {
                    $('[id*=txtRemarks]').removeAttr("disabled");
                    $('[id*=txtAdhyanYear]').removeAttr("disabled");
                    $('[id*=txtNiskarsha]').removeAttr("disabled");
                    $('[id*=txtRemarks]').val(initial_remarks);
                    $('[id*=txtAdhyanYear]').val(initial_adhyanyear);
                    $('[id*=txtNiskarsha]').val(initial_niskarsha);
                    
                } else {
                    $('[id*=txtRemarks]').attr('disabled', 'true');
                    $('[id*=txtAdhyanYear]').attr('disabled', 'true');
                    $('[id*=txtNiskarsha]').attr('disabled', 'true');
                    $('[id*=txtRemarks]').val("उपयोगी नभएको");
                    $('[id*=txtAdhyanYear]').val("");
                    $('[id*=txtNiskarsha]').val("");
                }
            });


            val2 = $('[id*=rbdEnvironmentalBibaran]').find('input:checked').val();

            if (val2 == 1) {
                $('[id*=txtEnvironmentalBibaranRemarks]').removeAttr("disabled");
                var initial_EnvironmentalBibaranRemarks = $('[id*=txtEnvironmentalBibaranRemarks]').val();
            } else {
                $('[id*=txtEnvironmentalBibaranRemarks]').attr('disabled', 'true');
                $('[id*=txtEnvironmentalBibaranRemarks]').val("उपयोगी नभएको");
            }



            $('#MainContent_rbdEnvironmentalBibaran').on('change', function () {
                debugger;
                val3 = $('[id*=rbdEnvironmentalBibaran]').find('input:checked').val();
                
                if (val3 == 1) {
                    $('[id*=txtEnvironmentalBibaranRemarks]').removeAttr("disabled");
                    $('[id*=txtEnvironmentalBibaranRemarks]').val(initial_EnvironmentalBibaranRemarks);

                } else {
                    $('[id*=txtEnvironmentalBibaranRemarks]').attr('disabled', 'true');
                    $('[id*=txtEnvironmentalBibaranRemarks]').val("उपयोगी नभएको");
                }
            });
        });

        $("#MainContent_ddlBudgetHead").change(function () {
            var id = $("#MainContent_ddlBudgetHead").val();
            LoadProjectByBudgetHead();
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
        function changeProject() {
            var id = $("#MainContent_ddlProject").val();
            $("#MainContent_hidProjectId").val(id);
        };

    </script>
</asp:Content>
