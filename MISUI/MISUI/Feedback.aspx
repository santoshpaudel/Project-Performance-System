<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="MISUI.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <strong><%=GetLabel("Give us your valuable feedback")%> (<span class="style1">*</span> <%=GetLabel("Compulsary")%>)</strong>
    <hr/>
    <div class="row">
        <div class="col-sm-3">
            <%=GetLabel("Name") %><span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass=""   required ID="txtName"></asp:TextBox>
        </div>
    </div>
   
    <hr/>
     <div class="row">
        <div class="col-sm-3">
             <%=GetLabel("Contact Number")%> <span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass=""   required ID="txtContactNumber"></asp:TextBox>
        </div>
    </div>
    <hr/>
     <div class="row">
        <div class="col-sm-3">
             <%=GetLabel("Your Email Id") %> <span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass=""  required ID="txtYourEmail"></asp:TextBox>
        </div>
    </div>
    <hr/>
     <%--<div class="row">
        <div class="col-sm-3">
             <%=GetLabel("Your Password") %> <span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass="" TextMode="Password"  required ID="txtYourPassword"></asp:TextBox>
        </div>
    </div>
    <hr/>--%>
     <div class="row">
        <div class="col-sm-3">
             <%=GetLabel("Message")%> <span class="style1">*</span>:
        </div>
         <div class="col-sm-3">
            <asp:TextBox runat="server" CssClass="" TextMode="MultiLine" onKeypress = "return setUnicode(event,this);"  required ID="txtMessage"></asp:TextBox>
        </div>
    </div>
    <hr/>
    <div class="row">
        <div class="col-sm-3">
             
        </div>
         <div class="col-sm-3">
            <asp:FileUpload runat="server" ID="fileFeedback" AllowMultiple="true"/>
        </div>
    </div>
    <hr/>
     <div class="row">
        <div class="col-sm-3">
           
        </div>
         <div class="col-sm-3">
           <asp:Button runat="server" ID="btnSend" CssClass="btn btn-primary"  OnClick="btnSend_Click"/>
        </div>
         <div>
             <asp:Label runat="server" ID="lblSuccess"></asp:Label>
         </div>
    </div>
</asp:Content>
