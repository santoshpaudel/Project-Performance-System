<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="KaryekramPragati.aspx.cs"
    Inherits="MISUI.Modules.BarsikKaryekram.KaryekramPragati" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="alert alert-dismissible alert-info pull-right" style="padding: 5px;">
        <%=GetLabel("Last Modified By")%>:&nbsp;<asp:Label runat="server" ID="lblModifiedBy"></asp:Label><br />
        <%=GetLabel("Last Modified On")%>:&nbsp;<asp:Label runat="server" ID="lblModification"></asp:Label>
    </div>
  
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td>
                चैमासिक
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlChaumarsik" OnSelectedIndexChanged="ddlChaumarsik_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="0" Text="--छान्नुहोस्--"></asp:ListItem>
                    <asp:ListItem Value="1" Text="प्रथम"></asp:ListItem>
                    <asp:ListItem Value="2" Text="दोस्रो"></asp:ListItem>
                    <asp:ListItem Value="3" Text="तेस्रो"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div id="divContent" runat="server">
        <table class="table table-striped table-condensed table-responsive">
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
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
                                        यस चैमासिक लक्ष्य
                                    </th>
                                    <th>
                                        यस चैमासिकको रकम
                                    </th>
                                    <th>
                                        सोधभर्ना माग गर्नुपर्ने रकम
                                    </th>
                                    <th>
                                        हालसम्म माग गरिएको रकम
                                    </th>
                                    <th>
                                        हालसम्म प्राप्त रकम
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hidBadfadId" runat="server" Value='<%# Eval("BUDG_BADFAD_ID") %>' />
                                        <asp:DropDownList Enabled="False" runat="server" Width="100px" ID="ddlShrot" />
                                    </td>
                                    <td>
                                        <asp:DropDownList Enabled="False" runat="server" Width="100px" ID="ddlBhuktaniPrakar" />
                                    </td>
                                    <td>
                                        <% if (ddlChaumarsik.SelectedValue == "1")
                                           {%>
                                        <asp:TextBox runat="server" ID="txtRakam" Enabled="False" onchange="unicodeToEngNumber(this)"
                                            Width="100px" Text='<%# Eval("FIRST_T_RAKAM") %>'></asp:TextBox>
                                        <%  }
                                           else if (ddlChaumarsik.SelectedValue == "2")
                                           {%>
                                        <asp:TextBox runat="server" ID="TextBox1" Enabled="False" onchange="unicodeToEngNumber(this)"
                                            Width="100px" Text='<%# Eval("SECOND_T_RAKAM") %>'></asp:TextBox>
                                        <% %>
                                        <%  }
                                           else
                                           {%>
                                        <asp:TextBox runat="server" ID="TextBox2" Enabled="False" onchange="unicodeToEngNumber(this)"
                                            Width="100px" Text='<%# Eval("THIRD_T_RAKAM") %>'></asp:TextBox>
                                        <% }%>
                                    </td>
                                    <td>
                                        <% if (ddlChaumarsik.SelectedValue == "1")
                                           {%>
                                        <asp:TextBox runat="server" ID="txtFirstTRakam" onchange="unicodeToEngNumber(this)"
                                            Width="100px" Text='<%# Eval("FIRST_P_RAKAM") %>'></asp:TextBox>
                                        <%  }
                                           else if (ddlChaumarsik.SelectedValue == "2")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSecondTRakam"
                                            Text='<%# Eval("SECOND_P_RAKAM") %>'></asp:TextBox>
                                        <% %>
                                        <%  }
                                           else
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtThirdTRakam"
                                            Text='<%# Eval("THIRD_P_RAKAM") %>'></asp:TextBox>
                                        <% }%>
                                    </td>
                                    <td>
                                        <% if (ddlChaumarsik.SelectedValue == "1")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaMagF"
                                            Text='<%# Eval("S_BH_MAG_GARNE_F") %>'></asp:TextBox>
                                        <%  }
                                           else if (ddlChaumarsik.SelectedValue == "2")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaMagS"
                                            Text='<%# Eval("S_BH_MAG_GARNE_S") %>'></asp:TextBox>
                                        <% %>
                                        <%  }
                                           else
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaMagT"
                                            Text='<%# Eval("S_BH_MAG_GARNE_T") %>'></asp:TextBox>
                                        <% }%>
                                    </td>
                                    <td>
                                        <% if (ddlChaumarsik.SelectedValue == "1")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaHalSammaMagF"
                                            Text='<%# Eval("S_BH_HAL_SAMMA_MAG_F") %>'></asp:TextBox>
                                        <%  }
                                           else if (ddlChaumarsik.SelectedValue == "2")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaHalSammaMagS"
                                            Text='<%# Eval("S_BH_HAL_SAMMA_MAG_S") %>'></asp:TextBox>
                                        <% %>
                                        <%  }
                                           else
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaHalSammaMagT"
                                            Text='<%# Eval("S_BH_HAL_SAMMA_MAG_T") %>'></asp:TextBox>
                                        <% }%>
                                    </td>
                                    <td>
                                        <% if (ddlChaumarsik.SelectedValue == "1")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaPraptaF"
                                            Text='<%# Eval("S_BH_HAL_SAMMA_PRAPTA_F") %>'></asp:TextBox>
                                        <%  }
                                           else if (ddlChaumarsik.SelectedValue == "2")
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaPraptaS"
                                            Text='<%# Eval("S_BH_HAL_SAMMA_PRAPTA_S") %>'></asp:TextBox>
                                        <% %>
                                        <%  }
                                           else
                                           {%>
                                        <asp:TextBox runat="server" Width="100px" onchange="unicodeToEngNumber(this)" ID="txtSodhBharnaPraptaT"
                                            Text='<%# Eval("S_BH_HAL_SAMMA_PRAPTA_T") %>'></asp:TextBox>
                                        <% }%>
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
                    यस चैमासिक लक्ष्य
                </td>
                <td colspan="2" align="center" style="border-right: 1px solid">
                    प्रथम चौमासिक
                </td>
                <td colspan="2" align="center" style="border-right: 1px solid">
                    दोस्रो चौमासिक
                </td>
                <td colspan="2" align="center" style="border-right: 1px solid">
                    तेस्रो चौमासिक
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
                    <asp:TextBox Enabled="False" onchange="unicodeToEngNumber(this)" ID="txtPSBRakam"
                        Width="100px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPSFirstTNo" runat="server" onchange="unicodeToEngNumber(this)"
                        Width="100px"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox onchange="unicodeToEngNumber(this)" ID="txtPSFirstTRakam" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPSSecondTNo" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox onchange="unicodeToEngNumber(this)" ID="txtPSSSecondTRakam" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPSThirdTNo" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPSThirdTRakam" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border-right: 1px solid">
                    परामर्शदाता-विदेशी
                </td>
                <td>
                    <asp:TextBox Enabled="False" ID="txtPBBNo" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox Enabled="False" onchange="unicodeToEngNumber(this)" ID="txtPBBRakam"
                        Width="100px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPBFirstTNo" runat="server" onchange="unicodeToEngNumber(this)"
                        Width="100px"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox onchange="unicodeToEngNumber(this)" ID="txtPBFirstTRakam" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPBSecondTNo" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox onchange="unicodeToEngNumber(this)" ID="txtPBSecondTRakam" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPBThirdTNo" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtPBThirdTRakam" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="border-right: 1px solid">
                    ठेक्का
                </td>
                <td>
                    <asp:TextBox ID="txtThekaBNo" Enabled="False" Width="100px" onchange="unicodeToEngNumber(this)"
                        runat="server"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox Enabled="False" onchange="unicodeToEngNumber(this)" ID="txtThekaBRakam"
                        Width="100px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtThekaFirstTNo" onchange="unicodeToEngNumber(this)" runat="server"
                        Width="100px"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox onchange="unicodeToEngNumber(this)" ID="txtThekaFirstTRakam" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtThekaSecondTNO" onchange="unicodeToEngNumber(this)" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox onchange="unicodeToEngNumber(this)" ID="txtThekaSecondTRakam" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtThekaThirdTNo" onchange="unicodeToEngNumber(this)" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtThekaThirdTRakam" onchange="unicodeToEngNumber(this)" Width="100px"
                        runat="server"></asp:TextBox>
                </td>
                <asp:HiddenField ID="hidThekaParamarsaId" runat="server" />
            </tr>
        </table>
        <table class="table table-striped table-condensed table-responsive">
            <tr>
                <td>
                </td>
                <td>
                    यस चैमासिक लक्ष्य
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
            </tr>
        </table>
        <asp:HiddenField ID="hidBarshikAnyaId" runat="server" />
        <table class="table table-condensed table-striped  table-responsive table-bordered">
            <tr>
                <td>
                </td>
                <td align="center" colspan="2" style="border-right: 1px solid">
                    यस अबधिको
                </td>
                <td align="center" colspan="3" style="border-right: 1px solid">
                    शुरु देखि यस अबधिसम्मको
                </td>
                <td align="center" colspan="2" style="border-right: 1px solid">
                    यस आवको हालसम्मको
                </td>
            </tr>
            <tr>
                <td>
                    यस चैमासिकको भारित लक्ष्य
                </td>
                <td>
                    भैतिक प्रगति
                </td>
                <td style="border-right: 1px solid">
                    वित्तिय प्रगति
                </td>
                <td>
                    भैतिक प्रगति
                </td>
                <td>
                    वित्तिय प्रगति
                </td>
                <td style="border-right: 1px solid">
                    वितेको अवधि
                </td>
                <td>
                    भैतिक प्रगति
                </td>
                <td>
                    वित्तिय प्रगति
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtYesChaumashikBharitLakshya" Enabled="False" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtYesAbadhikoBhautik" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                </td>
                <td style="border-right: 1px solid">
                    <asp:TextBox ID="txtYesAbadhikoBitiye" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtYesAbadhiSammaBhautik" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtYesAbadhiSammaBitiye" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidBhutikPragatiId" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtBitekoAbadhi" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtYesAawaBhautik" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtYesAawaPragati" onchange="unicodeToEngNumber(this)" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
        </table>
        <table class="table table-striped table-condensed table-responsive">
            <tr>
                <td colspan="12">
                    लाभान्वित प्रगति
                    <asp:Button runat="server" ID="btnAddLavanvit" CssClass="btn-primary" Text="Add"
                        OnClick="btnAddLavanvit_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="12">
                    <table class="table-striped table-condensed table-responsive table-bordered">
                        <asp:Repeater ID="rptLavanvit" runat="server" OnItemDataBound="rptLavanvit_ItemDataBound">
                            <HeaderTemplate>
                                <tr>
                                    <th>
                                        महिला
                                    </th>
                                    <th>
                                        बालबालिका
                                    </th>
                                    <th>
                                        आदिवासी/जनजाती
                                    </th>
                                    <th>
                                        दलित
                                    </th>
                                    <th>
                                        मधेशी
                                    </th>
                                    <th>
                                        मुस्लिम
                                    </th>
                                    <th>
                                        अन्य
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="pragati">
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtMahila" Text='<%# Eval("MAHILA") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtBalbalika"
                                            Text='<%# Eval("BALBALIKA") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtAadibasiJanajati"
                                            Text='<%# Eval("AADIBASI_JANAJATI") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtDalit" Text='<%# Eval("DALIT") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtMadhesi" Text='<%# Eval("MADHESI") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtMuslim" Text='<%# Eval("MUSLIM") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" onchange="unicodeToEngNumber(this)" ID="txtAnya" Text='<%# Eval("ANYA") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.pragati').remove();"
                                            EnableViewState="True" />
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
                <td colspan="3">
                    कार्यक्रम उपलब्धिहरु
                </td>
            </tr>
            <tr>
                <td>
                    प्रथम चैामासिक
                </td>
                <td>
                    दोस्रो चैामासिक
                </td>
                <td>
                    तेस्रो चैमासिक
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtFirstCUpalabdhi" Width="300px" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtSecondCUpalabdhi" Width="300px" TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtThirdCUpalabdhi" Width="300px" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="hidUpalabdhId" runat="server" />
                </td>
            </tr>
        </table>
        <table class="table table-striped table-condensed table-responsive">
            <tr>
                <td colspan="12">
                    समस्या र सुझाब
                    <asp:Button runat="server" ID="btnAddProblems" CssClass="btn-primary" Text="Add"
                        OnClick="btnAddProblems_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="12">
                    <table class="table-striped table-condensed table-responsive table-bordered">
                        <asp:Repeater ID="rptProblems" runat="server" OnItemDataBound="rptProblems_ItemDataBound">
                            <HeaderTemplate>
                                <tr>
                                    <th>
                                        मुख्य समस्या
                                    </th>
                                    <th>
                                        समस्याका कारण
                                    </th>
                                    <th>
                                        समाधान प्रयास
                                    </th>
                                    <th>
                                        समाधान सुझाव
                                    </th>
                                    <th>
                                        NDAC
                                    </th>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="samashya">
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtProblems" Text='<%# Eval("PROBLEMS") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtReasons" Text='<%# Eval("REASONS") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtEfforts" Text='<%# Eval("EFFORTS") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtSuggestions" Text='<%# Eval("SUGGESTIONS") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="chkNdac" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" Text="X" CssClass="btn btn-danger" OnClientClick="$(this).parents('.samashya').remove();"
                                            EnableViewState="True" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
        </table>
        <table>
            <tr>
                <td>
                    चौमासिक प्रगति फाइल अपलोड:
                </td>
                <td colspan="5">
                    <asp:FileUpload runat="server" ID="FileChaumasik" AllowMultiple="true" />
                </td>
                <td>
                    <%--<span class="style2">फाइल</span>: <a id="aChaumasikFile" runat="server" target="_blank">
                    </a>--%>
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
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            color: #006600;
        }
    </style>
</asp:Content>
