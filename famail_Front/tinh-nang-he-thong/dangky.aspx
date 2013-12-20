<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Dangky.aspx.cs" Inherits="tinh_nang_he_thong_Dangky" %>

<!DOCTYPE html>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/cssform.css" rel="stylesheet" />
    <link href="../colorbox.css" rel="stylesheet" />
    <%-- java cho chuc nang kiem tra  --%>
  /* <%--<script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.validationEngine-vi.js"></script>  
    <script src="../js/jquery.validationEngine.js"></script>
    <link href="../css/template.css" rel="stylesheet" />
    <link href="../css/validationEngine.jquery.css" rel="stylesheet" />
    <script>
        jQuery(document).ready(function () {
            // binds form submission and fields to the validation engine
            jQuery("#form1").validationEngine();
        });
        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                // this allows to use i18 for the error msgs
                return options.allrules.validate2fields.alertText;
            }
        }
	</script>--%>*/
    <%-- java cho chuc nang kiem tra  --%>
</head>
<body>
    <form runat="server" id="form1">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div id='inline_dangky'>
                    <h2 style="margin-left:40px; font-size:30px; margin-top:-10px; ">Đăng ký tài khoản FA Mail:<asp:Label ID="lblTenGoiMail" runat="server" Text=""></asp:Label>
                    </h2>
                    <%--<div style="float:left; padding-left:30px;"><span style="font-size:13px; text-align: left;"><i>(Phiên bản đầy đủ tính năng, danh sách 50 khách hàng, gởi không giới hạn. Thời gian 1 tháng)<asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </i></span></div>--%>
                    <div style="float: left; padding-left: 30px; width: 600px; height: 19px; background-color: #e5f5f9; border-radius: 30px; margin-left: 50px;">
                        <asp:Label ID="lbdiengiai" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="formcontentdangky">
                        <div class="fcdk1">
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label1" runat="server" Text="Gói thời gian:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:DropDownList ID="Drpacketime" runat="server" CssClass="txtbox" OnSelectedIndexChanged="Drpacketime_SelectedIndexChanged" Width="48px" AutoPostBack="True"></asp:DropDownList>
                                </div>                                                          
                           </div>
                                   <div class="box-fcdk">
                                <div class="divbo" style="margin-left:285px;margin-top:-33px;font-size:14px;font-weight:bold; color:red;">
                                   <asp:Label ID="Label15" runat="server" Text="Phí tương ứng :"></asp:Label>                         
                                   <asp:Label ID="lbtongphi" runat="server"></asp:Label>
                                </div>                                
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label4" runat="server" Text="Tên của bạn:" BorderStyle="None"></asp:Label>
                                    <asp:Label ID="lbtotalfree" runat="server" Text="0" Visible="False"></asp:Label>
                                </div>
                                <div class="divbox">                               
                                    <asp:TextBox ID="txtclientname" CssClass="validate[required] text-input" runat="server" Width="222px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <%--<span style="font-size:16px ; color:#FF0000;" >&nbsp;&nbsp;</span>--%>
                                    <asp:Label ID="Label2" runat="server" Text="Tên doanh nghiệp / Cửa hàng:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtcompanyname" CssClass="txtbox" runat="server" Width="221px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <span style="font-size: 16px;">Email:</span>
                                    <asp:Label ID="Label3" runat="server" Text="(Là tên đăng nhập của bạn)" BorderStyle="None" Font-Size="13px" Font-Italic="True"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtemail" CssClass="validate[required,custom[email]] text-input" runat="server" Width="221px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label5" runat="server" Text="Mật khẩu:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtPass" CssClass="validate[required] text-input" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label6" runat="server" Text="Nhập lại mật khẩu:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtpassAgain" CssClass="validate[required,equals[txtPass]] text-input" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label7" runat="server" Text="Số điện thoại:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtphone" CssClass="validate[required,custom[phone]] text-input" runat="server" Width="220px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label12" runat="server" Text="Địa chỉ:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtaddress" CssClass="validate[required] text-input" runat="server" Width="221px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label14" runat="server" Text="Mã xác nhận:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtbody" CssClass="txtmxn" runat="server" Width="90px"></asp:TextBox>
                                     
                                      </div>  
                                     <div class="divbox1" style="margin-left:326px;margin-top:-2px;">
                                    
    <cc1:CaptchaControl ID="cptCaptcha" runat="server"

        CaptchaBackgroundNoise="Low" CaptchaLength="5"

        CaptchaHeight="31" CaptchaWidth="105"

        CaptchaLineNoise="None" CaptchaMinTimeout="5"

        CaptchaMaxTimeout="240" FontColor = "#529E00" />

                                     
                                </div>  
                                  <div class="divbox2" style="margin-left:435px; margin-top:-33px;">
                                   
                                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/capchar.gif" OnClientClick="btnVerify_Click" />
                                </div>  
                                                                                                                                                              
                            </div>
                            <div class="box-fcdk">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" />
                                <span style="font-size: 13px; color: #000000;">Tôi đồng ý với 
                            <asp:HyperLink ID="HyperLink4" runat="server"><u>Quy định sử dụng</u> </asp:HyperLink>&
                            <asp:HyperLink ID="HyperLink5" runat="server"><u> Chính sách bảo mật của FA MAIL</u></asp:HyperLink></span>
                            </div>
                            <div class="box-btndangky">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/imagesfrom/taotaikhoang.png" OnClick="ImageButton1_Click" />
                            </div>
                        </div>
                        <div class="fcdk2" style="margin-left:-27px;margin-top:60px;">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/FA MAIL.com.jpg" Width="260px" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
