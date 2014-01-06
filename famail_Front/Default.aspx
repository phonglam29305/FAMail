<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- ===============SlideImage==================-->
    <div class="sectionTop">
		<h1 class="sectionTitle">Email Marketing tự động hóa</h1>
		<div class="sectionText">
    	    <p>Hệ thống email Marketing online từ fastautomaticmail làm cho bạn nhanh chóng và dễ dàng trong việc gửi, xây dựng danh sách email ... Và nhiều hơn thế nữa !</p>
      	    <ul>
        	    <li>Hệ thống Autoresponders, Broadcast Email</li>
        	    <li>Dễ sử dụng, thiết kế Templates HTML chuyên nghiệp</li>
        	    <li>Quản lý danh sách email dễ dàng</li>
        	    <li>Mở các chiến dịch thu thập email khách hàng</li>
      	    </ul>
    	</div>
		<div class="sectionBtns" style="margin-left:270px;">
    	    <a href="Bang-gia.aspx">
                <a href="Bang-gia.aspx"><img src="css/images/banggiavadangky.png" alt="Bảng giá & Đăng ký" /></a>
    	    </a>
   		</div>
    </div>
    <div class="sectionTabs">
	    <div class="features">Chức năng Email Marketing</div>
	    <div class="shadowleft"></div>
	    <div class="shadowright"></div>
    </div>
            <!-- ===============SlideImage==================-->
    <div id="sectconts">
        <span class="content-sectconts">  
             Email marketing từ FA Mail cung cấp cho bạn mọi thứ để bạn marketing cho khách hàng và khách hàng tiềm năng của bạn, 
             giúp bạn xây dựng danh sách email khách hàng, phát triển kinh doanh một cách tự động <br/><br/>

             Dịch vụ email marketing của chúng tôi không tính phí thiết lập và không có hợp đồng dài hạn.  
             Tài khoản mới thành lập chỉ mất vài phút, và chúng tôi đảm bảo sự hài lòng của bạn hoặc hoàn tiền lại cho bạn.<br/><br/>

             Hãy thử sử dụng hệ thống email marketing FA Mail với các công cụ tự động trả lời 
             hôm nay và bạn sẽ thấy lý do tại sao hàng ngàn doanh nghiệp sử dụng hệ thống email marketing của FA Mail 
             với một sự tin cậy hoàn toàn.  <br/>
        </span>
    </div>
    <div class="bottompagehtml">
      <div class="menu-content-1"> <!-- menu trai -->
      <div style="padding-top:20px;">
      <asp:Repeater ID="rptListPost" runat="server">
          <ItemTemplate>
            <ul style="float:left;margin-right:24px;">
                <li class="icon-content">
                   <a href='<%#Eval("link") %>'  class=""><%#Eval("keyName") %></a>
                    <%--<asp:Image ID="Image1"  runat="server" ImageUrl="~/images/iconbaiviet/autoresponders.gif" CssClass="imgleft" Width="46px" />--%>
                   <img src='http://emailmarketing.1onlinebusinesssystem.com<%#Eval("keyImage") %>' class="imgleft" width="46px" />
                
                   <div style="text-align: justify;">
                      <p>  
                          <%#Eval("keyDescription")%> <a href='<%#Eval("link") %>' class="more">Xem thêm</a>
                      </p>
                    </div>
                </li>
            </ul>
          </ItemTemplate>
      </asp:Repeater>
      </div>

      </div>
      <div class="menu-content-2"> <!--  Menu support -->
          <div class="boder_bottom">
               <div class="tittle_support">
                      <span> Chi phí thời gian </span>
               </div>
               <div class="center_support">    
                 <ul>	   
                    <li>   
                        <div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div><div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div>
                        <div class="downarrow left"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="downarrow"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div><div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div>
                        <div class="downarrow left"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="downarrow"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div><div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div>
                        <div class="downarrow left"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="downarrow"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div><div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div>
                        <div class="downarrow left"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="downarrow"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div><div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div>
                        <div class="downarrow left"><div style="width:100px;height:100px;"></div></div>
                        <div class="downarrow"><img style="width:100px;height:100px;" src="images/blue_arrow_down.png" /></div>
                        <div class="list"> </div><div class="list"><img src="images/question.jpg" height="40px" width="40px" /></div>
                       <div class="clear"></div>
                    </li>    
                 </ul>    
                <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
      </div>
    </div>
</asp:Content>

