<%@ Page Language="C#" AutoEventWireup="true" CodeFile="success.aspx.cs" Inherits="success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div.alert-message { 
            display: block; 
            padding: 13px 12px 12px; 
            font-weight: bold; 
            font-size: 14px; 
            color: white; 
            background-color: #2ba6cb; 
            margin-bottom: 12px; 
            -webkit-border-radius: 3px; 
            -moz-border-radius: 3px; 
            -ms-border-radius: 3px; 
            -o-border-radius: 3px; 
            border-radius: 3px; 
            text-shadow: 0 -1px rgba(0, 0, 0, 0.3); 
            position: relative;
            top: 0px;
            left: 0px;
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
        <div class="alert-message success">
            <div class="box-icon"></div>
            <p>Chúc mừng bạn đã đăng ký thành công gói <asp:Label ID="lblPackageName" runat="server" Text=""></asp:Label>.
            Chúng tôi vừa gửi một email  chứa thông tin đăng ký vào email của bạn.
            </p>
        </div>
        <div class="alert-message info">
                <div class="box-icon"></div>
                <a href="http://emailmarketing.1onlinebusinesssystem.com/webapp/page/backend/login.aspx" target="_parent"><p>Đăng nhập vào FA Mail</p></a>
        </div>
    </form>
</body>
</html>
