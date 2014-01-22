<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VerifyEmail.aspx.cs" Inherits="VerifyEmail" %>

<!DOCTYPE html>

<html lang="en">
<head>
	<meta charset="utf-8">
	<title>FASTAUTOMATICMAIL</title>
	<link href="http://chomy.com.vn/templates/ja_mesolite_ii/favicon.ico" rel="shortcut icon" type="image/x-icon"/>
	<!-- Stylesheets -->
	<link href='http://fonts.googleapis.com/css?family=Droid+Sans:400,700' rel='stylesheet'>
	<link rel="stylesheet" href="webapp/resource/css/style.css">
	
	<!-- Optimize for mobile devices -->
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	
	<!-- jQuery & JS files -->
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
	<script src="webapp/resource/js/script.js"></script>  
</head>
<body>

	<!-- TOP BAR -->
	<div id="top-bar">		
	    <div class="page-full-width cf">

			<ul id="nav" class="fl">	
				<li class="v-sep">
				<a href="http://emailmarketing.1onlinebusinesssystem.com" class="round button dark ic-left-arrow image-left">
				Đăng nhập hệ thống</a>
				</li>
				
			</ul> <!-- end nav -->
			
		</div> <!-- end full-width -->		
	</div> <!-- end top-bar -->
	

	<!-- MAIN CONTENT -->
	<div id="content">
		
		<div class="page-full-width cf">		
			
			<div class="confirmation-box round">
			    <asp:Label ID="lblStatus" Text="Bạn đã xác nhận thành công !" runat="server"></asp:Label>
			    <br />    
               
			</div>	
			<asp:Image ID="Image1" ImageUrl="~/webapp/resource/images/register-success.jpg" Width="100%" Height="400px" runat="server" />			
		
		</div> <!-- end full-width -->
			
	</div> <!-- end content -->
	
	
	
	<!-- FOOTER -->
	<div id="footer">

		<p>&copy; Copyright 2013 <a href="#">Hệ thống FA MAI</a>. All rights reserved.</p>
		<p><strong>Design</strong> by <a href="#"></a></p>
	
	</div> <!-- end footer -->
<div id="Div1">		
    <div class="page-full-width cf">
    </div>
</div>

</body>
</html>