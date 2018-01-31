<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListMenu.aspx.cs" Inherits="MISUI.Modules.MenuManagement.ListMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="../../dist/themes/default/style.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <a class="btn btn-primary" href="javascript:void(0)" onclick="loadAddMenu();" ><%=GetLabel("ADD MENU") %></a>
    <a class="btn btn-primary" href="javascript:void(0)" onclick="loadEditMenu();"><%=GetLabel("EDIT MENU") %></a>
    <a class="btn btn-primary" href="javascript:void(0)" onclick="loadDeleteMenu();"><%=GetLabel("DELETE") %></a>
    <asp:HiddenField runat="server" ID="hidMenuId"/>

     <!--<a href="#" onclick="demo_create()">add menu</a>-->
	<table class="table table-bordered table-responsive">
	    <tr>
	        <td>
	            <div id="lazy" class="demo" style="width:600px;float: left"></div>
	        </td>
            <td>
                <div id="permission" style="width:300px;float: left"></div>
            </td>
	    </tr>
	
    
    </table>

	<%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>--%>

    <script src="../../src/jquery-1.4.1.js" type="text/javascript"></script>
  
	<script src="../../dist/jstree.min.js" type="text/javascript"></script>
    

	
	<script>

	    $.noConflict();

	    jQuery("#lazy").jstree({

	        'core': {
	            "data":
            {

                "type": "POST",
                "url": "../../WebService1.asmx/FetchMenu",
                "data": function (node) {
                    debugger;
                    if (node.id == '#') {
                        return { "id": node.id };
                    }
                    else {
                        return { "id": node.original.attr.id };
                    }

                }
            }
	        }
	    });
	    jQuery('#lazy')
	        .on("changed.jstree", function (e, data) {
	            debugger
	            if (data.selected.length) {
	                $("#MainContent_hidMenuId").val(data.node.original.attr.id);
	                // loadPermission(data.node.original.attr.id);
	                //window.location = "About.aspx?id=" + data.node.original.attr.id;
	                // alert('The selected node is: ' +data.node.original.attr.id);
	            }
	        });

	    function changePermission(menu, role, mode, permission) {
	        jQuery.ajax({
	            type: "POST",
	            url: "../../WebService1.asmx/ChangePermission",
	            data: { menu: menu, role: role, mode: mode, permission: permission }, // here we are specifing the data as a JSON object, not a string in JSON format
	            // this will be converted into a form encoded format by jQuery
	            // even though data is a JSON object, jQuery will convert it to "firstName=Aidy&lastName=F" so it *is* form encoded
	            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
	            dataType: "text", // the data type we want back, so text.  The data will come wrapped in xml
	            success: function (data) {
	                jQuery("#permission").html(data); // show the data inside the xml wrapper
	            }
	        });

	    }
	    function loadPermission(menu) {
	        jQuery.ajax({
	            type: "POST",
	            url: "../../WebService1.asmx/test",
	            data: { menuId: menu }, // here we are specifing the data as a JSON object, not a string in JSON format
	            // this will be converted into a form encoded format by jQuery
	            // even though data is a JSON object, jQuery will convert it to "firstName=Aidy&lastName=F" so it *is* form encoded
	            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
	            dataType: "text", // the data type we want back, so text.  The data will come wrapped in xml
	            success: function (data) {
	                jQuery("#permission").html(data); // show the data inside the xml wrapper
	            }
	        });
	    }

	    function demo_create() {

	    }
	    jQuery("#lazy").bind("dblclick.jstree", function (event) {
	        alert('a');

	    });

	    function loadAddMenu() {
	        var id = $("#MainContent_hidMenuId").val();

	        if (id != '') {
	            if (confirm("Would you like to add new menu?") == true) {
	                window.location.href = "menuAdd.aspx?entryMode=0&menuId=" + id;
	            } else {
	               
	            }

	        }
	    }
	    function loadEditMenu() {
	        var id = $("#MainContent_hidMenuId").val();

	        if (id != '' && id !="0" ) {
	            if (confirm("Would you like to edit selected menu?") == true) {
	                window.location.href = "menuAdd.aspx?entryMode=1&menuId=" + id;
	            } else {

	            }
	        }


	        if (id == "0") {
	            alert("Please select a menu!");
	        }
	    }
	    function loadDeleteMenu() {
	        var id = $("#MainContent_hidMenuId").val();
	        if (id != '') {
	            if (confirm("Would you like to delete selected menu?") == true) {
	                jQuery.ajax({
	                    type: "POST",
	                    url: "../../WebService1.asmx/DeleteMenu",
	                    data: { id: id }, // here we are specifing the data as a JSON object, not a string in JSON format
	                    // this will be converted into a s by jQuery
	                    // even though data is a JSON object, jQuery will convert it to "firstName=Aidy&lastName=F" so it *is* form encoded
	                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
	                    dataType: "text", // the data type we want back, so text.  The data will come wrapped in xml
	                    success: function (data) {

	                        window.location.href = "ListMenu.aspx";
	                    }
	                });
	            }
	            else {
	            }
	        } else {
	            alert("Please select a menu");
	        }
	    }

	</script>

</asp:Content>
