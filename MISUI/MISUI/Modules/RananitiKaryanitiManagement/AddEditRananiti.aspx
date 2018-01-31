<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
 CodeBehind="AddEditRananiti.aspx.cs" Inherits="MISUI.Modules.RananitiKaryanitiManagement.AddEditRananiti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table class="table table-bordered table-responsive table-striped table-condensed">
        <tr>
            <td><%=GetLabel("FIELDS MARKED WITH * ARE COMPULSORY.")%></td>
            <td></td>
        </tr>
        <tr>
            <td><%=GetLabel("Sector") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlSector"></asp:DropDownList>
        </tr>
        <tr>
            <td><%=GetLabel("Sub Sector") %><span class="style1">*</span></td>
            <td><asp:DropDownList runat="server" ID="ddlSubSector"></asp:DropDownList>
             <asp:HiddenField ID="hidSubSector" runat="server" />
        </tr>
        <tr>
            <td><%=GetLabel("Rananiti (In Nepali)") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" required ID="txtRananitiNepaliName" onKeypress = "return setUnicode(event,this);"></asp:TextBox></td>
        </tr> 
        
        <tr>
            <td><%=GetLabel("Rananiti (In English)") %><span class="style1">*</span></td>
            <td><asp:TextBox runat="server" required ID="txtRananitiEnglishName"></asp:TextBox></td>
        </tr> 
                
        <tr>
            <td></td>
            <td><asp:Button runat="server" CssClass="btn btn-primary" Text="Add Rananiti" ID="btnAddRananiti" OnClick="btnAddRananiti_Click"/></td>
        </tr>
    </table>
    <script type="text/javascript">
    $("#MainContent_ddlSector").change(function () {
            var id = $("#MainContent_ddlSector").val();
            //resetAll(1);
            LoadSubSectorBySectorId();
        });

        $("#MainContent_ddlSubSector").change(function () {
            debugger;
            $("#MainContent_hidSubSector").val($("#MainContent_ddlSubSector").val());
        });
        
    function LoadSubSectorBySectorId() {
        //load another dropdown
        var sectorId = $("#MainContent_ddlSector").val();

        $("#MainContent_ddlSubSector").html("");
        $.ajax({
            type: "POST",
            url: "../../WebService1.asmx/FindSubSectorBySectorId",
            data: "{sectorId:'" + sectorId + "'}",
            contentType: "application/json; charset=utf-8",
            success: function(msg) {
                dataType: "json",
                BindSubSectorDdl(msg.d);
            }
        });

        function BindSubSectorDdl(msg) {
            $.each(msg, function () {
                $("#MainContent_ddlSubSector").append($("<option></option>").val(this['ComboId']).html(this['Name']));
            });
        }
    }
    </script>
</asp:Content>
