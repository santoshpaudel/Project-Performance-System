<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddProjectOutput.aspx.cs" Inherits="MISUI.Modules.OutputTargetManagement.AddProjectOutput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-dismissible alert-info pull-right" style="padding: 5px;">
        <%=GetLabel("Last Modified By")%>:&nbsp;<asp:Label runat="server" ID="lblModifiedBy"></asp:Label><br />
        <%=GetLabel("Last Modified On")%>:&nbsp;<asp:Label runat="server" ID="lblModification"></asp:Label>
    </div>
    
    
    <div class="row">
        वार्षिक प्रतिफल
    </div>
    <hr />
    <div class="row">
        <asp:Label runat="server" ID="lblNote"></asp:Label>
        <asp:Button runat="server" ID="btnAddProjectOutput" Text="+थप्नुहोस्" CssClass="btn btn-warning"
            OnClick="btnAddProjectOutput_Click" />
    </div>
    <div class="row">
        <table class="table-striped table-condensed table-responsive table-bordered">
            <asp:Repeater ID="rptOutput" runat="server" OnItemDataBound="rptOutput_ItemDataBound">
                <HeaderTemplate>
                    <tr>
                        <th>
                            <%=GetLabel("S.N.")%>
                        </th>
                        <th>
                            <%=GetLabel("Output")%>
                        </th>
                        <th>
                            <%=GetLabel("Unit")%>
                        </th>
                        <th>
                            <%=GetLabel("Yearly Target")%>
                        </th>
                        <th>
                            <%=GetLabel("First Quarter Target")%>
                        </th>
                        <th>
                            <%=GetLabel("Second Quarter Target")%>
                        </th>
                        <th>
                            <%=GetLabel("Third Quarter Target")%>
                        </th>
                        <th>
                            <%=GetLabel("Remarks")%>
                        </th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="pratifal">
                        <td>
                            <asp:TextBox runat="server" ID="txtOrder" Width="40" Text='<%# Eval("OUTPUT_ORDER") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox TextMode="MultiLine" runat="server" onKeypress="return setUnicode(event,this);"
                                ID="txtOutput" Text='<%# Eval("OUTPUT") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlUnit" />
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtYearlyTarget" Text='<%# Eval("YEARLY_TARGET") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtFirstQuarterTarget" Text='<%# Eval("FIRST_QUARTER_TARGET") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtSecondQuarterTarget" Text='<%# Eval("SECOND_QUARTER_TARGET") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server"  onchange="unicodeToEngNumber(this)"
                                ID="txtThirdQuarterTarget" Text='<%# Eval("THIRD_QUARTER_TARGET") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server"  ID="txtOutputRemarks"
                                Text='<%# Eval("OUTPUT_REMARKS") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.pratifal').remove();"
                                EnableViewState="True" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="row">
        <asp:Button runat="server" ID="btnSaveOutput" CssClass="btn btn-primary" Text="Save"
            OnClick="btnSaveOutput_Click" />
    </div>
    <script>
        $(document).ready(function () {
            var rowLength = $(".pratifal tr:visible").length - 1;
            for (var i = 0; i < rowLength; i++) {
                var initialPrathamId = "#MainContent_rptOutput_txtFirstQuarterTarget_" + i;
                $(initialPrathamId).keyup(function (e) {
                    var focused = document.activeElement.id;
                    var j = focused.split("_").pop();
                    var totalRakamId = "#MainContent_rptOutput_txtYearlyTarget_" + j;
                    var totalRakam = $(totalRakamId).val();
                    var mainVal = parseFloat(totalRakam);
                    if (parseFloat($(this).val()) > mainVal) {
                        $(this).val(0);
                        alert("प्रथम चौमासिक रकम कुल भन्दा बढी भयो");
                    }
                    var secondRakamId = "#MainContent_rptOutput_txtSecondQuarterTarget_" + j;
                    var secondRakam = $(secondRakamId).val();
                    var pass = parseFloat(totalRakam) - (parseFloat(secondRakam) || 0) - (parseFloat($(this).val()) || 0);
                    callThird(pass, j);

                });
            }

            $(document).keyup(function (e) {
                if (e.currentTarget.activeElement != undefined) {
                    //var id = $(e.currentTarget.activeElement).attr('id');
                    var focusedSec = document.activeElement.id;
                    var s = focusedSec.split("_").pop();
                    var barshikLaksyaId = "#MainContent_rptOutput_txtYearlyTarget_" + s;
                    var barshikLaksyaRakam = $(barshikLaksyaId).val();
                    var prathamId = "#MainContent_rptOutput_txtFirstQuarterTarget_" + s;
                    var prathamRakam = $(prathamId).val();
                    var doshroId = "#MainContent_rptOutput_txtSecondQuarterTarget_" + s;
                    var doshroRakam = $(doshroId).val();
                    var tesroId = "#MainContent_rptOutput_txtThirdQuarterTarget_" + s;
                    var tesroRakam = $(tesroId).val();

                    //checking second quarter
                    var secVal = parseFloat(barshikLaksyaRakam) - parseFloat(prathamRakam) - parseFloat(tesroRakam);
                    if (parseFloat(doshroRakam) > secVal) {
                        $(e.currentTarget.activeElement).val(0);
                        alert("दोस्रो चौमासिक रकम कुल भन्दा बढी भयो");
                    }

                    //checking third quarter
                    var thirdVal = parseFloat(barshikLaksyaRakam) - parseFloat(prathamRakam) - parseFloat(doshroRakam);
                    if (parseFloat(tesroRakam) > thirdVal) {
                        $(e.currentTarget.activeElement).val(0);
                        alert("तेस्रो चौमासिक रकम कुल भन्दा बढी भयो");
                    }
                    
                    var pass = parseFloat(barshikLaksyaRakam) - (parseFloat(prathamRakam) || 0) - (parseFloat(doshroRakam) || 0);
                    callThird(pass, s);

                }
            });

            var tesroId = "#MainContent_rptOutput_txtThirdQuarterTarget_";
//            function callThird(pass, j) {
//                $(tesroId + j).val(pass);
//            }
        });
       
    </script>
</asp:Content>
