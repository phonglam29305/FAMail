<%@ Page Language="C#" AutoEventWireup="true" CodeFile="success.aspx.cs" Inherits="success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        .header {
                height:70px;
                width:100%;
                background-color:#3498db;
                color:#ecf0f1;
                border-radius:5px;
                margin-bottom:12px;
                -moz-border-radius:5px;
                -webkit-border-radius:5px;
                -ms-border-radius:5px;
                -o-border-radius:5px;
            }
                .header h2{
                    padding-top:20px;
                    text-align:center;
                    font-size:25px;
                    font-weight:bold;
                }
        div.alert-message { 
            display: block; 
            padding: 13px 12px 12px; 
            font-weight: bold; 
            font-size: 14px; 
            color: white; 
            background-color: #2ba6cb; 
            border: 1px solid rgba(0, 0, 0, 0.1); 
            margin-bottom: 12px; 
            -webkit-border-radius: 3px; 
            -moz-border-radius: 3px; 
            -ms-border-radius: 3px; 
            -o-border-radius: 3px; 
            border-radius: 3px; 
            text-shadow: 0 -1px rgba(0, 0, 0, 0.3); 
            position: relative; 
        }
            div.alert-message a {
                color:white;
            }
        div.alert-message .box-icon { 
            display: block; 
            float: left; 
            background-image: url('images/icon.png'); 
            width: 30px; 
            height: 25px; 
            margin-top: -2px; 
            background-position: -8px -8px; 
        }
        div.alert-message.success { 
            background-color: #5da423;
            color: #fff; 
            text-shadow: 0 -1px rgba(0, 0, 0, 0.3); 

        }
        div.alert-message.info .box-icon {
            margin-top:8px;    
        }
        div.alert-message.success .box-icon { 
            background-position: -48px -8px; 
            margin-top:8px;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="maincontent">
            <div class="header">
                <h2>Chúc mừng bạn !</h2>
            </div>
            <div class="alert-message success">
                <div class="box-icon"></div>
                <p>Bạn đã đăng ký thành công gói <asp:Label ID="lblPackageName" runat="server" Text=""></asp:Label>.</p>
            </div>
            <div class="alert-message success">
                <div class="box-icon"></div>
                <p>Chúng tôi vừa gửi một email chứa thông tin đăng ký vào email của bạn.</p>
            </div>
            <div class="alert-message info">
                    <div class="box-icon"></div>
                    <a href="http://emailmarketing.1onlinebusinesssystem.com/webapp/page/backend/login.aspx" target="_parent"><p>Đăng nhập vào FA Mail</p></a>
            </div>
        </div>
    </form>
</body>
</html>
