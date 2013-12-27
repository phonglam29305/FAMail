<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master" AutoEventWireup="true"
 CodeFile="createcontentmail.aspx.cs" Inherits="webapp_page_backend_CreateContentMail" Title="FASTAUTOMATICMAIL"
  ValidateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="side-content fr">
  <div class="content-module">
		        <div class="content-module-heading cf">				
				    <h3 class="fl">Soạn thư</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>
    			
			    </div> <!-- end content-module-heading -->
			    
			    <div class="content-module-main">
		          <asp:Panel Visible="false" ID="pnError" runat="server">
                    <div class="error-box round">
                        <asp:Label ID="lblError"  runat="server" Text=""></asp:Label> 
                    </div>
                  </asp:Panel>
                  <asp:Panel Visible="false" ID="pnSuccess" runat="server">
                    <div class="confirmation-box round">
                        <asp:Label ID="lblSuccess"  runat="server" Text=""></asp:Label> 
                    </div>
                  </asp:Panel>
			      <div class="content-module-main cf">
                 
			         <p>

        				<asp:HiddenField ID="hdfContentId" runat="server" />
        				
				        <asp:Label ID="Label1" runat="server" Text="Tiêu đề "></asp:Label> 
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:TextBox ID="txtSubject" CssClass="round default-width-input" runat="server" 
                             Width="98.5%" ToolTip="Nhập tiêu đề bức thư của bạn"></asp:TextBox>
			        </p>			        
			         
			       <p>
			            <asp:Label ID="Label2" runat="server" Text="Nội dung"></asp:Label> &nbsp;&nbsp;&nbsp; 
                        <em><div class="information-box round">Để đưa tên khách hàng vào nội dung bạn vui lòng nhập [khachhang] hệ thống sẽ tự động thay vào<br />
                            VD:Khách hàng là: Nguyễn Văn A khi bạn điền:  Chào, [khachhang] chúc mừng bạn...=> Chào, Nguyễn Văn A chúc mừng bạn...<br />
                            Lưu ý: nếu khách hàng chưa cung cấp thông tin họ tên, hệ thống sẽ thay đổi bằng địa chỉ email.
                            </div>
                        </em>
                    </p>
                    
                    <p>
                        <asp:TextBox ID="txtWelcome" CssClass="round default-width-input" Width="15%" runat="server" ToolTip="Nhập lời chào cho bức thư!">Chào</asp:TextBox>
                        <asp:RadioButton ID="rdoCustomerName" Checked="true" GroupName="groupWelcome" runat="server" />Tên khách hàng
                        <asp:RadioButton ID="rdoCustomerEmail" GroupName="groupWelcome" runat="server" />Mail khách hàng
                        <asp:TextBox ID="txtAfterWelcome" CssClass="round default-width-input" Width="35%" runat="server">thân mến !</asp:TextBox>
                        <asp:LinkButton ID="lbtAddWelcome" 
                            class="round button dark menu-user image-left" runat="server" 
                            onclick="lbtAddWelcome_Click" ToolTip="Click thêm lời chào vào nội dung">Thêm lời chào</asp:LinkButton>                             
                    </p>
                    
                    <p>
			                <asp:TextBox ID="txtBody" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <%--<asp:TextBox ID="txtBody" rows="15" style="width: 100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                    </p>             
                   <p>			                                                
                       <ul id="nav" class="fr">				            
			                <li>
		                    <asp:LinkButton ID="lbtInsertSignature" class="round button dark menu-user image-left" runat="server" ToolTip="Thêm chữ ký của bạn vào nội dung thư">Thêm chữ ký</asp:LinkButton>                             
				                <ul>
				                    <asp:DataList ID="dlSignature" runat="server" 
                                         RepeatColumns="1"  Width="100%" BorderStyle="None" 
                                       >  
                                         <HeaderTemplate>                                               
                                         </HeaderTemplate>                      
                                         <ItemTemplate>  
                                                <li> 
                                                    <%--<asp:Label ID="lblSignatureName" runat="server" Text="Signature"></asp:Label>--%>
                                                    <asp:LinkButton ID="lbtInsert" runat="server" onclick="lbtInsertSignature_Click" >Thêm</asp:LinkButton>                                                    
                                                </li>          
                                             
                                         </ItemTemplate>
                                         <FooterTemplate>
                                                       
                                         </FooterTemplate>
                                     </asp:DataList>
					                
				                </ul> 
			                </li>            			
		                </ul>                         
         
			        </p>                    
			        
                    <p>					
                        <asp:Button ID="btnSaveContent" runat="server" Text="Lưu" 
                            CssClass="button round blue image-right ic-add text-upper" 
                          onclick="btnSaveContent_Click"/>	
                            <asp:Button ID="btnRefesh" runat="server" Text="Làm mới" 
                            CssClass="button round blue image-right ic-refresh text-upper" 
                          onclick="btnRefesh_Click"/>                   

                            <%--<input id="btnCheck" type="button" value="Đánh giá nội dung" class="round blue ic-right-arrow"
                            onclick = "ShowCurrentTime()" />  --%>                  

                            <asp:Button ID="btnPreview" runat="server" Text="Kiểm tra HTML" 
                            CssClass="round blue ic-right-arrow" 
                            ToolTip="Xem với các trình duyệt Email: Gmail, Yahoo, Hotmail.." 
                            onclick="btnPreview_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy" 
                            CssClass="round blue ic-right-arrow" onclick="btnCancel_Click" 
                          PostBackUrl="~/webapp/page/backend/list-content-mail.aspx"/>	
                           
                    </p>
                    <div class="stripe-separator"><!--  --></div> 
			      </div>
	        </div>
    </div>    		     	      
 </div>	  


</asp:Content>

