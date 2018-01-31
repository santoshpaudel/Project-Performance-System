<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BarsikKaryekram.aspx.cs"
    Inherits="MISUI.Modules.BarsikKaryekram.BarsikKaryekram" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-dismissible alert-info pull-right" style="padding: 5px;">
        <%=GetLabel("Last Modified By")%>:&nbsp;<asp:Label runat="server" ID="lblModifiedBy"></asp:Label><br />
        <%=GetLabel("Last Modified On")%>:&nbsp;<asp:Label runat="server" ID="lblModification"></asp:Label>
    </div>
    
    <div class="setId">
    </div>
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table class="table-striped table-condensed table-responsive table-bordered aayojana">
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
                                    आयोजनाको कुल रकम
                                </th>
                                <th>
                                    प्रथम चौमासिक
                                </th>
                                <th>
                                    दोस्रो चौमासिक
                                </th>
                                <th>
                                    तेस्रो चौमासिक
                                </th>
                                <th>
                                    बार्षिक कुल रकम
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hidBadfadId" runat="server" Value='<%# Eval("BADFAD_ID") %>' />
                                    <asp:DropDownList Enabled="False" runat="server" ID="ddlShrot" />
                                </td>
                                <td>
                                    <asp:DropDownList Enabled="False" runat="server" ID="ddlBhuktaniPrakar" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Enabled="False" onchange="unicodeToEngNumber(this)" ID="txtRakam"
                                        Text='<%# Eval("RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtFirstTRakam"
                                        Text='<%# Eval("FIRST_T_RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtSecondTRakam"
                                        Text='<%# Eval("SECOND_T_RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtThirdTRakam"
                                        Text='<%# Eval("THIRD_T_RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtBarshikShrotKul"></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td style="border-right: 1px solid">
            </td>
            <td style="border-right: 1px solid" colspan="2">
                बार्षिक
            </td>
            <td colspan="2" align="center" style="border-right: 1px solid">
                प्रथम
            </td>
            <td colspan="2" align="center" style="border-right: 1px solid">
                दोस्रो
            </td>
            <td colspan="2" align="center" style="border-right: 1px solid">
                तेस्रो
            </td>
        </tr>
        <tr>
            <td style="border-right: 1px solid">
            </td>
            <td>
                संख्या
            </td>
            <td style="border-right: 1px solid">
                रकम
            </td>
            <td>
                संख्या
            </td>
            <td style="border-right: 1px solid">
                रकम
            </td>
            <td>
                संख्या
            </td>
            <td style="border-right: 1px solid">
                रकम
            </td>
            <td>
                संख्या
            </td>
            <td>
                रकम
            </td>
        </tr>
        <tr>
            <td style="border-right: 1px solid">
                परामर्शदाता-स्वदेशी
            </td>
            <td>
                <asp:TextBox ID="txtPSBNo" Enabled="False" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtPSBRakam" Enabled="False" onchange="unicodeToEngNumber(this)"
                    Width="100px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPSFirstTNo" onchange="unicodeToEngNumber(this)" runat="server"
                    Width="100px"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtPSFirstTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPSSecondTNo" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtPSSSecondTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPSThirdTNo" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPSThirdTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="border-right: 1px solid">
                परामर्शदाता-विदेशी
            </td>
            <td>
                <asp:TextBox ID="txtPBBNo" Enabled="False" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox Enabled="False" ID="txtPBBRakam" onchange="unicodeToEngNumber(this)"
                    Width="100px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPBFirstTNo" runat="server" Width="100px" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtPBFirstTRakam" Width="100px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPBSecondTNo" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtPBSecondTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPBThirdTNo" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtPBThirdTRakam" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="border-right: 1px solid">
                ठेक्का
            </td>
            <td>
                <asp:TextBox ID="txtThekaBNo" Enabled="False" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox Enabled="False" ID="txtThekaBRakam" onchange="unicodeToEngNumber(this)"
                    Width="100px" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtThekaFirstTNo" runat="server" Width="100px" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtThekaFirstTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtThekaSecondTNO" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td style="border-right: 1px solid">
                <asp:TextBox ID="txtThekaSecondTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtThekaThirdTNo" Width="100px" runat="server" onchange="unicodeToEngNumber(this)"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtThekaThirdTRakam" Width="100px" onchange="unicodeToEngNumber(this)"
                    runat="server"></asp:TextBox>
            </td>
            <asp:HiddenField ID="hidThekaParamarsaId" runat="server" />
            <asp:HiddenField ID="hidBarshikAnyaId" runat="server" />
        </tr>
    </table>
    <table class="table table-striped table-condensed table-bordered table-responsive">
        <tr>
            <td>
            </td>
            <td>
                बार्षिक
            </td>
            <td>
                प्रथम चौमासिक
            </td>
            <td>
                दोस्रो चौमासिक
            </td>
            <td>
                तेस्रो चौमासिक
            </td>
            <td>
                कैफियत
            </td>
        </tr>
        <tr>
            <td>
                अन्य
            </td>
            <td>
                <asp:TextBox Enabled="False" ID="txtAnyaBarshik" onchange="unicodeToEngNumber(this)"
                    runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtAnyaFirst" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtAnyaSecond" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtAnyaThird" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtAnyaRemarks" onchange="unicodeToEngNumber(this)" runat="server"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="table table-striped table-condensed table-bordered table-responsive">
        <tr>
            <td>
            </td>
            <td>
                बार्षिक
            </td>
            <td>
                प्रथम चौमासिक
            </td>
            <td>
                दोस्रो चौमासिक
            </td>
            <td>
                तेस्रो चौमासिक
            </td>
        </tr>
        <tr>
            <td>
                बार्षिक भारित लक्ष्य:
            </td>
            <td>
                <asp:TextBox ID="txtBarshik" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtFirstBharit" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtSecondBharit" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtThirdBharit" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
            </td>
            <asp:HiddenField ID="hidBarshikBharitId" runat="server" />
        </tr>
    </table>
    <table>
        <tr>
            <td>
                वार्षिक कार्यक्रम र्फाइल अपलोड:
            </td>
            <td colspan="5">
                <asp:FileUpload runat="server" ID="FileBarshikUpload" AllowMultiple="true" />
            </td>
            <td>
                <%--<span class="style2">फाइल</span>: 
                <a id="aBarshikFile" runat="server" target="_blank" ></a>--%>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Label runat="server" ForeColor="red" ID="lblFileWarning">नयाँ फाइल ब्राउज गरी अपलोड गर्दा पूरानो फाइल हट्नेछ।</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:GridView ID="grdUploadedFiles" runat="server" CssClass="table table-bordered table-striped table-responsive"
                    OnRowCommand="grdUploadedFiles_RowCommand" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="FILE_NAME" HeaderText="File Name" />
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/img/view.png" ToolTip="View File"
                                    Width="20" Height="20" CommandName="View" CommandArgument='<%#Eval("FILE_NAME") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <script>
        //आयोजनाको कुल रकम
        $(document).ready(function () {
            var totalBarshikRakam = 0;
            var rowLength = $(".aayojana tr:visible").length - 1;
            var paramarshaThekkaTotal = 0;
            var paramarshaSwadeshi = $("#MainContent_txtPSBRakam").val();
            var paramarshaBideshi = $("#MainContent_txtPBBRakam").val();
            var thekka = $("#MainContent_txtThekaBRakam").val();
            paramarshaThekkaTotal = ((parseInt(paramarshaSwadeshi) || 0) + (parseInt(paramarshaBideshi) || 0) + (parseInt(thekka) || 0));
            for (var i = 0; i < rowLength; i++) {
                var initialfirstRakamID = "#MainContent_rptAayojanaBadfad_txtFirstTRakam_" + i;
                var secRakamID = "#MainContent_rptAayojanaBadfad_txtSecondTRakam_" + i;
                var thRakamID = "#MainContent_rptAayojanaBadfad_txtThirdTRakam_" + i;
                //initilly populate barshik total
                var barshikTotal = 0;
                var frstRakam = $(initialfirstRakamID).val();
                var secRakam = $(secRakamID).val();
                var thRakam = $(thRakamID).val();
                barshikTotal = ((parseInt(frstRakam) || 0) + (parseInt(secRakam) || 0) + (parseInt(thRakam) || 0));
                bindBarshik(barshikTotal, i);
                totalBarshikRakam += barshikTotal;

                $(initialfirstRakamID).keyup(function (e) {
                    var focused = document.activeElement.id;
                    var j = focused.split("_").pop();
                    var secondRakamID = "#MainContent_rptAayojanaBadfad_txtSecondTRakam_" + j;
                    var secondRakam = $(secondRakamID).val();
                    var thirdRakamID = "#MainContent_rptAayojanaBadfad_txtThirdTRakam_" + j;
                    var thirdRakam = $(thirdRakamID).val();
                    var pass = (parseInt(thirdRakam) || 0) + (parseInt(secondRakam) || 0) + (parseInt($(this).val()) || 0);
                    callThird(pass, j);
                });
                $(secRakamID).keyup(function (e) {
                    var focused = document.activeElement.id;
                    var j = focused.split("_").pop();
                    var firstRakamID = "#MainContent_rptAayojanaBadfad_txtFirstTRakam_" + j;
                    var firstRakam = $(firstRakamID).val();
                    var thirdRakamID = "#MainContent_rptAayojanaBadfad_txtThirdTRakam_" + j;
                    var thirdRakam = $(thirdRakamID).val();
                    var pass = (parseInt(thirdRakam) || 0) + (parseInt(firstRakam) || 0) + (parseInt($(this).val()) || 0);
                    callThird(pass, j);
                });
                $(thRakamID).keyup(function (e) {
                    var focused = document.activeElement.id;
                    var j = focused.split("_").pop();
                    var firstRakamID = "#MainContent_rptAayojanaBadfad_txtFirstTRakam_" + j;
                    var firstRakam = $(firstRakamID).val();
                    var secondRakamID = "#MainContent_rptAayojanaBadfad_txtSecondTRakam_" + j;
                    var secondRakam = $(secondRakamID).val();
                    var pass = (parseInt(secondRakam) || 0) + (parseInt(firstRakam) || 0) + (parseInt($(this).val()) || 0);
                    callThird(pass, j);
                });
            }
            var barshikTotalID = "#MainContent_rptAayojanaBadfad_txtBarshikShrotKul_";

            function callThird(pass, j) {
                $(barshikTotalID + j).val(pass);
            }

            function bindBarshik(b, i) {
                var barshikId = "#MainContent_rptAayojanaBadfad_txtBarshikShrotKul_";
                $(barshikId + i).val(b);
            }

            if (parseInt(totalBarshikRakam) == 0) {
                var anyaBarshikTotal = 0;

                $("#MainContent_txtAnyaBarshik").val(anyaBarshikTotal);
            }
            else if (parseInt(totalBarshikRakam)) {
                var anyaBarshikTotal = totalBarshikRakam - paramarshaThekkaTotal;

                $("#MainContent_txtAnyaBarshik").val(anyaBarshikTotal);
            }

        });

        //validation for anya
        $("#MainContent_txtAnyaFirst").keyup(function () {
            var totalAnya = $("#MainContent_txtAnyaBarshik").val();
            if (parseInt($(this).val()) > parseInt(totalAnya)) {
                $(this).val(0);
                alert("प्रथम चौमासिक रकम कुल भन्दा भन्दा बढी भयो");
            }
            var secAnya = $("#MainContent_txtAnyaSecond").val();
            var a = parseInt(totalAnya) - (parseInt(secAnya) || 0) - (parseInt($(this).val()) || 0);
            validateAnya(a);
        });

        $("#MainContent_txtAnyaSecond").keyup(function () {
            var totalAnya = $("#MainContent_txtAnyaBarshik").val();
            var firstAnya = $("#MainContent_txtAnyaFirst").val();
            var secAnyaRakam = $(this).val();
            var secVal = parseInt(totalAnya) - parseInt(firstAnya);
            if (parseInt(secAnyaRakam) > (secVal)) {
                $(this).val(0);
                alert("दोस्रो चौमासिक रकम कुल भन्दा भन्दा बढी भयो");
            }
            var a = parseInt(totalAnya) - (parseInt(firstAnya) || 0) - (parseInt($(this).val()) || 0);
            validateAnya(a);
        });

        function validateAnya(a) {
            $("#MainContent_txtAnyaThird").val(a);
        }



        $("#MainContent_txtPSFirstTNo, #MainContent_txtPSFirstTRakam, #MainContent_txtPBFirstTNo, #MainContent_txtPBFirstTRakam, #MainContent_txtThekaFirstTNo,#MainContent_txtThekaFirstTRakam").keyup(function () {
            var totalFirstParmarshaSwadeshi = $("#MainContent_txtPSBNo").val();
            var totalFirstCount = parseInt(totalFirstParmarshaSwadeshi);
            if (parseInt($("#MainContent_txtPSFirstTNo").val()) > totalFirstCount) {
                $("#MainContent_txtPSFirstTNo").val(0);
                alert("प्रथम परामर्शदाता-स्वदेशी संख्या कुल भन्दा भन्दा बढी भयो");
            }
            var secCountSwadeshi = $("#MainContent_txtPSSecondTNo").val();
            var p = parseInt(totalFirstCount) - (parseInt(secCountSwadeshi) || 0) - (parseInt($("#MainContent_txtPSFirstTNo").val()) || 0);
            validateThird(p);

            var totalParmarshaSwadeshiRakam = $("#MainContent_txtPSBRakam").val();
            if (parseInt($("#MainContent_txtPSFirstTRakam").val()) > parseInt(totalParmarshaSwadeshiRakam)) {
                $("#MainContent_txtPSFirstTRakam").val(0);
                alert("प्रथम परामर्शदाता-स्वदेशी रकम कुल भन्दा भन्दा बढी भयो");
            }
            var secParamarshaRakamSwadeshi = $("#MainContent_txtPSSSecondTRakam").val();
            var rakam = parseInt(totalParmarshaSwadeshiRakam) - (parseInt(secParamarshaRakamSwadeshi) || 0) - (parseInt($("#MainContent_txtPSFirstTRakam").val()) || 0);
            validateThirdRakamSwadeshi(rakam);

            var totalPBNo = $("#MainContent_txtPBBNo").val();
            if (parseInt($("#MainContent_txtPBFirstTNo").val()) > parseInt(totalPBNo)) {
                alert("प्रथम परामर्शदाता-विदेशी संख्या कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtPBFirstTNo").val(0);
            }
            var secPBNo = $("#MainContent_txtPBSecondTNo").val();
            var num = parseInt(totalPBNo) - (parseInt(secPBNo) || 0) - (parseInt($("#MainContent_txtPBFirstTNo").val()) || 0);
            validatePBNo(num);

            var totalPBRakam = $("#MainContent_txtPBBRakam").val();
            if (parseInt($("#MainContent_txtPBFirstTRakam").val()) > parseInt(totalPBRakam)) {
                alert("प्रथम परामर्शदाता-विदेशी रकम कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtPBFirstTRakam").val(0);
            }
            var secPBRakam = $("#MainContent_txtPBSecondTRakam").val();
            var sPBRakam = parseInt(totalPBRakam) - (parseInt(secPBRakam) || 0) - (parseInt($("#MainContent_txtPBFirstTRakam").val()) || 0);
            validatePBRakam(sPBRakam);

            var totalThekkaNo = $("#MainContent_txtThekaBNo").val();
            if (parseInt($("#MainContent_txtThekaFirstTNo").val()) > parseInt(totalThekkaNo)) {
                alert("प्रथम ठेक्का संख्या कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtThekaFirstTNo").val(0);
            }
            var secThekkaNo = $("#MainContent_txtThekaSecondTNO").val();
            var thekkaNo = parseInt(totalThekkaNo) - (parseInt(secThekkaNo) || 0) - (parseInt($("#MainContent_txtThekaFirstTNo").val()) || 0);
            validateThekkaNo(thekkaNo);

            var totalThekkaRakam = $("#MainContent_txtThekaBRakam").val();
            if (parseInt($("#MainContent_txtThekaFirstTRakam").val()) > parseInt(totalThekkaRakam)) {
                alert("प्रथम ठेक्का रकम कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtThekaFirstTRakam").val(0);
            }
            var secThekkaRakam = $("#MainContent_txtThekaSecondTRakam").val();
            var thekkaRakam = parseInt(totalThekkaRakam) - (parseInt(secThekkaRakam) || 0) - (parseInt($("#MainContent_txtThekaFirstTRakam").val()) || 0);
            validateThekkaRakam(thekkaRakam);
        });


        $("#MainContent_txtPSSecondTNo,#MainContent_txtPBSecondTNo, #MainContent_txtPSSSecondTRakam,#MainContent_txtPBSecondTRakam, #MainContent_txtThekaSecondTNO, #MainContent_txtThekaSecondTRakam").keyup(function () {
            var totalFirstParmarshaSwadeshi = $("#MainContent_txtPSBNo").val();
            var firstCount = $("#MainContent_txtPSFirstTNo").val();
            var secCountSwadeshi = $("#MainContent_txtPSSecondTNo").val();
            var secVal = parseInt(totalFirstParmarshaSwadeshi) - parseInt(firstCount);
            if (parseInt(secCountSwadeshi) > (secVal)) {
                $("#MainContent_txtPSSecondTNo").val(0);
                alert("दोस्रो परामर्शदाता-स्वदेशी संख्या कुल भन्दा भन्दा बढी भयो");
            }
            var p = parseInt(totalFirstParmarshaSwadeshi) - (parseInt(firstCount) || 0) - (parseInt(secCountSwadeshi) || 0);
            validateThird(p);

            var totalPSSRakam = $("#MainContent_txtPSBRakam").val();
            var firstPSSRakam = $("#MainContent_txtPSFirstTRakam").val();
            var secPSSRakam = $("#MainContent_txtPSSSecondTRakam").val();
            var secPSSVal = parseInt(totalPSSRakam) - parseInt(firstPSSRakam);
            if (parseInt(secPSSRakam) > secPSSVal) {
                alert("दोस्रो परामर्शदाता-स्वदेशी रकम कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtPSSSecondTRakam").val(0);
            }
            var rakam = parseInt(totalPSSRakam) - (parseInt(firstPSSRakam) || 0) - (parseInt(secPSSRakam) || 0);
            validateThirdRakamSwadeshi(rakam);

            var totalPBNo = $("#MainContent_txtPBBNo").val();
            var firstPBNo = $("#MainContent_txtPBFirstTNo").val();
            var secPBNo = $("#MainContent_txtPBSecondTNo").val();
            var secPBVal = parseInt(totalPBNo) - parseInt(firstPBNo);
            if (parseInt(secPBNo) > secPBVal) {
                alert("दोस्रो परामर्शदाता-विदेशी 	संख्या कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtPBSecondTNo").val(0);
            }
            var n = parseInt(totalPBNo) - (parseInt(firstPBNo) || 0) - (parseInt(secPBNo) || 0);
            validatePBNo(n);

            var totalPBRakam = $("#MainContent_txtPBBRakam").val();
            var firstPBRakam = $("#MainContent_txtPBFirstTRakam").val();
            var secPBRakam = $("#MainContent_txtPBSecondTRakam").val();
            var secPBRakamVal = parseInt(totalPBRakam) - parseInt(firstPBRakam);
            if (parseInt(secPBRakam) > secPBRakamVal) {
                alert("दोस्रो परामर्शदाता-विदेशी रकम कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtPBSecondTRakam").val(0);
            }
            var n = parseInt(totalPBRakam) - (parseInt(firstPBRakam) || 0) - (parseInt(secPBRakam) || 0);
            validatePBRakam(n);

            var totalThekkaNo = $("#MainContent_txtThekaBNo").val();
            var firstTHNo = $("#MainContent_txtThekaFirstTNo").val();
            var secTHNo = $("#MainContent_txtThekaSecondTNO").val();
            var secTHnVal = parseInt(totalThekkaNo) - parseInt(firstTHNo);
            if (parseInt(secTHNo) > secTHnVal) {
                alert("दोस्रो ठेक्का	संख्या कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtThekaSecondTNO").val(0);
            }
            var thekkaNo = parseInt(totalThekkaNo) - (parseInt(firstTHNo) || 0) - (parseInt(secTHNo) || 0);
            validateThekkaNo(thekkaNo);

            var totalThekkaRakam = $("#MainContent_txtThekaBRakam").val();
            var firstTHRakam = $("#MainContent_txtThekaFirstTRakam").val();
            var secTHRakam = $("#MainContent_txtThekaSecondTRakam").val();
            var secTHRVal = parseInt(totalThekkaRakam) - parseInt(firstTHRakam);
            if (parseInt(secTHRakam) > secTHRVal) {
                alert("दोस्रो ठेक्का	रकम कुल भन्दा भन्दा बढी भयो");
                $("#MainContent_txtThekaSecondTRakam").val(0);
            }
            var thekkaRakam = parseInt(totalThekkaRakam) - (parseInt(firstTHRakam) || 0) - (parseInt(secTHRakam) || 0);
            validateThekkaRakam(thekkaRakam);
        });

        function validateThird(p) {
            $("#MainContent_txtPSThirdTNo").val(p);
        }
        function validateThirdRakamSwadeshi(rakam) {
            $("#MainContent_txtPSThirdTRakam").val(rakam);
        }

        function validatePBNo(n) {
            $("#MainContent_txtPBThirdTNo").val(n);
        }

        function validatePBRakam(n) {
            $("#MainContent_txtPBThirdTRakam").val(n);
        }

        function validateThekkaNo(thekkaNo) {
            $("#MainContent_txtThekaThirdTNo").val(thekkaNo);
        }

        function validateThekkaRakam(thekkaRakam) {
            $("#MainContent_txtThekaThirdTRakam").val(thekkaRakam);
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            color: #006600;
        }
    </style>
</asp:Content>
