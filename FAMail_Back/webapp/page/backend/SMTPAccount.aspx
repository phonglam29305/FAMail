﻿<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="SMTPAccount.aspx.cs" Inherits="webapp_page_backend_Default" %>

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
                        <asp:HiddenField ID="hdfId" runat="server" /> 					
					    <fieldset>  
						        <p>
								    <label for="full-width-input">Email đăng nhập</label>
						         	<asp:TextBox ID="txtEmailConfig" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								    
							    <p>
								    <label for="full-width-input">AccessKep</label>
								     <asp:TextBox ID="txtaccesskey"  CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								   							
							    </p>
							    <p>
								    <label for="full-width-input">PasswordSMTP</label>
								     <asp:TextBox ID="txtpasssmtp"  CssClass="round default-width-input" 
                                        runat="server" TextMode="Password"></asp:TextBox>
								    								
							    </p>

                                <p>
                                     <label for="simple-input">UserNameSMTP</label>
                                        <asp:TextBox ID="txtusername" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>                          
                             <br />
				                   </p>
							    	       				
						    </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr" style="height: 264px;">
				        <fieldset>
				            <p>
							    <label for="simple-input">Mật khẩu</label>								
                                <asp:TextBox ID="txtpassword" CssClass="round default-width-input" 
                                    runat="server" TextMode="Password"></asp:TextBox>
                               
						    </p>						
							
						    <p>
							    <label for="simple-input">SecrectKey</label>								
                                <asp:TextBox ID="txtsecrectkey"  CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                            >
						    </p>
						      
						     <p>
								 <label for="simple-input">ServerSMTP</label>    								
                                 <asp:TextBox ID="txtserversmtp" CssClass="round default-width-input" 
                                        runat="server" ToolTip=" Được sử dụng để làm email gửi tới khách hàng "></asp:TextBox>
                               &nbsp;</p>
						    <p>
								 <label for="simple-input">Giới Hạn gửi mail</label>    								
                                 <asp:TextBox ID="txtlimit" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                               
							 </p>
						
				        </fieldset>				             
				    </div>
				   
				    <div class="full-width-editor" style="float: left; margin-top: 0px;">  
				          
				         <br />
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu cấu hình" 
                                CssClass="button round blue image-right ic-add text-upper" OnClick="btnSave_Click" 
                                  />	
                                                        
				        </fieldset>	
				    </div> 
				    
			
		 <!-- end content-module-main -->
			</div>			
		</div>
		
		<!--end content 01-->
	  </div>
	    <div class="content-module">
				<div class="full-width-editor">
				        <div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách mail </h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
				   <%--<table>	                --%>
				  <%--  <table>--%>
                                    <asp:DataList ID="dtsmtpaccount" runat="server" RepeatColumns="1" Width="100%">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    
                                                    <th>  Email </th>
                                                    <th>  Giới hạn gởi mail/s  </th>                                           
                                                     <th> Điều chỉnh </th>
                                                </tr>
                                            </thead>
                                        </HeaderTemplate>
                                        <FooterTemplate>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="5" class="table-footer">
                                                    </td>
                                                </tr>
                                            </tfoot>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                          <tbody>
                                    <tr>
                                      
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblmail" runat="server" Text='<%# Eval("email") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgioihang" runat="server" Text='<%# Eval("limit") %>'></asp:Label>
                                        </td>
                                        
                                       
                                      
                                      
                                          <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("Id") %>' OnClick="btnEdit_Click" />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("id") %>'
                                                     OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" OnClick="btnDelete_Click" 
                                                     /> 
                                                 
                                                 
                                        </td>
                                    </tr>
                                </tbody>        
                                        </ItemTemplate>
                                    </asp:DataList>
                              <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [description], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>
                                </table>
                  
				  </div>
			    
				
			</div>
</div>
</asp:Content>

