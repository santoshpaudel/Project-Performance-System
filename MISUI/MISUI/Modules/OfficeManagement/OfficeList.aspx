<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="OfficeList.aspx.cs" Inherits="MISUI.Modules.OfficeManagement.OfficeList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
	<link rel="stylesheet" href="../../dist/themes/default/style.min.css" />

</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<style>
	
	.demo { overflow:auto; border:1px solid silver; min-height:100px; }
	</style>
	
	

	<a class="btn btn-primary" href="javascript:void(0)" onclick="loadAddOffice();"><%=GetLabel("ADD OFFICE")%></a>
    <a class="btn btn-primary" href="javascript:void(0)" onclick="loadEditOffice();"><%=GetLabel("Edit Office") %></a>
    <a class="btn btn-primary" href="javascript:void(0)" onclick="loadDeleteOffice();"><%=GetLabel("Delete Office") %></a>
    
    <asp:HiddenField runat="server" ID="hidOfficeId"/>
	<div id="lazy" class="demo"></div>

	
    <script src="../../src/jquery-1.4.1.js" type="text/javascript"></script>
	<script src="../../dist/jstree.min.js"></script>
    

	
	<script>

	    $.noConflict();
       jQuery("#lazy").jstree({
	        
        'core': {
        "data": 
            {
            
                "type": "POST",
                "url": "../../WebService1.asmx/FetchOffice",
                "data": function (node) {
                    debugger;
                    if(node.id=='#') {
                        return { "id": node.id };
                    }
                    else {
                         return { "id" : node.original.attr.id };
                    }

                }
            }
        }
    });

    jQuery('#lazy')
	        .on("changed.jstree", function (e, data) {
	            debugger
	            if (data.selected.length) {
	                $("#MainContent_hidOfficeId").val(data.node.original.attr.id);
	                // window.location = "About.aspx?id=" + data.node.original.attr.id;
	                // alert('The selected node is: ' +data.node.original.attr.id);
	            }
	        });
	    function loadAddOffice() {
	        var id = $("#MainContent_hidOfficeId").val();
	        if (id != '') {
	            if (confirm("Would you like to add new office?") == true) {
	                window.location.href = "AddOffice.aspx?entryMode=0&officeId=" + id;
	            } else {

	            }

	        } else {
	            alert("Please select an office!");
	        }
	       
	    }
	    function loadEditOffice() {
	        var id = $("#MainContent_hidOfficeId").val();
	        if (id != '') {
	            if (confirm("Would you like to edit selected office?") == true) {
	                window.location.href = "AddOffice.aspx?entryMode=1&officeId=" + id;
	            } else {

	            }
	        } else {
	            alert("Please select an office!");
	        }
	       
	       
	    }
	    function loadDeleteOffice() {
	        var id = $("#MainContent_hidOfficeId").val();
	        if (id != '') {
	            if (confirm("Would you like to delete selected office?") == true) {
	                jQuery.ajax({
	                    type: "POST",
	                    url: "../../WebService1.asmx/DeleteOffice",
	                    data: { id: id }, // here we are specifing the data as a JSON object, not a string in JSON format
	                    // this will be converted into a form encoded format by jQuery
	                    // even though data is a JSON object, jQuery will convert it to "firstName=Aidy&lastName=F" so it *is* form encoded
	                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
	                    dataType: "text", // the data type we want back, so text.  The data will come wrapped in xml
	                    success: function (data) {

	                    }
	                });
	            }
	            else {
	            }
	        } else {
	            alert("Please select an office");
	        }

	     }
	  
	</script>
</asp:Content>
