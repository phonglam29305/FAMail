<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true"
 CodeFile="config-email-send.aspx.cs" Inherits="webapp_page_backend_Config_Email_Send" ValidateRequest="false" 
 Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Thông tin cấu hình</h3>
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
				    <div class="half-size-column fl">					
					    <fieldset>  
						        <p>
								    <label for="full-width-input">Tài khoản</label>
						         	<asp:TextBox ID="txtEmailConfig" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								    <em>Tài khoản đăng nhập SMTP của bạn!</em></p>
							    <p>
								    <label for="full-width-input">Mật khẩu</label>
								     <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								    <em>Mật khẩu mail cấu hình ! </em>								
							    </p>
							    <p>
								    <label for="full-width-input">Nhập lại mật khẩu</label>
								     <asp:TextBox ID="txtConfilmPassword" TextMode="Password" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								    <em>Nhập lại mật khẩu mail cấu hình ! </em>								
							    </p>

                                <p>
                                     <label for="simple-input">Chọn phòng ban</label>
                             <asp:DropDownList ID="drlDepartmen" runat="server" CssClass="round default-width-input" style="height: 35px; border: 1px solid #bbbdbe; width:360px;">
                             </asp:DropDownList>
                             <em>Chon phòng ban</em>
                             <br />
				                   </p>
							    	       <br />       <br />				
						    </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr" style="height: 450px;">
				        <fieldset>
				            <p>
							    <label for="simple-input">Server</label>								
                                <asp:TextBox ID="txtServer" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Nhập thông tin server gui mail Ví dụ: mail.chomy.net !</em>
						    </p>						
							
						    <p>
							    <label for="simple-input">Port</label>								
                                <asp:TextBox ID="txtPort"  CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                <em>Port gửi mail của server , ví dụ: 25 !</em>
						    </p>
						        <p>
							    <label for="simple-input">Chế độ SSL/tls</label>								
                         <asp:CheckBox ID="chkIsSSL" runat="server" />
                                <em>Chế độ mã hóa dữ liệu của server !</em>
						    </p>
						     <p>
								 <label for="simple-input">Email gửi</label>    								
                                 <asp:TextBox ID="txtEmailSend" CssClass="round default-width-input" 
                                        runat="server" ToolTip=" Được sử dụng để làm email gửi tới khách hàng "></asp:TextBox>
                                 <em>Được sử dụng để làm email gửi tới khách hàng </em>&nbsp;</p>
						    <p>
								 <label for="simple-input">Tên cấu hình</label>    								
                                 <asp:TextBox ID="txtName" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                                 <em>Được sử dụng để làm tên mail gửi tới khách hàng</em>
							 </p>
						
				        </fieldset>				             
				    </div>
				   
				    <div class="full-width-editor" style="float: left; margin-top: 30px;">  
				          
				         <br />
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu cấu hình" 
                                CssClass="button round blue image-right ic-add text-upper" 
                                  onclick="btnSave_Click" />	
                            <asp:Button ID="btnTest" runat="server" Text="Kiểm tra" 
                                CssClass="button round blue image-right ic-refresh text-upper" 
                                  onclick="btnTest_Click" Visible="False" />                            
				        </fieldset>	
				    </div> 
				    
			
		 <!-- end content-module-main -->
			</div>			
		</div>
		
		<!--end content 01-->
	  </div>
	    <div class="content-module">
				<div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách cấu hình</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
			    <div class="content-module-main" style="display:none">
				   <table>	                
				    <asp:DataList ID="dlMailConfig" runat="server" 
                         RepeatColumns="1"  Width="100%">  
                         <HeaderTemplate>
                               <thead>            					
		                            <tr>
			                            <th style="width:300px; text-align:left; padding-left: 10px;">Email Name</th>
			                            <th>Email</th>
			                            <th>Host Name</th>
			                            <th>Port</th>			                            
			                            <th>Option</th>
		                            </tr>            						
	                            </thead>
                         </HeaderTemplate>                      
                         <ItemTemplate>                                      						
						            <tbody>
							            <tr>
								            <td style="text-align:left; padding-left: 10px;">								            
                                                <asp:Label ID="EmailName" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
								            </td>
                                            <td>								            
                                                <asp:Label ID="Email" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
								            </td>
								            
								            <td>
								                <asp:Label ID="HostName" runat="server" Text='<%# Eval("Server") %>'></asp:Label>
								            </td>
								            <td>
								                <asp:Label ID="Port" runat="server" Text='<%# Eval("Port") %>'></asp:Label>
								            </td>
								            <td>
								           
								        	        <asp:ImageButton ID="btnDelete" runat="server" 
                                                  ImageUrl="~/webapp/resource/images/Delete-icon.png" 
                                                CommandArgument='<%# Eval("Id") %>' 
                                                        OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa cấu hình này không ?')" 
                                                        onclick="btnDelete_Click"    />
								            </td>
								            
							            </tr>             						
						            </tbody>            						
					            
                             
                         </ItemTemplate>
                         <FooterTemplate>
                            <tfoot>
					            <tr>
						            <td colspan="5" class="table-footer">
						            </td>
    								
					            </tr>
				            </tfoot>                     
                         </FooterTemplate>
                     </asp:DataList>
                   </table>
				  </div>
				
			</div>
</div>
 
</asp:Content>

