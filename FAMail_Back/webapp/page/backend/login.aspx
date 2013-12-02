<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="webapp_page_backend_login" EnableViewState="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>FASTAUTOMATICMAIL </title>
    <link href="http://chomy.com.vn/templates/ja_mesolite_ii/favicon.ico" rel="shortcut icon" type="image/x-icon"/>
    <!-- Stylesheets -->
	<link href='http://fonts.googleapis.com/css?family=Droid+Sans:400,700' rel='stylesheet'>
	<link rel="stylesheet" href="../../resource/css/style.css">	

	<!-- Optimize for mobile devices -->
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>  
</head>
<body>

    <!-- TOP BAR -->
	<div id="top-bar">
		
		<div class="page-full-width">
		
			<a href="login.aspx" class="round button dark ic-left-arrow image-left ">Trở về website</a>

		</div> <!-- end full-width -->	
	
	</div> <!-- end top-bar -->
	
	
	
	<!-- HEADER -->
	<div id="header">
		
		<div class="page-full-width cf">
	
			<div id="login-intro" class="fl">
			
				<h1>Đăng nhập vào hệ thống</h1>
				<h5>Tiện lợi cho bạn là niềm vui của chúng tôi !</h5>
			
			</div> <!-- login-intro -->
			
			<!-- Change this image to your own company's logo -->
			<!-- The logo will automatically be resized to 39px height. -->
			<a href="#" id="company-branding" class="fr">
			<img src="../../resource/images/chomy-logo.png" alt="Chợ mỹ" /></a
			
		</div> <!-- end full-width -->	

	</div> <!-- end header -->
	
	
	
	<!-- MAIN CONTENT -->
	<div id="content">
	
		<form action="#" method="POST" runat="server" class="login-form" defaultbutton="lbtSubmit" defaultfocus="lbtSubmit">
            <asp:Panel Visible="false" ID="pnError" class="error-box round" runat="server">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </asp:Panel>
			<fieldset>
                
				<p>
					<label for="login-username">Email</label>
					
                    <asp:TextBox ID="txtUsername" CssClass="round full-width-input" runat="server" required=""></asp:TextBox>
					
				</p>

				<p>
					<label for="login-password">Mật khẩu</label>					
                    <asp:TextBox ID="txtPassword" CssClass="round full-width-input"
                        runat="server" TextMode="Password" required=""></asp:TextBox>					
				</p>
				
				<p>Tôi, <a href="#">Quên mật khẩu</a>.</p>
				
				
              <asp:LinkButton ID="lbtSubmit" 
                    CssClass="button round blue image-right ic-right-arrow" runat="server" 
                    onclick="lbtSubmit_Click">Đăng nhập</asp:LinkButton>				
                
			</fieldset>
			<br/><div class="information-box round">Vui lòng sử dụng thông tin cấu hình mail để đăng nhập cho hệ thống này.</div>

		</form>
		
	</div> <!-- end content -->
	
	
	
	<!-- FOOTER -->
	<div id="footer">
		<p>&copy; Copyright 2013 <a href="#">FASTAUTOMATICMAIL</a>. All rights reserved.</p>
		<p><strong>Design</strong> by <a href="#">FPT Team</a></p>	
	</div> <!-- end footer -->
    
</body>
</html>
