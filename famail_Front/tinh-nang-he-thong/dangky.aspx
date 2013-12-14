<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dangky.aspx.cs" Inherits="tinh_nang_he_thong_Dangky" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/cssform.css" rel="stylesheet" />
    <link href="../colorbox.css" rel="stylesheet" />
</head>
<body>
    <form id="ss" runat="server">
        
		    <div id='inline_dangky'>
                <h2>Đăng ký tài khoản FA Mail dùng thử 2$ <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h2>
                <div style="float:left; padding-left:30px;"><span style="font-size:13px; text-align: left;"><i>(Phiên bản đầy đủ tính năng, danh sách 50 khách hàng, gởi không giới hạn. Thời gian 1 tháng)</i></span></div>
                
                <div class="formcontentdangky">
                    <div class="fcdk1">

                        <div class="box-fcdk">
                          <div class="labelfcdk"> 
                              <span style="font-size:16px ; color:#FF0000;" >*</span>
                              <asp:Label ID="Label1" runat="server" Text="Gói thời gian:" BorderStyle="None"></asp:Label>
                          </div>
                          <div class="divbox">  
                              <asp:DropDownList ID="Drpacketime" runat="server" CssClass="txtbox"></asp:DropDownList>
                          </div>
                        </div>
                        <div class="box-fcdk">
                          <div class="labelfcdk"> 
                              <span style="font-size:16px ; color:#FF0000;" >*</span>
                              <asp:Label ID="Label5" runat="server" Text="Tên của bạn:" BorderStyle="None"></asp:Label>
                          </div>
                          <div class="divbox">  
                            <asp:TextBox ID="txtten" CssClass="txtbox" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="box-fcdk">
                          <div class="labelfcdk">
                              <%--<span style="font-size:16px ; color:#FF0000;" >&nbsp;&nbsp;</span>--%>  
                              <asp:Label ID="Label2" runat="server" Text="Tên doanh nghiệp / Cửa hàng:" BorderStyle="None"></asp:Label>
                          </div>
                          <div class="divbox">  
                            <asp:TextBox ID="txttendoanhnghiep" CssClass="txtbox" runat="server"></asp:TextBox>
                          </div>
                        </div>

                        <div class="box-fcdk">
                          <div class="labelfcdk">
                              <span style="font-size:16px ; color:#FF0000;" >*</span>  
                              <span style="font-size:16px ; ">Email:</span>                              
                              <asp:Label ID="Label3" runat="server" Text="(Là tên đăng nhập của bạn)" BorderStyle="None" Font-Size="13px" Font-Italic="True"></asp:Label>
                          </div>
                          <div class="divbox">  
                            <asp:TextBox ID="txtemail" CssClass="txtbox" runat="server"></asp:TextBox>
                          </div>
                        </div>

                        <div class="box-fcdk">
                          <div class="labelfcdk">  
                              <span style="font-size:16px ; color:#FF0000;" >*</span>
                              <asp:Label ID="Label7" runat="server" Text="Mật khẩu:" BorderStyle="None"></asp:Label>
                          </div>
                          <div class="divbox">  
                            <asp:TextBox ID="txtmatkhau" CssClass="txtbox" runat="server"></asp:TextBox>
                          </div>
                        </div>

                        <div class="box-fcdk">
                          <div class="labelfcdk"> 
                              <span style="font-size:16px ; color:#FF0000;" >*</span> 
                              <asp:Label ID="Label12" runat="server" Text="Nhập lại mật khẩu:" BorderStyle="None"></asp:Label>
                          </div>
                          <div class="divbox">  
                            <asp:TextBox ID="txtnhaplaimatkhau" CssClass="txtbox" runat="server"></asp:TextBox>
                          </div>
                        </div>

                        <div class="box-fcdk">
                          <div class="labelfcdk"> 
                              <span style="font-size:16px ; color:#FF0000;" >*</span> 
                              <asp:Label ID="Label14" runat="server" Text="Mã xác nhận:" BorderStyle="None"></asp:Label>
                          </div>
                          <div class="divbox">  
                              <asp:TextBox ID="txtmaxacnhan" CssClass="txtmxn" runat="server"></asp:TextBox>                              
                          </div>
                          <div class="divbox">  
                               <asp:Image ID="ImgCaptcha"  runat="server" ImageUrl="~/captcha.ashx" Width="100px" />                             
                          </div>
                        </div>

                        <div class="box-fcdk">
                        <asp:CheckBox ID="CheckBox1" runat="server"  Checked="True" />
                            <span style="font-size:13px; color:#000000;">Tôi đồng ý với 
                            <asp:HyperLink ID="HyperLink4" runat="server"><u>Quy định sử dụng</u> </asp:HyperLink>&
                            <asp:HyperLink ID="HyperLink5" runat="server"><u> Chính sách bảo mật của FA MAIL</u></asp:HyperLink></span>
                        </div>

                        <div class="box-btndangky">
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="inline" href="#inline_dangnhap" OnClick="LinkButton2_Click">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/imagesfrom/taotaikhoang.png" Width="200px" />
                            </asp:LinkButton>
                        </div>

                    </div>
                    <div class="fcdk2">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/FA MAIL.com.jpg" Width="240px" />
                    </div>
                </div>
	
			</div>

	 
        </form>
</body>
</html>
