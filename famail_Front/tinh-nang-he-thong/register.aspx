<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="tinh_nang_he_thong_Register" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/cssform.css" rel="stylesheet" />
    <style>
            body {
                font-family: 'Open Sans', sans-serif;
                margin:0px;
                padding:0;
            }
            p {
                font-size:15px;
                font-weight:bold;
                line-height:20px;
                padding-left:5px;
            }
            .cost {
                color:#069c37;
            }   
            #maincontent {
                width:546px;
                float:left;
                margin-top: -10px;
            }
            .header {
                height:70px;
                width:100%;
                background-color:#3498db;
                color:#ecf0f1;
                border-radius:5px;
            }
                .header h2{
                    padding-top:20px;
                    text-align:center;
                    font-size:25px;
                    font-weight:bold;
                }
            .textbox {
                
                width: 310px; 
                display: inline-block;
                height: 20px;
                padding: 4px 6px;
                margin-bottom: 10px;
                font-size: 14px;
                border: 1px solid #ccc;
                line-height: 20px;
                color: #555;
                vertical-align: middle;
                outline:none;
            }
            .error {
                border:1px solid red;
            }
            .captchavalidate {
                width:80px !important;
            }
                .textbox:focus {
                    border:1px solid #3498db;
                }
            .bodycontent {
                
            }
                .bodycontent .rows {
                    width:100%;
                    float:left;
                    height:40px;
                }
                .rows .leftcontent {
                    width:140px;
                    float:left;
                    padding:2px;
                    margin-left:16px;
                }
                .rows .rightcontent {
                    width:330px;
                    float:left;
                    padding:10px;
                }
            .clear {
                clear:both;
                height:10px;
                margin-bottom:20px;
                border-bottom:1px dashed #2c3e50;
            }
            .availablecss
            {
                background-color:#CEFFCE;
                border:1px solid green;
            }
            .notavailablecss
            {
                background-color:#FFD9D9;
                border:1px solid red;
            }
            #btnRegis {
                background: #368ee0;
                color: #fff;
                text-shadow: none;
                filter: none;
                border:0px;
                width:120px;
                font-size:20px;
                outline:none;
                padding:15px;
                border-radius:5px;
            }
                #btnRegis:focus,#btnRegis:hover {
                    background-color:#04c;
                }
            .ddList {
                display: inline-block;
                height: 30px;
                padding: 4px 6px;
                margin-bottom: 10px;
                font-size: 14px;
                line-height: 20px;
                color: #555;
                vertical-align: middle;
                border:1px solid #d8d8d8;
                -webkit-border-radius: 4px;
                -moz-border-radius: 4px;
                border-radius: 4px;
                outline:none;
            }
                .ddList:focus {
                    border:1px solid #3498db;
                }
            OPTION { 
                border:1px solid #3498db;
                -webkit-border-radius: 4px;
                -moz-border-radius: 4px;
                border-radius: 4px;
            }
        </style>
    <script src="../js/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="maincontent">
            <div class="header">
                <h2>Đăng ký gói dịch vụ</h2>
            </div>
            <div class="bodycontent">
                <div id="diverror" style="height:20px !important" runat="server" class="rows">
                    <div style="width:100%;text-align:center;">
                        <p style="font-size:12px;">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Gói đăng ký:</p>
                    </div>
                    <div class="rightcontent">
                        <p style="color:#069c37;margin-top:7px;">
                            <asp:Label ID="lblTenGoi" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Thời hạn:</p>
                    </div>
                    <div class="rightcontent">
                        <div style="float:left">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddList" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="1">1 tháng</asp:ListItem>
                            <asp:ListItem Value="3">3 tháng</asp:ListItem>
                            <asp:ListItem Value="6">6 tháng</asp:ListItem>
                            <asp:ListItem Value="12">12 tháng</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <p class="cost" style="float:left;margin-top:5px;margin-left:10px;">
                            <asp:Label ID="lblCost" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Tên đăng nhập:
                    </div>
                    <div class="rightcontent">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox"></asp:TextBox>
                        
                        <br />
                        <span id="idstatus"></span>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Mật khẩu:</p>
                    </div>
                    <div class="rightcontent">
                        <asp:TextBox ID="txtPass" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Nhập lại mật khẩu:</p>
                    </div>
                    <div class="rightcontent">
                        <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Email:</p>
                    </div>
                    <div class="rightcontent">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" ></asp:TextBox>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Địa chỉ:</p>
                    </div>
                    <div class="rightcontent">
                        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Số điện thoại:</p>
                    </div>
                    <div class="rightcontent">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="rows">
                    <div class="leftcontent">
                        <p>Mã xác nhận:</p>
                    </div>
                    <div class="rightcontent">
                        <div style="float:left;"><asp:TextBox ID="txtCapt" runat="server" CssClass="textbox captchavalidate"></asp:TextBox></div>
                        <div style="float:left;width:100px;margin-right:35px;">
                            <cc1:CaptchaControl ID="cptCaptcha" runat="server"
                                CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                CaptchaHeight="31" CaptchaWidth="105"
                                CaptchaLineNoise="None" CaptchaMinTimeout="5" />
                        </div>
                        <div style="float:left;"><asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="~/images/capchar.gif"/></div>
                    </div>
                </div>
                <div class="rows">
                    <div style="width:100%;padding:2px;height:40px;margin-top:15px;">
                        <asp:CheckBox ID="chkAgree" runat="server" Checked="True" />
                        <span style="font-size: 13px; color: #000000;">Tôi đồng ý với 
                        <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" Font-Italic="True"  Target="_parent" NavigateUrl="http://emailmarketing.1onlinebusinesssystem.com"><u>Quy định sử dụng</u> </asp:HyperLink>&
                        <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="True" Font-Italic="True"><u> Chính sách bảo mật của FA MAIL</u></asp:HyperLink></span>
                    </div>
                </div>
                <div class="clear"></div>
                <div class="rows">
                    <div class="leftcontent"></div>
                    <div class="rightcontent">
                        <div style="margin-left:35px;"><asp:Button ID="btnRegis" runat="server" Text="Đăng ký" OnClick="btnRegis_Click" /></div>
                    </div>
                </div>
            </div>
            
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
