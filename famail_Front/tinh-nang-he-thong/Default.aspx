<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tinh_nang_he_thong_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
	<title>FASTAUTOMATICMAIL</title>
	<link href="http://chomy.com.vn/templates/ja_mesolite_ii/favicon.ico" rel="shortcut icon" type="image/x-icon"/>
	<!-- Stylesheets -->
	<link href='http://fonts.googleapis.com/css?family=Droid+Sans:400,700' rel='stylesheet'>
    <link href="../css/success.css" rel="stylesheet" />
   
	<!-- Optimize for mobile devices -->
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	
	<!-- jQuery & JS files -->
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
	<script src="../../resource/js/script.js"></script>  
</head>
<body>
    <form id="form1" runat="server">
    <div id="top-bar">		
	    <div class="page-full-width cf">

			<ul id="nav" class="fl">	
				<li class="v-sep">
				<a href="emailmarketing.1onlinebusinesssystem.com" class="round button dark ic-left-arrow image-left">
				Đến trang FAMail</a>
				</li>
				
			</ul> <!-- end nav -->
			
		</div> <!-- end full-width -->		
	</div> <!-- end top-bar -->

        <div id="content">
		
		<div class="page-full-width cf">		
			
			<div class="confirmation-box round">
			    <table>
                   <tr >
                       <td style="font-size:20px; color:red; " > Đăng ký thành công !</td>
                   </tr>
                   <tr>
                       <td> Cảm ơn Quí khách đã tin tưởng vào dịch vụ của chúng tôi</td>
                   </tr>
                    <tr>
                       <td> Thông tin tài khoản đăng nhập</td>
                   </tr>
                    <tr>
                       <td>
                           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                   </tr>
                    <tr>
                       <td>http://localhost:7318/FAMail_Back/webapp/page/backend/login.aspx</td>
                   </tr>
                     <tr>
                       <td></td>
                   </tr>
			   </table>
			    <br />    
               
			</div>	
            
			<asp:Image ID="Image1" ImageUrl="~/images/register-success.jpg" Width="100%" Height="400px" runat="server" />			
		
		</div> <!-- end full-width -->
			
	</div>
<div id="footer">

		<p>&copy; Copyright 2013 <a href="#">Công ty cổ phần MARKET AMARICAN</a>. All rights reserved.</p>
		<p><strong>Design</strong> by <a href="#">FPT Team</a></p>
	
	</div>
<div id="Div1">		
    <div class="page-full-width cf">
    </div>
</div>


    </form>
</body>
</html>
