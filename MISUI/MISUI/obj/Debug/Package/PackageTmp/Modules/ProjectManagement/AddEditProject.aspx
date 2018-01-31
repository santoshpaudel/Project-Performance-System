<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddEditProject.aspx.cs" EnableEventValidation="false" Inherits="MISUI.Modules.ProjectManagement.AddEditProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <%--<script type="text/javascript" src="../../assets/js/bootstrap.js"></script>--%>
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
            <div class="alert alert-dismissible alert-info pull-right" style="padding: 5px;">
                <%=GetLabel("Last Modified By")%>:&nbsp;<asp:Label runat="server" ID="lblModifiedBy"></asp:Label><br />
                <%=GetLabel("Last Modified On")%>:&nbsp;<asp:Label runat="server" ID="lblModification"></asp:Label>
            </div>
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td colspan="4">
                <%=GetLabel("Ministry")%>:
                <asp:DropDownList ID="ddlMinistry" runat="server" CssClass="chosen-select" AutoPostBack="True" OnSelectedIndexChanged="ddlMinistry_SelectedIndexChanged">
        </asp:DropDownList>
            </td>
            <td colspan="8">
                <%=GetLabel("Budget Head")%>:
                <asp:DropDownList runat="server" ID="ddlBudgetHead" Enabled="False" />
            </td>
            
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <strong>नाम (देवनगरी)</strong>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <strong>नाम (अङ्ग्रेजी)</strong>
            </td>
        </tr>
        <tr>
            <td>
                १
            </td>
            <td>
                <strong>आयोजनाको नाम:</strong>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAyojanaNepName" onKeypress="return setUnicode(event,this);" />
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAyojanaEngName"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                २
            </td>
            <td>
                <strong>आयोजानाको लक्ष्य:</strong>
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAyojanaLakshya" onKeypress="return setUnicode(event,this);" />
            </td>
            <td>
                ३
            </td>
            <td>
                <strong>आयोजनाको उदेश्य:</strong>
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAyojanaUdeshya" onKeypress="return setUnicode(event,this);" />
            </td>
        </tr>
        <tr>
            <td>
                ४
            </td>
            <td>
                <strong>आयोजनाको प्रतिफल:*</strong>
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAyojanaPratifal" onKeypress="return setUnicode(event,this);" />
            </td>
            <td>
                ५
            </td>
            <td>
                <strong>आयोजनाका मुख्य क्रियाकलापहरु:*</strong>
            </td>
            <td>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtAyojanaKriyakalap" onKeypress="return setUnicode(event,this);" />
            </td>
        </tr>
        <tr>
            <td>
                ६
            </td>
            <td>
                <strong>कार्यक्रमको प्रकार</strong>
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rblKaryakramPrakar">
                    <asp:ListItem Selected="True" Value="1">आवधिक</asp:ListItem>
                    <asp:ListItem Value="2">सालवसाली</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ७
            </td>
            <td>
                <strong>आयोजनाको अवधि प्रस्तावित जम्मा वर्ष</strong>
            </td>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-condensed table-bordered table-responsive">
                    <tr>
                        <td>
                            क
                        </td>
                        <td>
                            <strong>शुरु मिति:*</strong>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtSuruMiti"></asp:TextBox>
                        </td>
                        <td>
                            <strong>(वर्ष-महिना-दिन)</strong>
                        </td>
                        <td>
                            <strong>२०५८-०२-१९</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ख
                        </td>
                        <td>
                            <strong>आयोजना सम्पन्न मिति:*</strong>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAyojanaSampannaMiti"></asp:TextBox>
                        </td>
                        <td>
                            <strong>(वर्ष-महिना-दिन)</strong>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                    <tr>
                        <td>
                        </td>
                        <td colspan="5">
                            <asp:Button runat="server" ID="btnAddSansodhan" CssClass="btn-primary" Text="Add"
                                OnClick="btnAddSansodhan_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="5">
                            <table class="table-striped table-condensed table-responsive table-bordered">
                                <asp:Repeater ID="rptSansodhan" runat="server" OnItemDataBound="rptSansodhan_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr>
                                            <th>
                                            </th>
                                            <th>
                                                मिति
                                            </th>
                                            <th>
                                                (वर्ष-महिना-दिन)
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="sansodhan">
                                            <td>
                                                संशोधन
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtSansodhanDate" Text='<%# Eval("SANSODHAN_DATE") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.sansodhan').remove();"
                                                    EnableViewState="True" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <%-- </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddSansodhan" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>--%>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                ८
            </td>
            <td>
                <strong>क्षेत्र(sector)</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlSector" />
            </td>
        </tr>
        <tr>
            <td>
                ९
            </td>
            <td>
                <strong>उप-क्षेत्र(sub-sector)</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlSubSector" />
                <asp:HiddenField ID="hidSubSector" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                १०
            </td>
            <td>
                <strong>रणनीति</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlRananiti" />
                <asp:HiddenField ID="hidRananiti" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                ११
            </td>
            <td>
                <strong>कार्यनीति</strong>
            </td>
            <td colspan="4">
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:DropDownList runat="server" ID="ddlKaryaniti1" />
                            <asp:HiddenField ID="hidKaryaniti1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:DropDownList runat="server" ID="ddlKaryaniti2" />
                            <asp:HiddenField ID="hidKaryaniti2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:DropDownList runat="server" ID="ddlKaryaniti3" />
                            <asp:HiddenField ID="hidKaryaniti3" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <strong>दिगो विकास वा सहस्राब्दि विकास</strong>
            </td>
            <td>
                <%--<asp:DropDownList runat="server" ID="ddlSahasrabdiDigo">
                    <asp:ListItem Value="0">--छान्नुहोस--</asp:ListItem>
                    <asp:ListItem Value="1">सहस्राब्दि विकास लक्ष्य</asp:ListItem>
                    <asp:ListItem Value="2">दिगो विकास लक्ष्य</asp:ListItem>
                </asp:DropDownList>--%>
               
                    <asp:RadioButtonList runat="server"   ID="rbdSahaSrabdiDigo">
                        <asp:ListItem Value="1"  Text="सहस्राब्दि विकास लक्ष्य"></asp:ListItem>
                        <asp:ListItem Value="2" Text="दिगो विकास लक्ष्य"></asp:ListItem>
                    </asp:RadioButtonList>
                    <%--<asp:CheckBox runat="server" ID="chkSahaSrabdi" Text="सहस्राब्दि विकास लक्ष्य" />
                    <asp:CheckBox runat="server" ID="chkDigo" Text="दिगो विकास लक्ष्य" />--%>
            </td>
        </tr>
        <tr id="sahaSrabdi1" runat="server">
            <td>
                १२
            </td>
            <td>
                <strong>सहस्राब्दि विकास लक्ष्य</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlSahasabdiBikashLakshya" />
            </td>
        </tr>
        <tr id="sahaSrabdi2" runat="server">
            <td>
                १३
            </td>
            <td>
                <strong>सहस्राब्दि विकास गन्तव्य</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlSahasabdiBikashGantabya" />
                <asp:HiddenField ID="hidSahasabdiBikashGantabya" runat="server" />
            </td>
        </tr>
        <tr id="sahaSrabdi3" runat="server">
            <td>
                १४
            </td>
            <td>
                <strong>सहस्राब्दि विकास सुचक</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlSahasabdiBikashSuchak" />
                <asp:HiddenField runat="server" ID="hidSahasabdiBikashSuchak" />
            </td>
        </tr>
        <tr id="digo1" runat="server">
            <td>
                १५
            </td>
            <td>
                <strong>दिगो विकास लक्ष्य</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlDigoBikashLakshya" />
            </td>
        </tr>
        <tr id="digo2" runat="server">
            <td>
                १६
            </td>
            <td>
                <strong>दिगो विकास गन्तव्य</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlDigoBikashGantabya" />
                <asp:HiddenField ID="hidDigoBikashGantavya" runat="server" />
            </td>
        </tr>
        <tr id="digo3" runat="server">
            <td>
                १७
            </td>
            <td>
                <strong>दिगो विकास सूचक</strong>
            </td>
            <td colspan="4">
                <asp:DropDownList runat="server" ID="ddlDigoBikashSuchak" />
                <asp:HiddenField runat="server" ID="hidDigoBikashSuchak" />
            </td>
        </tr>
        <tr>
            <td>
                १८
            </td>
            <td>
                <strong>गरीबी संकेत</strong>
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rbdGaribiSankhet">
                    <asp:ListItem Value="1"> गरिबी निवारणमा प्रत्यक्ष योगदान पुर्याउने</asp:ListItem>
                    <asp:ListItem Value="2"> गरिबी निवारणमा अप्रत्यक्ष योगदान पुर्याउने</asp:ListItem>
                    <asp:ListItem Value="3"> अन्य</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                १९
            </td>
            <td>
                <strong>लैंङ्गिक संकेत</strong>
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rbdLaingikSankhet">
                    <asp:ListItem Value="1">लैङ्गिक समानताका लागी प्रत्यक्ष योगदान पुर्याउने </asp:ListItem>
                    <asp:ListItem Value="2"> लैङ्गिक समानताका लागी अप्रत्यक्ष योगदान पुर्याउने</asp:ListItem>
                    <asp:ListItem Value="3"> अन्य</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                २०
            </td>
            <td>
                <strong>जलवायू संकेत</strong>
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rbdJalBayuSanket">
                    <asp:ListItem Value="1">प्रत्यक्ष </asp:ListItem>
                    <asp:ListItem Value="2"> अप्रत्यक्ष</asp:ListItem>
                    <asp:ListItem Value="3"> तटस्थ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                २१
            </td>
            <td>
                <strong>रणनीतिक स्तम्भ (योजनाको रणनीति नं.)</strong>
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rbdYojanaRananiti">
                    <asp:ListItem Value="1">उत्पादन वृध्दि </asp:ListItem>
                    <asp:ListItem Value="2"> पूर्वाधार निर्माण</asp:ListItem>
                    <asp:ListItem Value="3">सामाजिक विकास </asp:ListItem>
                    <asp:ListItem Value="4"> सुशासन प्रवर्धन</asp:ListItem>
                    <asp:ListItem Value="5"> अन्तरसम्बन्धित विकास</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                २२
            </td>
            <td>
                <strong>आयोजनाको किसिम:</strong>
            </td>
            <td colspan="4">
                <asp:CheckBoxList runat="server" ID="chkAyojanaKisim">
                    <asp:ListItem Value="1">सेवा प्रधान</asp:ListItem>
                    <asp:ListItem Value="2">अनुसन्धान प्रधान</asp:ListItem>
                    <asp:ListItem Value="3">उत्पादन प्रधान</asp:ListItem>
                    <asp:ListItem Value="4">निर्माण प्रधान</asp:ListItem>
                    <asp:ListItem Value="5">सुशासन</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                २३
            </td>
            <td>
                <strong>मध्यमकालिन खर्च योजना(MTEF)अनुरुप प्राथमिकताक्रम</strong>
            </td>
            <td colspan="4">
                <asp:RadioButtonList runat="server" ID="rbdMadhyaKharchaYojana">
                    <asp:ListItem Value="1"> पहिलो प्राथमिकता</asp:ListItem>
                    <asp:ListItem Value="2"> दोस्रो प्राथमिकता</asp:ListItem>
                    <asp:ListItem Value="3"> तेस्रो प्राथमिकता</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                २४
            </td>
            <td colspan="5">
                <strong>कार्यान्वयन गर्ने निकाय:</strong>
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtKaryanayanNikaya"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <strong>आयोजनाको कुल लागत :</strong>
                <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtAyojanaLagat"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:CheckBox runat="server" Text="सक्रिय गर्नुहोस्" ID="chkEnable" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" CssClass="btn btn-primary" OnClick="btnAddEditProject_Click"
                    ID="btnSave" Text="Save & Continue" />
            </td>
            <%--<td>
                <asp:Button runat="server" CssClass="btn btn-warning" ID="btnCancel" Text="Reset" />
            </td>--%>
            <td colspan="4">
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {

            val = $('[id*=rbdSahaSrabdiDigo]').find('input:checked').val();

            if (val == 1) {
                $("#MainContent_sahaSrabdi1").show();
                $("#MainContent_sahaSrabdi2").show();
                $("#MainContent_sahaSrabdi3").show();
                $("#MainContent_digo1").hide();
                $("#MainContent_digo2").hide();
                $("#MainContent_digo3").hide();
            } else {
                $("#MainContent_sahaSrabdi1").hide();
                $("#MainContent_sahaSrabdi2").hide();
                $("#MainContent_sahaSrabdi3").hide();
                $("#MainContent_digo1").show();
                $("#MainContent_digo2").show();
                $("#MainContent_digo3").show();
            }

            $('#MainContent_rbdSahaSrabdiDigo').on('change', function () {
                debugger;
                val = $('[id*=rbdSahaSrabdiDigo]').find('input:checked').val();

                if (val == 1) {
                    $("#MainContent_sahaSrabdi1").show();
                    $("#MainContent_sahaSrabdi2").show();
                    $("#MainContent_sahaSrabdi3").show();
                    $("#MainContent_digo1").hide();
                    $("#MainContent_digo2").hide();
                    $("#MainContent_digo3").hide();
                } else {
                    $("#MainContent_sahaSrabdi1").hide();
                    $("#MainContent_sahaSrabdi2").hide();
                    $("#MainContent_sahaSrabdi3").hide();
                    $("#MainContent_digo1").show();
                    $("#MainContent_digo2").show();
                    $("#MainContent_digo3").show();
                }
            });
        });

        
        $("#MainContent_ddlSector").change(function () {
            var id = $("#MainContent_ddlSector").val();
            //resetAll(1);
            LoadSubSectorBySectorId();
        });


        function LoadSubSectorBySectorId() {
            //load another dropdown
            var sectorId = $("#MainContent_ddlSector").val();

            $("#MainContent_ddlSubSector").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindSubSectorBySectorId",
                data: "{sectorId:'" + sectorId + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindSubSectorDdl(msg.d);
                }
            });

            function BindSubSectorDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlSubSector").append($("<option></option>").val(this['ComboId']).html(this['Name']));
                });
            }
        }

        $("#MainContent_ddlSubSector").change(function () {
            var id = $("#MainContent_ddlSubSector").val();
            //resetAll(2);
            LoadRananitiBySubSectorId();
        });

        function LoadRananitiBySubSectorId() {
            //load another dropdown
            var subSectorId = $("#MainContent_ddlSubSector").val();

            $("#MainContent_ddlRananiti").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindRananitiBySectorId",
                data: "{subSectorId:'" + subSectorId + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindRaninitiDdl(msg.d);
                }
            });

            function BindRaninitiDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlRananiti").append($("<option></option>").val(this['ComboId']).html(this['Name']));
                });
            }
        }

        $("#MainContent_ddlRananiti").change(function () {

            var id = $("#MainContent_ddlRananiti").val();
            //resetAll(3);
            LoadKaryanitiByRananitiId();
        });

        function LoadKaryanitiByRananitiId() {
            //load another dropdown
            debugger;
            var rananitiId = $("#MainContent_ddlRananiti").val();
            $("#MainContent_ddlKaryaniti1").html("");
            $("#MainContent_ddlKaryaniti2").html("");
            $("#MainContent_ddlKaryaniti3").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindKaryanitiByRananitiId",
                data: "{rananitiId:'" + rananitiId + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindKaryanitiDdl(msg.d);
                }
            });

            function BindKaryanitiDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlKaryaniti1").append($("<option></option>").val(this['ComboId']).html(this['Name']));
                    $("#MainContent_ddlKaryaniti2").append($("<option></option>").val(this['ComboId']).html(this['Name']));
                    $("#MainContent_ddlKaryaniti3").append($("<option></option>").val(this['ComboId']).html(this['Name']));
                });
            }
        }

        $("#MainContent_ddlSahasabdiBikashLakshya").change(function () {

            var id = $("#MainContent_ddlSahasabdiBikashLakshya").val();
            // resetAll(3);
            LoadSahasabdiBikashGantabya(id);
        });

        function LoadSahasabdiBikashGantabya(id) {
            //load another dropdown
            debugger;
            $("#MainContent_ddlSahasabdiBikashGantabya").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindSahasabdiBikashGantabyaByLakshya",
                data: "{lakshyaId:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindGantabyaDdl(msg.d);
                }
            });

            function BindGantabyaDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlSahasabdiBikashGantabya").append($("<option></option>").val(this['ComboId']).html(this['Name']));

                });
            }
        }

        $("#MainContent_ddlSahasabdiBikashGantabya").change(function () {

            var id = $("#MainContent_ddlSahasabdiBikashGantabya").val();
            //resetAll(3);
            LoadSahasabdiBikashSuchak(id);
        });

        function LoadSahasabdiBikashSuchak(id) {
            //load another dropdown
            debugger;
            $("#MainContent_ddlSahasabdiBikashSuchak").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindSahasabdiBikashSuchakByGantabya",
                data: "{gantabyaId:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindSuchakDdl(msg.d);
                }
            });

            function BindSuchakDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlSahasabdiBikashSuchak").append($("<option></option>").val(this['ComboId']).html(this['Name']));

                });
            }
        }

        $("#MainContent_ddlDigoBikashLakshya").change(function () {
            var id = $("#MainContent_ddlDigoBikashLakshya").val();
            LoadDigoBikashGantabya(id);
        });

        function LoadDigoBikashGantabya(id) {
            $("#MainContent_ddlDigoBikashGantabya").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindDigoBikashGantabyaByLakshya",
                data: "{lakshyaId:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    BindDigoGantabyaDdl(msg.d);
                }
            });

            function BindDigoGantabyaDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlDigoBikashGantabya").append($("<option></option>").val(this['ComboId']).html(this['Name']));

                });
            }
        }

        $("#MainContent_ddlDigoBikashGantabya").change(function () {
            var id = $("#MainContent_ddlDigoBikashGantabya").val();
            LoadDigoBikashSuchak(id);
        });

        function LoadDigoBikashSuchak(id) {
            //load another dropdown
            $("#MainContent_ddlDigoBikashSuchak").html("");
            $.ajax({
                type: "POST",
                url: "../../WebService1.asmx/FindDigoBikashSuchakByGantabya",
                data: "{gantabyaId:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    dataType: "json",
                    bindDigoSuchakDdl(msg.d);
                }
            });

            function bindDigoSuchakDdl(msg) {
                $.each(msg, function () {
                    $("#MainContent_ddlDigoBikashSuchak").append($("<option></option>").val(this['ComboId']).html(this['Name']));

                });
            }
        }

        function resetAll(id) {
            if (id == 1) {
                $("#MainContent_ddlSubSector").val(0);
                $("#MainContent_ddlRananiti").val(0);
                $("#MainContent_ddlKaryaniti1").val(0);
                $("#MainContent_ddlKaryaniti2").val(0);
                $("#MainContent_ddlKaryaniti3").val(0);
            }
            if (id == 2) {
                $("#MainContent_ddlRananiti").val(0);
                $("#MainContent_ddlKaryaniti1").val(0);
                $("#MainContent_ddlKaryaniti2").val(0);
                $("#MainContent_ddlKaryaniti3").val(0);
            }
            if (id == 3) {
                $("#MainContent_ddlKaryaniti1").val(0);
                $("#MainContent_ddlKaryaniti2").val(0);
                $("#MainContent_ddlKaryaniti3").val(0);
            }

        }

        function removeOptions(selectbox) {
            debugger;
            var i;
            if (selectbox.options.length > 0) {
                for (i = selectbox.options.length - 1; i >= 0; i--) {
                    selectbox.remove(i);
                }
            }
        }

        $("#MainContent_ddlSubSector").change(function () {
            $("#MainContent_hidSubSector").val($("#MainContent_ddlSubSector").val());
        });
        $("#MainContent_ddlRananiti").change(function () {
            $("#MainContent_hidRananiti").val($("#MainContent_ddlRananiti").val());
        });
        $("#MainContent_ddlKaryaniti1").change(function () {
            $("#MainContent_hidKaryaniti1").val($("#MainContent_ddlKaryaniti1").val());
        });
        $("#MainContent_ddlKaryaniti2").change(function () {
            $("#MainContent_hidKaryaniti2").val($("#MainContent_ddlKaryaniti2").val());
        });
        $("#MainContent_ddlKaryaniti3").change(function () {
            $("#MainContent_hidKaryaniti3").val($("#MainContent_ddlKaryaniti3").val());
        });
        $("#MainContent_ddlSahasabdiBikashGantabya").change(function () {
            $("#MainContent_hidSahasabdiBikashGantabya").val($("#MainContent_ddlSahasabdiBikashGantabya").val());
        });
        $("#MainContent_ddlSahasabdiBikashSuchak").change(function () {
            $("#MainContent_hidSahasabdiBikashSuchak").val($("#MainContent_ddlSahasabdiBikashSuchak").val());
        });
        $("#MainContent_ddlDigoBikashGantabya").change(function () {
            $("#MainContent_hidDigoBikashGantavya").val($("#MainContent_ddlDigoBikashGantabya").val());
        });
        $("#MainContent_ddlDigoBikashSuchak").change(function () {
            $("#MainContent_hidDigoBikashSuchak").val($("#MainContent_ddlDigoBikashSuchak").val());
        });
    </script>
</asp:Content>
