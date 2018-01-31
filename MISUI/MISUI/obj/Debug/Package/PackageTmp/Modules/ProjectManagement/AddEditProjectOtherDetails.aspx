<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddEditProjectOtherDetails.aspx.cs" Inherits="MISUI.Modules.ProjectManagement.AddEditProjectOtherDetails" %>

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
    <table class="table table-bordered table-condensed table-responsive table-striped">
        <%--<tr>
            <td colspan="6">
                बजेट शीर्षक:
                <asp:DropDownList runat="server" ID="ddlBudgetHead" AutoPostBack="True" OnSelectedIndexChanged="ddlBudgetHead_SelectedIndexChanged"/>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                आयोजना:
                <asp:DropDownList runat="server" ID="ddlProject" AutoPostBack="True"  OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"/>
            
            </td>
        </tr>--%>
        <tr>
            <td>
                <a href="javascript: history.go(-1)">Go Back</a>
            </td>
        </tr>
        <tr>
            <td>
                ३४
            </td>
            <td colspan="5">
                <strong>परामर्श सम्बन्धि विवरण:</strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-bordered table-condensed table-responsive">
                    <tr>
                        <td colspan="5">
                            <strong>क) आयोजनाको परामर्शदाताको लागि हुने खर्च रकम:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="btnAddParamarsaBibaran" runat="server" Text="‌‍‌+थप्नुहोस्" CssClass="btn btn-warning"
                                OnClick="btnAddParamarsaBibaranRow_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <table class="table-striped table-condensed table-responsive table-bordered">
                                <asp:Repeater ID="rptParamarsaBibaran" runat="server" OnItemDataBound="rptParamarsaBibaran_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr>
                                            <th>
                                                आ.ब
                                            </th>
                                            <th>
                                                रकम (स्वदेशी)
                                            </th>
                                            <th>
                                                रकम (विदेशी)
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="paramarsha">
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlAaba" />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                                    ID="txtRakamSwadeshi" Text='<%# Eval("RAKAM_SWADESHI") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                                    ID="txtRakamBideshi" Text='<%# Eval("RAKAM_BIDESHI") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.paramarsha').remove();"
                                                    EnableViewState="True" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-bordered table-condensed table-responsive">
                    <tr>
                        <td colspan="5">
                            <strong>ख) आयोजनामा रहने परामर्शदाताको संख्या:</strong>
                        </td>
                    </tr>
                    <%--  <tr>
                        <td colspan="5">
                            <strong>आयोजनामा रहने कुल परामर्शदाताको संख्या</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>स्वदेशी:</strong>
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress = "return setUnicode(event,this);" onchange="unicodeToEngNumber(this)" ID="txtSwadeshi"></asp:TextBox>
                        </td>
                        <td>
                            <strong>विदेशी</strong>
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress = "return setUnicode(event,this);" onchange="unicodeToEngNumber(this)" ID="txtBideshi"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="btnParamarshaSankhya" runat="server" Text="‌‍‌+थप्नुहोस्" CssClass="btn btn-warning"
                                OnClick="btnParamarshaSankhya_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <table class="table-striped table-condensed table-responsive table-bordered">
                                <asp:Repeater ID="rptParamarshaSankhya" runat="server" OnItemDataBound="rptParamarshaSankhya_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr>
                                            <th rowspan="2">
                                                आ.ब
                                            </th>
                                            <th colspan="2">
                                                स्वदेशी
                                            </th>
                                            <th colspan="2">
                                                विदेशी
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                संख्या
                                            </th>
                                            <th>
                                                श्रम दिन
                                            </th>
                                            <th>
                                                संख्या
                                            </th>
                                            <th>
                                                श्रम दिन
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="shram">
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlAaba" />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                                    ID="txtSwadeshiSankhya" Text='<%# Eval("SWADESHI") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                                    ID="txtSwadeshiShramDin" Text='<%# Eval("SWADESHI_SHRAM_DIN") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                                    ID="txtBideshiSankhya" Text='<%# Eval("BIDESHI") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                                    ID="txtBideshiShramDin" Text='<%# Eval("BIDESHI_SHRAM_DIN") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.shram').remove();"
                                                    EnableViewState="True" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                ३५
            </td>
            <td colspan="5">
                <strong>आयोजनाको ठेक्का संख्या र रकम</strong>
            </td>
        </tr>
        <%-- <tr>
            <td></td>
            <td colspan="5">
                <table class="table table-condensed table-responsive">
                    <tr>
                        <td colspan="5"><strong>आयोजना अवधिको</strong></td>
                    </tr>
                    <tr>
                        <td>संख्या</td>
                        <td>रकम</td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" onKeypress = "return setUnicode(event,this);" onchange="unicodeToEngNumber(this)" ID="txtThekkaSankhya"></asp:TextBox></td>
                        <td><asp:TextBox runat="server" onKeypress = "return setUnicode(event,this);" onchange="unicodeToEngNumber(this)" ID="txtThekkaRakam"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Button ID="btnAddThekkaSankhyaRakam" runat="server" Text="‌‍‌+थप्नुहोस्" CssClass="btn btn-warning"
                    OnClick="btnAddThekkaSankhyaRakam_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table-striped table-condensed table-responsive table-bordered">
                    <asp:Repeater ID="rptThekkaSankhyaRakam" runat="server" OnItemDataBound="rptThekkaSankhyaRakam_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <th>
                                    आ.ब
                                </th>
                                <th>
                                    संख्या
                                </th>
                                <th>
                                    रकम
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="thekka">
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlAaba" />
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtThekkaSankhya" Text='<%# Eval("THEKKA_SANKHYA") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        ID="txtThekkaRakam" Text='<%# Eval("THEKKA_RAKAM") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.thekka').remove();"
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
                ३६
            </td>
            <td colspan="5">
                <strong>आयोजनाको कार्यान्वयनबाट हुने लाभ र लाभको प्रकृति</strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table table-condensed table-responsive">
                    <tr>
                        <td>
                           
                        </td>
                        <td><strong>
                            उपयोगी हुने/नहुने
                            </strong>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkIsUsable"/>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            क.
                        </td>
                        <td colspan="4">
                            लाभान्वित भएको कुल जनसङ्ख्या
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            महिला
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtLavanbitMahila"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" 
                                ID="txtLavanbitMahilaKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            बालबालिका
                        </td>
                        <td>
                            <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)"
                                ID="txtLavanbitBalBalika"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" 
                                ID="txtLavanbitBalKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            आदिवासी/जनजाती
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtLavanbitJanajati"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" 
                                ID="txtLavanbitJanaKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            दलित
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtLavanbitDalit"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" 
                                ID="txtLavanbitDalitKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            मधेशी
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtLavanbitMadhesi"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" 
                                ID="txtLavanbitMadhesiKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            मुश्लिम
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtLavanbitMuslim"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" 
                                ID="txtLavanbitMuslimKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            अन्य
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtAnya"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" 
                                ID="txtAnyaKaifiyat" placeholder="कैफियत"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ख.
                        </td>
                        <td>
                            रोजगारी सिर्जना सङ्ख्या (श्रम दिन)
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtShramDin"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ग.
                        </td>
                        <td>
                            उत्पादनमा बृद्धि हुने अनुमानित परिमाण
                        </td>
                        <td>
                            <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)"
                                ID="txtParimaan"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            घ.
                        </td>
                        <td>
                            क्षेत्रीय सन्तुलनमा हुने योगदान
                        </td>
                        <td>
                            <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtYogdan"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                ३७
            </td>
            <td>
                जग्गा प्राप्ति
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlJaggaPraptiUnit" />
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                    ID="txtJaggaPrapti"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ३८
            </td>
            <td colspan="5">
                आयोजना प्रमुखको नाम
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Button runat="server" Text="Add" CssClass="btn btn-warning" OnClick="btnAddAayojanaPramukh_Click"
                    ID="btnAddAayojanaPramukh" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <table class="table-striped table-condensed table-responsive table-bordered">
                    <asp:Repeater ID="rptAayojanaPramukh" runat="server" OnItemDataBound="rptAayojanaPramukh_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <th>
                                    शुरु मिति
                                </th>
                                <th>
                                    प्रमुखको नाम
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="pramukh">
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" onchange="unicodeToEngNumber(this)"
                                        CssClass="validateDate" ID="txtPramukhStartDate" Text='<%# Eval("PRAMUKH_START_DATE") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" onKeypress="return setUnicode(event,this);" ID="txtPramukhName"
                                        Text='<%# Eval("PRAMUKH_NAME") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.pramukh').remove();"
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
                <a href="javascript: history.go(-1)">Go Back</a>
            </td>
            <td colspan="5">
                <asp:Button runat="server" Text="Save & Continue" CssClass="btn btn-primary" ID="btnSaveOthers"
                    OnClick="btnSaveOthers_Click" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(document).ready(function () {

            if ($('#MainContent_chkIsUsable').is(":checked")) {
                RemoveDisableAttributes();
            } else {
                AddDisableAttributes();
            }
        });
        function RemoveDisableAttributes() {
            $("#MainContent_txtLavanbitMahila").removeAttr("disabled");
            $("#MainContent_txtLavanbitMahilaKaifiyat").removeAttr("disabled");
            $("#MainContent_txtLavanbitBalBalika").removeAttr("disabled");
            $("#MainContent_txtLavanbitBalKaifiyat").removeAttr("disabled");
            $("#MainContent_txtLavanbitJanajati").removeAttr("disabled");
            $("#MainContent_txtLavanbitJanaKaifiyat").removeAttr("disabled");
            $("#MainContent_txtLavanbitDalit").removeAttr("disabled");
            $("#MainContent_txtLavanbitDalitKaifiyat").removeAttr("disabled");
            $("#MainContent_txtLavanbitMadhesi").removeAttr("disabled");
            $("#MainContent_txtLavanbitMadhesiKaifiyat").removeAttr("disabled");
            $("#MainContent_txtLavanbitMuslim").removeAttr("disabled");
            $("#MainContent_txtLavanbitMuslimKaifiyat").removeAttr("disabled");
            $("#MainContent_txtAnya").removeAttr("disabled");
            $("#MainContent_txtAnyaKaifiyat").removeAttr("disabled");
            $("#MainContent_txtShramDin").removeAttr("disabled");
            $("#MainContent_txtParimaan").removeAttr("disabled");
            $("#MainContent_txtYogdan").removeAttr("disabled");
        }
       
        function AddDisableAttributes() {
            $("#MainContent_txtLavanbitMahila").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitMahilaKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitBalBalika").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitBalKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitovJanajati").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitJanaKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitDalit").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitDalitKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitMadhesi").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitMadhesiKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitMuslim").attr("disabled", "disabled");
            $("#MainContent_txtLavanbitMuslimKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtAnya").attr("disabled", "disabled");
            $("#MainContent_txtAnyaKaifiyat").attr("disabled", "disabled");
            $("#MainContent_txtShramDin").attr("disabled", "disabled");
            $("#MainContent_txtParimaan").attr("disabled", "disabled");
            $("#MainContent_txtYogdan").attr("disabled", "disabled");
        }

        $("#MainContent_chkIsUsable").change(function () {
            if ($(this).is(':checked')) {
                RemoveDisableAttributes();
            } else {
                AddDisableAttributes();
            }
        });

        $("#MainContent_ddlBudgetHead").change(function () {
            var id = $("#MainContent_ddlBudgetHead").val();
            // LoadProjectByBudgetHead();
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
            // $("#MainContent_hidProjectId").val(id);
        });

    </script>
</asp:Content>
