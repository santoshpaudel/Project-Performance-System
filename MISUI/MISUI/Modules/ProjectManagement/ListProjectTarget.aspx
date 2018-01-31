<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProjectTarget.aspx.cs" Inherits="MISUI.Modules.ProjectManagement.ListProjectTarget" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   <%-- <a id="aModal" href="#" runat="server" role="button" onclick="showModal();" class="btn btn-sm btn-primary"
                    data-toggle="modal"><i class="ace-icon fa fa-plus-square bigger-130"></i>&nbsp;&nbsp;
                    <%=GetLabel("Add") %>
    </a>--%>
    <div id="modal-form" class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button id="Button1" type="button" class="close" data-dismiss="modal" runat="server">
                        &times;</button>
                    <h4>
                    </h4>
                </div>
                <div class="modal-body">
                    <fieldset>
                        <table class="table table-striped table-responsive table-bordered table-condensed">
                           <tr>
                               <td><asp:DropDownList runat="server"  ID="ddlModalSector" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlModalSector_SelectedIndexChanged" /></td>
                               <td><asp:DropDownList runat="server" ID="ddlModalSubSector" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlModalSubSector_SelectedIndexChanged" /></td>
                               <td><asp:DropDownList runat="server" CssClass="form-control" ID="ddlModalActivity" /></td>
                               <td><asp:Button runat="server" ID="btnModalSearch" Text="Search" CssClass="btn btn-primary" OnClientClick="return ValidateForm();" OnClick="btnModalSearchClick"/></td>
                           </tr>
                       </table>
                       <asp:CheckBoxList runat="server"  ID="chkModalNatijaSuchak"/>
                    </fieldset>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnSaveNatijaSuchakList" Text="सेभ गर्नुहोस्" CssClass="btn btn-primary"
                        OnClick="btnSaveNatijaSuchakList_Click" />
                    <button class="btn btn-warning" data-dismiss="modal">
                        <i class="ace-icon fa fa-times"></i>
                        <%=GetLabel("Cancel") %>
                    </button>
                </div>
            </div>
        </div>
    </div>

   <table class="table table-striped table-responsive table-bordered table-condensed">
       <tr>
           <td><asp:DropDownList runat="server"  ID="ddlSector" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged" /></td>
           <td><asp:DropDownList runat="server" ID="ddlSubSector" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSubSector_SelectedIndexChanged" /></td>
           <td><asp:DropDownList runat="server" CssClass="form-control" ID="ddlActivity" /></td>
           <td><asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary" OnClientClick="return ValidateForm();" OnClick="btnSearchClick"/></td>
       </tr>
   </table>

   <asp:GridView ID="grdTarget" onrowcommand="GrdTarget_RowCommand"  
        CssClass="table table-bordered table-responsive table-striped table-hover"  
        runat="server" AutoGenerateColumns="False" 
        onrowdatabound="grdTarget_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="ACTIVITY_OUTPUT_NAME" HeaderText="OUTPUT"  />
                        <asp:BoundField DataField="ACTIVITY_DETAIL_NAME" HeaderText="ACTIVITY"  />
                        <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT"  />
                         <asp:TemplateField HeaderText="FRAMEWORK">
                             <ItemTemplate>
                                  <asp:HiddenField ID="hidAOutputMapId" runat="server" Value='<%# Eval("ACTIVITY_OUTPUT_MAP_ID") %>'   />
                                 <asp:DropDownList ID="ddlFramework" runat="server"></asp:DropDownList>
                             </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="BASE YEAR TARGET">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBaseYearTarget" Width="100px" runat="server" onchange="unicodeToEngNumber(this)" Text='<%# Bind("P_TARGET_BASE_YEAR")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FIRST YEAR TARGET">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFirstYearTarget" Width="100px" runat="server" onchange="unicodeToEngNumber(this)" Text='<%# Bind("P_TARGET_FIRST_YEAR")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SECOND YEAR TARGET">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSecondYearTarget" Width="100px" runat="server" onchange="unicodeToEngNumber(this)" Text='<%# Bind("P_TARGET_SECOND_YEAR")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="THIRD YEAR TARGET">
                            <ItemTemplate>
                                <asp:TextBox ID="txtThirdYearTarget" runat="server" onchange="unicodeToEngNumber(this)" Text='<%# Bind("P_TARGET_THIRD_YEAR")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="OVERALL TARGET">
                            <ItemTemplate>
                                <asp:TextBox ID="txtOverAllTarget" Width="100px" onchange="unicodeToEngNumber(this)" runat="server" Text='<%# Bind("P_OVERALL_TARGET")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="../../images/Edit.png" Width="20px" Height="20px" ToolTip="Add/Edit Target" CommandName="edit" CommandArgument='<%#Eval("P_TARGET_ID") %>'></asp:ImageButton>
                            </ItemTemplate>
                            <%-- <ItemTemplate>
                            <asp:ImageButton runat="server" ID="btnLockUnlock" ImageUrl="" Width="20px" Height="20px" CommandName="lockUnlock" CommandArgument='<%#Eval("ACTIVITY_OUTPUT_MAP_ID") %>'></asp:ImageButton>
                            </ItemTemplate>--%>
                        </asp:TemplateField>
                    </Columns>
    </asp:GridView>
   
     <script type="text/javascript">
         function ValidateForm() {
             var check = true;
             var sector = $("#<%=ddlSector.ClientID %>").val();
             var subsector = $("#<%=ddlSubSector.ClientID %>").val();
             var activity = $("#<%=ddlActivity.ClientID %>").val();
             if (sector== '--क्षेत्र छान्नुहोस्--') {
                 check = false;
                 $("#<%=ddlSector.ClientID %>").focus();
                 alert(" Please select sector !!!");
                 
             }
            /* else if (subsector == '--उपक्षेत्र छान्नुहोस्--') {
                 $("#<%=ddlSubSector.ClientID %>").focus();
                 alert("Please select sub sector!!!");
                 check = false;
             } else if (activity == '--सूचक छान्नुहोस्--') {
                 $("#<%=ddlActivity.ClientID %>").focus();
                 alert("Please select activity!!!");
                 check = false;

             }*/
             return check;
         }
         
         function showModal() {


            $('#modal-form').modal();
            //$("#modal-form").attr("style", "");
        }
       
     </script>

        </asp:Content>
