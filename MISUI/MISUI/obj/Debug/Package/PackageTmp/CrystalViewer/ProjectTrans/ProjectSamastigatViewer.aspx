<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectSamastigatViewer.aspx.cs" Inherits="MISUI.CrystalViewer.ProjectTrans.ProjectSamastigatViewer" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
  <div class="row" style="margin-left:-45px; margin-top:-20px">
                <div class="col-lg-12">
                    <ul class="breadcrumb">
							<li>
							    <a>आयोजनाहरुको समष्टिगत प्रगति प्रतिवेदन</a>
								</li>
						</ul><!-- /.breadcrumb -->
                </div>
                

</div>

<div class="row">
    <div class="widget-box" style="height:auto">
	  <div class="widget-header">
		<h4 class="widget-title">Search Criteria</h4>

			<div class="widget-toolbar">
				<a href="#" data-action="collapse">
					<i class="ace-icon fa fa-chevron-up"></i>
				</a>

				<a href="#" data-action="close">
					<i class="ace-icon fa fa-times"></i>
				</a>
			</div>
		</div>

	 <div class="widget-body">
	 <div class="widget-main">
		<div class="row">
		    
             <table class="table table-bordered table-responsive table-striped table-condensed">
        
        <thead>
            <tr>
                <td>
                    <label class="control-label"><%=GetLabel("MINISTRY")%></label>
                </td>
                 <td>
                     <label class="control-label"><%=GetLabel("PRIORITY")%> </label>
                </td>
                <td>
                    <label class="control-label"><%=GetLabel("QUARTER")%></label>
                </td>
               
                
                <td></td>
            </tr>
        </thead>
        <tr>
            <td>
                
                      <asp:DropDownList ID="ddlMinistry" runat="server" >
                </asp:DropDownList>                                       
                       
            </td>
             <td>
               
                      <asp:DropDownList ID="ddlPriority" runat="server">
                        <asp:ListItem Value="0">--छान्नुहोस्--</asp:ListItem>
                        <asp:ListItem Value="1">P1</asp:ListItem>
                        <asp:ListItem Value="2">P2</asp:ListItem>
                        <asp:ListItem Value="3">P3</asp:ListItem>
                      </asp:DropDownList>                                
                      

            </td>
            <td>
                
                      <asp:DropDownList ID="ddlChaumasik" runat="server" >
                          <asp:ListItem Value="0">--छान्नुहोस्--</asp:ListItem>
                        <asp:ListItem Value="1">प्रथम</asp:ListItem>
                        <asp:ListItem Value="2">दोस्रो</asp:ListItem>
                        <asp:ListItem Value="3">तेस्रो</asp:ListItem>
                </asp:DropDownList>                                       
                       
            </td>
           
           
           
            <td><asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-sm btn-purple" OnClientClick="setvalue()" onclick="btnFilter_Click">
                 <i class="ace-icon fa fa-filter "></i>Filter</asp:LinkButton>
            </td>

        </tr>
         <% if (((Session["role_id"].ToString() == "12")
                                    || (Session["role_id"].ToString() == "13")
                                    || (Session["role_id"].ToString() == "14")
                                    || (Session["role_id"].ToString() == "15")))
                               { %>
                            <tr>
                                <td colspan="5">
                                    <asp:LinkButton ID="lnkVerify" Visible="False" OnClick="lnkVerify_Click" runat="server"> I have viewed and thus verify this report</asp:LinkButton>
                                </td>
                            </tr>
                            
                            <% } %>
    </table>   
                                                        </div>
															
													</div>
												</div>
											</div>
										</div><!-- /.span -->

<div class="row">
							<div class="col-xs-12">
                           
                                <CR:CrystalReportViewer ID="RptViewer" runat="server" AutoDataBind="true" OnUnload="viewer_Unload" />
						  

							</div>
</div><!-- /.row -->
</asp:Content>