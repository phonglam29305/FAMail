<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id='support'>
         <div class="LH_voichungtoi">                                           
             <asp:Label ID="Label1" runat="server" Text="Liên hệ với chúng tôi " BorderStyle="None" ForeColor="#0000ff"></asp:Label>                                                               
         </div>                                       
         <div class="firstname">
             <asp:TextBox ID="txtho"   runat="server" Width="140px" Height="25px" placeholder="Họ" ></asp:TextBox>                            
         </div>
         <div class="lastname">
             <asp:TextBox ID="txtten" runat="server" Width="140px" Height="25px" placeholder="Tên"></asp:TextBox>
         </div> 
         <div class="email">
             <asp:TextBox ID="txtemail" CssClass="validate[required] text-input" runat="server" Width="289px" Height="25px" placeholder="Email"></asp:TextBox>
         </div>  
         <div class="phone">
             <asp:TextBox ID="txtsodienthoai" CssClass="validate[required] text-input" runat="server" Width="289px" Height="25px" placeholder="Số điện thoại"></asp:TextBox>
         </div> 
         <div class="conten">
             <asp:TextBox ID="txtconten"  runat="server" Width="289px" Height="100px" TextMode="MultiLine" placeholder="Nội dung"></asp:TextBox>
         </div>                                                                                              
         <div id="btdangky">
             <asp:ImageButton ID="image" runat="server" ImageUrl="~/images/contact-submit.png" OnClick="image_Click" />
         </div>
          <asp:TextBox ID="txtcontenkhachhang" runat="server" Text="Nội dung cần hỗ trợ của bạn đã được chúng tôi tiếp nhận.Chúng tôi sẽ cố gắn liên hệ lại với bạn trong thời gian sớm nhấn. Trân trọng cảm ơn" Visible="False"></asp:TextBox>
    </div>

    <div id='Contact'>
        <div class="lienhe">                                           
            <asp:Label ID="Label2" runat="server" Text="Liên hệ" BorderStyle="None" ForeColor="#0000ff" Font-Size="30px"></asp:Label>                                                                                      
        </div> 
        <div class="image">
                           
        </div>
        <div class="truso">
            <asp:Label ID="Label3" runat="server" Font-Size="20px" Text="Trụ sở"></asp:Label>
        </div> 
                                                                              
        <div class="thongtin">
            <asp:Label ID="Label4" runat="server" Font-Size="14px" Text="Để biết thông tin nói chung, quan hệ báo chí, tuyển dụng. Quảng cáo hoặc thắc mắt. Xin liên hệ văn phòng chúng tôi tại Seattle"></asp:Label>
        </div> 
        <div class="diachi">
            <asp:Label ID="Label5" runat="server" Font-Size="14px" Text="19236 98th AVe S renton Wa 98055 USA"></asp:Label>                  
        </div>  
        <div class="hotro">
            <asp:Label ID="Label6" runat="server" Font-Size="20px" Text="Hỗ trợ kỹ thuật"></asp:Label> <br />
            <asp:Label ID="Label7" runat="server" Font-Size="14px" Text="Nếu bạn là khách hàng của FAmail và cần sự hỗ trợ kỹ thuật, vui lòng bấm vào đây để biết thông tin về cách liên hệ với nhóm hỗ trợ của chúng tôi"></asp:Label>
        </div>   
    </div>
</asp:Content>

