<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/backend.master" AutoEventWireup="true" CodeFile="error-page.aspx.cs" 
Inherits="webapp_page_backend_error_page" Title="FASTAUTOMATICMAIL" EnableViewState="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content">
	  <div class="page-full-width cf" style="height:300px">
	    <div class="error-box round">	       	 
            <asp:Label ID="lblError" runat="server" Text="Vui lòng kiểm tra dữ liệu nhập vào !!!"></asp:Label> 
	    </div>
	  </div>
	</div>
</asp:Content>

