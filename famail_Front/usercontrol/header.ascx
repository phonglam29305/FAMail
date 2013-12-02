<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="usercontrol_header" %>

<script type="text/javascript">

    var analyticsFileTypes = [''];
    var analyticsEventTracking = 'enabled';
</script>
<script type="text/javascript">
    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-1905629-1']);
    _gaq.push(['_addDevId', 'i9k95']); // Google Analyticator App ID with Google 

    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();
</script>
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<script type="text/javascript" src="Jquery/jquery.js"></script>
<script type="text/javascript" src="Jquery/jquery.corner.js"></script>
<script type="text/javascript" src="Jquery/jquery.cookie.js"></script>
<script type='text/javascript' src='Scripts/jquery.js'></script>

<link href="../StyleSheet.css" rel="stylesheet" />--%>
<%--<script>
    $(document).ready(function () {
        $("#Label2").click(function () {
            $("#divche").show();
            $("#divche").fadeTo(0, 0.8);
            $("#divpopup").load("dangky.aspx").slideDown(500);
        });

    });
</script>--%>

<!-- Google+ -->
    <script type="text/javascript" src="script/fasautomaticmail-scripts.js"></script>
	<meta name="google-site-verification" content="a5wY9kTPtBEzXLcoZyOMCD6BucrSH193SPgYFXgfIQs" />
<!-- END Google+ -->   
<link href="../css/jquery.fancybox.css" rel="stylesheet" />
<link href="../css/style.css" rel="stylesheet" />
<a href="http://fastautomaticmail.com" id="logo" title="">Fastautomaticmail.com</a>
		<div class="headerlinks">
        	<ul><li><a href="#">Hãy để chúng tôi tư vấn cho bạn: 0917890550</a> </li>
				<li><a href="#">
                 <%--  <img src="../images/registration.gif" alt="Đăng ký dùng thử" title="Đăng ký dùng thử"id="Label" />--%>
                    </a></li>
				<li><a href="#">
                 <%--   <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
                    </a></li>
            </ul>
        </div>		
        <div class="login-btn"><a href="http://fastautomaticmail.com/webapp/page/backend/login.aspx" target="_blank" rel="nofollow">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/css/images/dangnhaphethong.png" Height="30px" />
        </a></div>	
        <div class="headhtml"><span>Hotline: 0917890550</span></div>
		<ul class="headsocial">
        <li></li>
        <li class="twitter"><a href="#" target="_blank" rel="nofollow">Twitter</a></li>
        <li class="facebook"><a href="#" target="_blank" rel="nofollow">Facebook</a></li>
        <li style="padding-top: 2px;"><script type="text/javascript" src="https://apis.google.com/js/plusone.js"></script> <g:plusone size="medium"></g:plusone></li>  
        </ul>				
        <ul class="headsects">
			<li><a href="../Default.aspx">Email Marketing</a></li>
            <li><a href="#">Hệ thống Famail</a></li>
            <li><a href="#">Hướng dẫn đăng ký</a></li>
            <li><a href="../tinh-nang-he-thong/Bang-gia.aspx">Bảng giá</a></li>
            <li><a href="#">Blog</a></li>
            <li><a href="../dieu-khoan/gioi-thieu-fa-mail.aspx"> Về chúng tôi</a></li>					
        </ul>

<%-- <div id="divche"></div>
 <div id="divpopup"></div>--%>