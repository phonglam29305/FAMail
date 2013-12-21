<%@ Page Title="" Language="C#" MasterPageFile="~/master_page/baiviethtml.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="tinh_nang_he_thong_register" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="khung">
        <div id='inline_dangky'>
            <h2 style="margin-left: 8px; font-size: 30px; margin-top: -82px;">Đăng ký tài khoản FA Mail:<asp:Label ID="lblTenGoiMail" runat="server" Text=""></asp:Label>
            </h2>
            <%--<div style="float:left; padding-left:30px;"><span style="font-size:13px; text-align: left;"><i>(Phiên bản đầy đủ tính năng, danh sách 50 khách hàng, gởi không giới hạn. Thời gian 1 tháng)<asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </i></span></div>--%>
            <div style="float: left; padding-left: 30px; padding-top: 12px; color: blue; width: 600px; height: 35px; background-color: #e5f5f9; border-radius: 30px; margin-left: 50px; font-size: 20px;">
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
                            <asp:DropDownList ID="Drpacketime" runat="server" Style="width: 100px" CssClass="txtbox" OnSelectedIndexChanged="Drpacketime_SelectedIndexChanged" Width="48px" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="box-fcdk">
                        <div class="divbo" style="margin-left: 330px; margin-top: -33px; font-size: 14px; font-weight: bold; color: red;">
                            <asp:Label ID="Label15" runat="server" Text="Phí dịch vụ:"></asp:Label>
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
                            <asp:TextBox ID="txtclientname" runat="server" Width="222px" class="txtbox"></asp:TextBox>
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
                            <asp:TextBox ID="txtemail" class="txtbox" runat="server" Width="221px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="box-fcdk">
                        <div class="labelfcdk">
                            <span style="font-size: 16px; color: #FF0000;">*</span>
                            <asp:Label ID="Label5" runat="server" Text="Mật khẩu:" BorderStyle="None"></asp:Label>
                        </div>
                        <div class="divbox">
                            <asp:TextBox ID="txtPass" class="txtbox" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="box-fcdk">
                        <div class="labelfcdk">
                            <span style="font-size: 16px; color: #FF0000;">*</span>
                            <asp:Label ID="Label6" runat="server" Text="Nhập lại mật khẩu:" BorderStyle="None"></asp:Label>
                        </div>
                        <div class="divbox">
                            <asp:TextBox ID="txtpassAgain" class="txtbox" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="box-fcdk">
                        <div class="labelfcdk">
                            <span style="font-size: 16px; color: #FF0000;">*</span>
                            <asp:Label ID="Label7" runat="server" Text="Số điện thoại:" BorderStyle="None"></asp:Label>
                        </div>
                        <div class="divbox">
                            <asp:TextBox ID="txtphone" class="txtbox" runat="server" Width="220px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="box-fcdk">
                        <div class="labelfcdk">
                            <span style="font-size: 16px; color: #FF0000;">*</span>
                            <asp:Label ID="Label12" runat="server" Text="Địa chỉ:" BorderStyle="None"></asp:Label>
                        </div>
                        <div class="divbox">
                            <asp:TextBox ID="txtaddress" class="txtbox" runat="server" Width="221px"></asp:TextBox>
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
                        <div class="divbox1" style="margin-left: 326px; margin-top: -2px;">

                            <cc1:CaptchaControl ID="cptCaptcha" runat="server"
                                CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                CaptchaHeight="31" CaptchaWidth="105"
                                CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                CaptchaMaxTimeout="240" FontColor="#529E00" />


                        </div>
                        <div class="divbox2" style="margin-left: 435px; margin-top: -33px;">

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
                <div class="fcdk2" style="margin-left: -27px; margin-top: -419px;">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/FA MAIL.com.jpg" Width="272px" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>


