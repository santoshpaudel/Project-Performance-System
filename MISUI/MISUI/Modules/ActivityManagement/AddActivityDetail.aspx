<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddActivityDetail.aspx.cs"
    Inherits="MISUI.Modules.ActivityManagement.AddActivityDetail" %>

<%@ Import Namespace="MISUICOMMON.HelperClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
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
                    <%=GetLabel("Add") %> </a>
                    <br/>
                
                <asp:ListView ID="lvRoles" runat="server" OnLayoutCreated="OnLayoutCreated" OnItemEditing="lvRoles_ItemEditing">
                    <LayoutTemplate>
                        <table id="dynamic-table" class="table table-striped table-bordered table-hover">
                            <thead>
                                <tr>
                                    <th style="display: none">
                                        Activity_detail_ID
                                    </th>
                                    <th>
                                        <asp:Label runat="server" ID="lblActivityName"></asp:Label>
                                    </th>
                                    <th>
                                       <asp:Label runat="server" ID="lblSubSector"></asp:Label>
                                    </th>
                                     <th>
                                       <asp:Label runat="server" ID="lblUnit"></asp:Label>
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
                                <%# Eval("activity_detail_ID").ToString()%>
                            </td>
                            <td>
                                <%# Eval("activity_detail_NAME").ToString()%>
                            </td>
                             <td>
                                <%# Eval("sub_sector_name").ToString()%>
                            </td>
                             <td>
                                <%# Eval("activity_unit_name").ToString()%>
                            </td>
                            <td>
                                <%# (Eval("ISENABLE").ToString() == "1") ? "<span class='label label-sm label-info arrowed arrowed-right'>Enabled</span>" : "<span class='label label-sm label-grey arrowed arrowed-right'>Disabled</span>"%>
                            </td>
                            <td>
                                <div class="hidden-sm hidden-xs action-buttons">
                                    <asp:LinkButton ID="BtnEdit" Class="green" runat="server" CommandName="edit" CommandArgument='<%#Eval("activity_detail_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Edit this row' Visible='<%#(Eval("ISLOCKED").ToString() == "0" ? true : false )%>'>
             
                                                             <i class="ace-icon fa  fa-pencil  bigger-130"></i>
             
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="BtnDelete" Class="red" runat="server" CommandName="delete" CommandArgument='<%#Eval("activity_detail_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Delete this row' Visible='<%#(Eval("ISLOCKED").ToString() == "0" ? true : false )%>'>
                                                             <i class="ace-icon fa fa-trash-o bigger-130"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnLock" Class="grey" runat="server" CommandName="lock" CommandArgument='<%#Eval("activity_detail_ID") %>'
                                        OnCommand="BtnEdit_Command" ToolTip='Lock this row' Visible='<%#(Eval("ISLOCKED").ToString() == "0" ? true : false )%>'>
                                                             <i class="ace-icon fa fa-lock bigger-130"></i>

                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnUnlock" Class="grey" runat="server" CommandName="unlock" CommandArgument='<%#Eval("activity_detail_ID") %>'
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
    <!-- Add Activity section  -->
    <div id="modal-form" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                   
                    <h4 class="blue bigger">
                        <%=GetLabel("Fill Form") %></h4>
                </div>
                <div class="modal-body">
                    <div class="row" style="display: none">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtbudgheadId" class="control-label">
                                    <%=GetLabel("Activity Detail Id")%>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-2">
                                <asp:TextBox runat="server" ID="txtActivityDetailId" class="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-6">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadNepName" class="control-label">
                                    <%=GetLabel("Activity Name Nepali") %>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                <asp:TextBox runat="server" ID="txtActivityDetailNepName" required class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadEngName" class="control-label">
                                <%=GetLabel("Activity Name English") %>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                <asp:TextBox runat="server" ID="txtActivityDetailEngName" required class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadEngName" class="control-label">
                                    <%= GetLabel("Sector")%>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                
                        <asp:DropDownList ID="ddlSector" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadEngName" class="control-label">
                                    <%= GetLabel("Sub Sector")%>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                
                        <asp:DropDownList ID="ddlSubSector" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-xs-12 col-sm-3">
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="form-group">
                            <div class="col-xs-12 col-sm-4">
                                <label for="txtBudgHeadEngName" class="control-label">
                                    <%= GetLabel("Unit")%>
                                </label>
                            </div>
                            <div class="col-xs-12 col-sm-5">
                                
                        <asp:DropDownList ID="ddlUnit" runat="server"></asp:DropDownList>
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
                    <asp:Button runat="server" ID="btnAddRoles" CssClass="btn btn-sm btn-primary" OnClick="btnAddRoles_Click" />
                    <asp:Button class="btn btn-sm btn-danger" ID="btnCancel"  onClick="btnCancel_Click" runat="server"/>
                       
                    <asp:HiddenField runat="server" ID="hidActivityDetailId" />
                    
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
    <script src="../../js/Modules/ActivityDetails.js" type="text/javascript"></script>
    <script type="text/javascript">
        function addnewLink() {


            $('#modal-form').modal();
            //$("#modal-form").attr("style", "");
        }
       
    </script>
</asp:Content>
