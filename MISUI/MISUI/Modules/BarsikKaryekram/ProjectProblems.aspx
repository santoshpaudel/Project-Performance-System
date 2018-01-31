<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectProblems.aspx.cs" Inherits="MISUI.Modules.ProjectManagement.ProjectProblems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-striped table-condensed table-responsive">
        <tr>
            <td colspan="6">
                बजेट शीर्षक:
                <asp:DropDownList runat="server" ID="ddlBudgetHead" AutoPostBack="True" OnSelectedIndexChanged="ddlBudgetHead_SelectedIndexChanged" />
            </td>
            <td colspan="6">
                आयोजना:
                <asp:DropDownList runat="server" ID="ddlProjects" AutoPostBack="True" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" />
            </td>
            <hr />
        </tr>
        <tr>
            <td colspan="12">
                <asp:Button runat="server" ID="btnAddProblems" CssClass="btn-primary" Text="Add"
                    OnClick="btnAddProblems_Click" />
            </td>
        </tr>
        <tr >
            <td colspan="12">
                <table class="table-striped table-condensed table-responsive table-bordered">
                    <asp:Repeater ID="rptProblems" runat="server" OnItemDataBound="rptProblems_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <th>
                                    चौमासिक
                                </th>
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
                            <tr>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlChaumasik">
                                        <asp:ListItem Value="1">प्रथम</asp:ListItem>
                                        <asp:ListItem Value="2">दोस्रो</asp:ListItem>
                                        <asp:ListItem Value="3">तेस्रो</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
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
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="12">
                <asp:Button runat="server" ID="btnSaveProblem" CssClass="btn btn-primary" Text="Save"
                    OnClick="btnSaveProblem_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
