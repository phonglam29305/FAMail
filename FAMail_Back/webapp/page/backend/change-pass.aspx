<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/user.master"
 AutoEventWireup="true" CodeFile="change-pass.aspx.cs" Inherits="webapp_page_backend_change_pass" 
 Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Thay đổi mật khẩu</h3>
				<span class="fr expand-collapse-text">Thu vào</span>
				<span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			</div> <!-- end content-module-heading -->			
	           
            
			<div class="content-module-main">
			  <asp:Panel Visible="false" ID="pnError" runat="server">
                <div class="error-box round">
                    <asp:Label ID="lblError"  runat="server" Text=""></asp:Label> 
                </div>
              </asp:Panel>
              <asp:Panel Visible="false" ID="pnSuccess" runat="server">
                <div class="confirmation-box round">
                    <asp:Label ID="lblSuccess"  runat="server" Text=""></asp:Label> 
                </div>
              </asp:Panel>
			  <div class="content-module-main cf">
			    <div class="half-size-column fl">					
				    <fieldset>  				        
				        <p>
				            <label for="simple-input">Nhập mật khẩu cũ</label>
                             <asp:TextBox ID="txtOldPass" CssClass="round default-width-input" 
                                        runat="server" TextMode="Password"></asp:TextBox>
                             <em>Mật khẩu cũ của bạn là gì !</em>
				        </p>
				        
				        <p>
				            <label for="full-width-input">Mật khẩu mới</label>
				            <asp:TextBox ID="txtNewPass" CssClass="round default-width-input" 
                                        runat="server" TextMode="Password"></asp:TextBox>
                            <em>Thông tin mật khẩu mới !</em>
				        </p>
				        
				        <p>
				            <label for="full-width-input">Xác nhận mật khẩu mới</label>
				            <asp:TextBox ID="txtConfirmPass" CssClass="round default-width-input" 
                                        runat="server" TextMode="Password"></asp:TextBox>
                            <em>Hãy chắc rằng bạn đã nhớ mật khẩu mới !</em>
				        </p>
                        <asp:LinkButton ID="lbtChangPass" 
                        CssClass="button round blue image-right ic-edit text-upper" 
                        runat="server" onclick="lbtChangPass_Click">Thay đổi</asp:LinkButton>
				       
				    </fieldset>
			    </div>
			   
			  </div>
		     </div>
		     
		  </div>
     </div>
</asp:Content>

