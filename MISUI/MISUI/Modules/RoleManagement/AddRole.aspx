<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddRole.aspx.cs"
    Inherits="MISUI.Modules.RoleManagement.AddRole" %>

<%@ Import Namespace="MISUICOMMON.HelperClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-left: -45px; margin-top: -20px">
        <div class="col-lg-12">
            <ul class="breadcrumb">
                <li><i class="ace-icon fa fa-home home-icon"></i><a href="#">BudgetDonar</a> </li>
                <li class="active">BudgetDonarList</li>
            </ul>
            <!-- /.breadcrumb -->
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="clearfix">
                <div class="pull-right tableTools-container">
                </div>
            </div>
            <%--<div class="table-header">
											Results for "Latest Registered Domains"
										</div>--%>
            <div>
                <a id="addNew" href="#" runat="server" role="button" onclick="addnewLink();" class="btn btn-sm btn-primary"
                    data-toggle="modal"><i class="ace-icon fa fa-plus-square bigger-130"></i>&nbsp;&nbsp;
                    <%=GetLabel("Add") %>
                </a>
                <br />
                <asp:ListView ID="lvRoles" runat="server" OnLayoutCreated="OnLayoutCreated" OnItemEditing="lvRoles_ItemEditing">
                    <LayoutTemplate>
                        <table id="dynamic-table" class="table table-striped table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th style="display: none">
                                        ROLE_ID
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblRoleName"></asp:Label>
                                    </th>
                                    <th class="hidden-480">
                                        <asp:Label runat="server" ID="Status"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblAction"></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="display: none">
                                <%# Eval("ROLE_ID").ToString()%>
                            </td>
                            <td>
                                <%# Eval("ROLE_NAME").ToString()%>
                            </td>
                            <td>
                                <%# (Eval("ISENABLE").ToString() == "1") ? "<span class='label label-sm label-info arrowed arrowed-right'>Enabled</span>" : "<span class='label label-sm label-grey arrowed arrowed-right'>Disabled</span>"%>
                            </td>
                            <td>
                                <div class="hidden-sm hidden-xs action-buttons">
                                    <asp:LinkButton ID="BtnEdit" Class="green" runat="server" CommandName="edit" CommandArgument='<%#Eval("ROLE_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Edit this row' Visible='<%#(Eval("ISLOCKED").ToString() == "0" ? true : false )%>'>
             
                                                             <i class="ace-icon fa  fa-pencil  bigger-130"></i>
             
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="BtnDelete" Class="red" runat="server" CommandName="delete" CommandArgument='<%#Eval("ROLE_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Delete this row' Visible='<%#(Eval("ISLOCKED").ToString() == "0" ? true : false )%>'>
                                                             <i class="ace-icon fa fa-trash-o bigger-130"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnLock" Class="grey" runat="server" CommandName="lock" CommandArgument='<%#Eval("ROLE_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Lock this row' Visible='<%#(Eval("ISLOCKED").ToString() == "0" ? true : false )%>'>
                                                             <i class="ace-icon fa fa-lock bigger-130"></i>

                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnUnlock" Class="grey" runat="server" CommandName="unlock" CommandArgument='<%#Eval("ROLE_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Unlock this row' Visible='<%#(Eval("ISLOCKED").ToString() == "1" ? true : false )%>'>
                                                             <i class="ace-icon fa fa-unlock bigger-130"></i>

                                    </asp:LinkButton>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
    <!-- Add Role section  -->
    <div id="modal-form" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button id="Button1" type="button" class="close" data-dismiss="modal" runat="server">
                        &times;</button>
                    <h4 class="blue bigger">
                        <%=GetLabel("Fill Form") %></h4>
                </div>
                <div class="modal-body">
                    <div class="row" style="display: none">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtbudgheadId" class="control-label">
                                    <%=GetLabel("Role Id")%>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-2">
                                <asp:TextBox runat="server" ID="txtRoleId" class="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-6">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadNepName" class="control-label">
                                    <%=GetLabel("Role Nepali Name") %>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                <asp:TextBox runat="server" ID="txtRoleNepName" required class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadEngName" class="control-label">
                                    <%= GetLabel("Role English Name")%>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                <asp:TextBox runat="server" ID="txtRoleEngName" required class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 col-sm-4">
                            <label for="IsEnable" class="control-label">
                                <%=GetLabel("Enable")%>
                            </label>
                        </div>
                        <div class="col-xs-12 col-sm-3">
                            <asp:CheckBox ID="IsActive" class="form-control" runat="server" />
                        </div>
                        <div class="col-xs-12 col-sm-5">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-sm" data-dismiss="modal">
                        <i class="ace-icon fa fa-times"></i>
                        <%=GetLabel("Cancel") %>
                    </button>
                    <asp:HiddenField runat="server" ID="hidroleId" />
                    <asp:Button runat="server" ID="btnAddRoles" CssClass="btn btn-sm" OnClick="btnAddRoles_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- basic scripts -->
    <!--if !IE -->
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery.js'>" + "<" + "/script>");
    </script>
    <!-- page specific plugin scripts -->
    <script type="text/javascript" src="../../assets/js/bootstrap.js"></script>
    <script type="text/javascript" src="../../assets/js/dataTables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../../assets/js/dataTables/jquery.dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="../../assets/js/dataTables/extensions/TableTools/js/dataTables.tableTools.js"></script>
    <script type="text/javascript" src="../../assets/js/dataTables/extensions/ColVis/js/dataTables.colVis.js"></script>
    <!-- inline scripts related to this page -->
    <script src="../../js/Modules/AddRole.js" type="text/javascript"></script>
    <script type="text/javascript">
        function addnewLink() {


            $('#modal-form').modal();
            //$("#modal-form").attr("style", "");
        }
       
    </script>
</asp:Content>
