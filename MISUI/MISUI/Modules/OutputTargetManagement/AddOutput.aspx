<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddOutput.aspx.cs" Inherits="MISUI.Modules.OutputTargetManagement.AddOutput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table class="table table-bordered table-responsive table-striped table-condensed">
         <tr>
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td><%=GetLabel("OUTPUT ENGLISH NAME") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtOutputEngName"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("OUTPUT NEPALI NAME")%><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" onKeypress = "return setUnicode(event,this);" required ID="txtOutputNepName"></asp:TextBox></td>
        </tr> 
        <tr>
            <td><%=GetLabel("OUTPUT CODE") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtOutputCode"></asp:TextBox></td>
        </tr>
        <tr>
            <td><%=GetLabel("PARENT OUTPUT") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlOutput"/></td>
        </tr>
         <tr>
            <td><%=GetLabel("OUTPUT TYPE") %><span class="style1">*</span></td>
            <td><asp:DropDownList ID="ddlOutputType" runat="server"></asp:DropDownList></td>
        </tr>
         <tr>
            <td><%=GetLabel("TOIP YEAR") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" Height="30px" required ID="txtToipYear"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td><%=GetLabel("RESPONSIBLE BODY") %></td>
            <td>
                <asp:CheckBoxList runat="server" ID="chkResponsibleOffices" RepeatDirection="Vertical" RepeatLayout="Table"/>
            </td>
        </tr>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" updatemode="Conditional" >
            <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="ddlSubsector" EventName="SelectedIndexChanged" />
             </Triggers>
         <ContentTemplate> --%>
        <tr>
            <td><%=GetLabel("SUB SECTOR") %><span class="style1">*</span></td>
            <td><asp:DropDownList ID="ddlSubsector"  runat="server"></asp:DropDownList></td>
        </tr>
         <%-- <tr>
            <td><%=GetLabel("ACTIVITY") %><span class="style1">*</span></td>
            <td><asp:DropDownList ID="ddlActivity" runat="server"></asp:DropDownList></td>
        </tr>
        </ContentTemplate>
        </asp:UpdatePanel>--%>
        <tr>
            <td></td>
            <td><asp:CheckBox runat="server" ID="chkIsEnable" 
                    ></asp:CheckBox><%=GetLabel("ENABLE") %></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text=" " ID="btnAddOutput" OnClientClick="return ValidateDropdown();" OnClick="btnAddOutput_Click"/></td>
        </tr>
        </table>
        <script type="text/javascript">
            function ValidateDropdown() {
                var check = true;
                var outputTypeId = document.getElementById("<%=ddlOutputType.ClientID %>").value;
                var subSectorId = document.getElementById("<%=ddlSubsector.ClientID %>").value;
                if (outputTypeId <= 0) {
                    check = false;
                    alert("Please Select output type!!!");

                } else {
                    if (subSectorId <= 0) {
                        check = false;
                        alert("Please Select Sub Sector!!!");  
                }


                }
                return check;

            }
         </script>
   
</asp:Content>
