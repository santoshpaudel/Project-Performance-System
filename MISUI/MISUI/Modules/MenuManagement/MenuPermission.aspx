<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPermission.aspx.cs" MasterPageFile="../../Site.Master" Inherits="MISUI.Modules.MenuManagement.MenuPermission" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
	
    <link rel="stylesheet" href="../../dist/themes/default/style.min.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">

	
   
	<table class="table table-bordered table-responsive">
	   
        <tr>
	        <td>
	            <div id="lazy" class="demo" style="width:200px;float: left"></div>
	        </td>
            <td>
                <div id="permission" class="table-striped table-hover table-responsive" style="float: left"></div>
            </td>
	    </tr>
	
    
    </table>

	<%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>--%>

    <script src="../../src/jquery-1.4.1.js" type="text/javascript"></script>
	<script src="../../dist/jstree.min.js"></script>
    

	
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
	                if (data.node.original.attr.id == "0") {
	                    alert("select any child menu");
	                }
	                else {
	                    loadPermission(data.node.original.attr.id);
	                    //window.location = "About.aspx?id=" + data.node.original.attr.id;
	                    // alert('The selected node is: ' +data.node.original.attr.id);
	                }
	              
	            }
	        });

	        function changePermission(menu,role,mode,permission) {
	            jQuery.ajax({
	                type: "POST",
	                url: "../../WebService1.asmx/ChangePermission",
	                data: { menu: menu, role:role, mode: mode, permission: permission }, // here we are specifing the data as a JSON object, not a string in JSON format
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

	</script>
</asp:Content>

