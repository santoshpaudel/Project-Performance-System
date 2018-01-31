<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddProjectOutputProgress.aspx.cs" Inherits="MISUI.Modules.OutputTargetManagement.AddProjectOutputTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-info fade in col-sm-8">
        <a href="#" class="close" data-dismiss="alert">&times;</a> <strong>नोट !</strong>
        " जुन नतिजाको प्रगति भर्ने हो, त्येसको दायाँ पट्टी रहेको अपडेट बटनमा थिच्नुहोस "|
        <br />
    </div>
    <div class="alert alert-dismissible alert-info pull-right" style="padding: 5px;">
        <%=GetLabel("Last Modified By")%>:&nbsp;<asp:Label runat="server" ID="lblModifiedBy"></asp:Label><br />
        <%=GetLabel("Last Modified On")%>:&nbsp;<asp:Label runat="server" ID="lblModification"></asp:Label>
    </div>
    
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td>
                <%=GetLabel("Quarter")%>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlChaumasik" OnSelectedIndexChanged="ddlChaumarsik_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem Value="0" Text="--छान्नुहोस्--"></asp:ListItem>
                    <asp:ListItem Value="1" Text="प्रथम"></asp:ListItem>
                    <asp:ListItem Value="2" Text="दोस्रो"></asp:ListItem>
                    <asp:ListItem Value="3" Text="तेस्रो"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div runat="server" id="divContent">
        <asp:GridView ID="grdTarget" OnRowCommand="GrdTarget_RowCommand" CssClass="table table-bordered table-responsive table-striped table-hover"
            runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTarget_RowDataBound">
            <Columns>
                <asp:BoundField DataField="OUTPUT" HeaderText="प्रतिफल" />
                <asp:BoundField DataField="UNIT_NEP_NAME" HeaderText="UNIT" />
                <asp:TemplateField HeaderText="यस चौमासिक लक्ष्य">
                    <ItemTemplate>
                        <asp:HiddenField ID="hidProjectOutputId" runat="server" Value='<%# Eval("PROJECT_OUTPUT_ID") %>' />
                        <%if (ddlChaumasik.SelectedValue == "1")
                          {%>
                        <asp:TextBox ID="txtQuarterTarget" onchange="unicodeToEngNumber(this)" Enabled="False"
                            Width="100px" runat="server" Text='<%# Bind("FIRST_QUARTER_TARGET")%>'></asp:TextBox>
                        <% }
                          else if (ddlChaumasik.SelectedValue == "2")
                          {%>
                        <asp:TextBox ID="TextBox2" Enabled="False" onchange="unicodeToEngNumber(this)" Width="100px"
                            runat="server" Text='<%# Bind("SECOND_QUARTER_TARGET")%>'></asp:TextBox>
                        <% }
                          else
                          {%>
                        <asp:TextBox ID="TextBox1" Enabled="False" onchange="unicodeToEngNumber(this)" Width="100px"
                            runat="server" Text='<%# Bind("THIRD_QUARTER_TARGET")%>'></asp:TextBox>
                        <% } %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="प्रथम चौमासिक प्रगति">
                    <ItemTemplate>
                        <asp:TextBox ID="txtFirstQuarterProgress" onchange="unicodeToEngNumber(this)" Width="100px"
                            runat="server" Text='<%# Bind("FIRST_QUARTER_PROGRESS")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="दोस्रो चौमासिक प्रगति">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSecondQuarterProgress" onchange="unicodeToEngNumber(this)" Width="100px"
                            runat="server" Text='<%# Bind("SECOND_QUARTER_PROGRESS")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="तेस्रो चौमासिक प्रगति">
                    <ItemTemplate>
                        <asp:TextBox ID="txtThirdQuarterProgress" onchange="unicodeToEngNumber(this)" runat="server"
                            Text='<%# Bind("THIRD_QUARTER_PROGRESS")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" Text="अपडेट" CssClass="btn btn-primary "
                            ToolTip="Add/Edit Progress" CommandName="edit" CommandArgument='<%#Eval("PROJECT_OUTPUT_ID") %>'>
                        </asp:Button>
                    </ItemTemplate>
                    <%-- <ItemTemplate>
                            <asp:ImageButton runat="server" ID="btnLockUnlock" ImageUrl="" Width="20px" Height="20px" CommandName="lockUnlock" CommandArgument='<%#Eval("ACTIVITY_OUTPUT_MAP_ID") %>'></asp:ImageButton>
                            </ItemTemplate>--%>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
