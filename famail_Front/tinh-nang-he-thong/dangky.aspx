<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dangky.aspx.cs" Inherits="tinh_nang_he_thong_Dangky" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/cssform.css" rel="stylesheet" />
    <link href="../colorbox.css" rel="stylesheet" />
    <style>
        .box-fcdk1 {
            margin-top: -10px;
        }

        .txtbox {
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div id='inline_dangky'>
                    <h2>Đăng ký tài khoản FA Mail dùng thử 2$
                        <asp:Label ID="lbgoimail" runat="server" Text="Label"></asp:Label></h2>
                    <%--<div style="float:left; padding-left:30px;"><span style="font-size:13px; text-align: left;"><i>(Phiên bản đầy đủ tính năng, danh sách 50 khách hàng, gởi không giới hạn. Thời gian 1 tháng)<asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </i></span></div>--%>
                    <div style="float: left; padding-left: 30px; width: 600px; height: 60px; background-color: #e5f5f9; border-radius: 30px; margin-left: 50px;">
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
                                &nbsp;
                            <asp:Label ID="Label15" runat="server" Text="Phí"></asp:Label>
                                &nbsp;
                            <asp:Label ID="lbtongphi" runat="server"></asp:Label>
                            </div>

                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label4" runat="server" Text="Tên của bạn:" BorderStyle="None"></asp:Label>
                                    <asp:Label ID="lbtotalfree" runat="server" Text="0" Visible="False"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtclientname" CssClass="txtbox" runat="server" Width="222px"></asp:TextBox>
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
                                    <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server" Width="221px"></asp:TextBox>
                                </div>
                            </div>

                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label7" runat="server" Text="Số điện thoại:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtphone" CssClass="txtbox" runat="server" Width="220px"></asp:TextBox>
                                </div>
                            </div>

                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label12" runat="server" Text="Địa chỉ:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtaddress" CssClass="txtbox" runat="server" Width="221px"></asp:TextBox>
                                </div>
                            </div>

                            <div class="box-fcdk">
                                <div class="labelfcdk">
                                    <span style="font-size: 16px; color: #FF0000;">*</span>
                                    <asp:Label ID="Label14" runat="server" Text="Mã xác nhận:" BorderStyle="None"></asp:Label>
                                </div>
                                <div class="divbox">
                                    <asp:TextBox ID="txtbody" CssClass="txtmxn" runat="server"></asp:TextBox>
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
                        <div class="fcdk2">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/FA MAIL.com.jpg" Width="240px" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
