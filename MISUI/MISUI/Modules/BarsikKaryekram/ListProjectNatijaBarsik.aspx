<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListProjectNatijaBarsik.aspx.cs" Inherits="MISUI.Modules.BarsikKaryekram.ListProjectNatijaBarsik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="../../assets/js/bootstrap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                    <asp:HiddenField ID="hidPTargetId" runat="server" Value='<%# Eval("P_TARGET_ID") %>'   />
                                 <asp:DropDownList ID="ddlFramework" runat="server"></asp:DropDownList>
                             </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="BASE YEAR TARGET">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBaseYearTarget" onchange="unicodeToEngNumber(this)" Width="100px" runat="server" Text='<%# Bind("P_TARGET_BASE_YEAR")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FIRST TRIMISTER">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFirstYearTarget" onchange="unicodeToEngNumber(this)" Width="100px" runat="server" Text='<%# Bind("P_TARGET_FIRST_C")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SECOND TRIMISTER">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSecondYearTarget" onchange="unicodeToEngNumber(this)" Width="100px" runat="server" Text='<%# Bind("P_TARGET_SECOND_C")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="THIRD TRIMISTER">
                            <ItemTemplate>
                                <asp:TextBox ID="txtThirdYearTarget" onchange="unicodeToEngNumber(this)" runat="server" Text='<%# Bind("P_TARGET_THIRD_C")%>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="../../images/Edit.png" Width="20px" Height="20px" ToolTip="Add/Edit Target" CommandName="edit" CommandArgument='<%#Eval("P_TARGET_B_ID") %>'></asp:ImageButton>
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
     </script>

        </asp:Content>
