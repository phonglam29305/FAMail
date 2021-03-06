﻿<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" 
AutoEventWireup="true" CodeFile="user-manage.aspx.cs" 
Inherits="webapp_page_backend_user_manage" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">		
                 <asp:HiddenField ID="hdfId" runat="server" /> 				
				<h3 class="fl">Quản lý người dùng</h3>
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
				        <asp:HiddenField ID="hdfUserId" runat="server" /> 
				      
				        <p>
				            <label for="full-width-input">Tên người dùng</label>
				            <asp:TextBox ID="txtUsername" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                            <em>Tài khoản này dùng để đăng nhập hệ thống !</em>
				        </p>
				        
				        <p>
				            <label for="full-width-input">Mật khẩu</label>
				            <asp:TextBox ID="txtPassword" CssClass="round default-width-input" 
                                        runat="server" TextMode="Password"></asp:TextBox>
                            <em>Để đảm bảo tính bảo mật, hệ thống sẽ tự động mã hóa mật khẩu !</em>
				        </p>
				        <p>
				            <label for="full-width-input">Nhập lại</label>
				            <asp:TextBox ID="txtRePassword" CssClass="round default-width-input" 
                                        runat="server" TextMode="Password"></asp:TextBox>
                            <em>Hãy gõ lại mật khẩu để đảm bảo rằng mật khẩu bạn đã nhớ !</em>
				        </p>

                          <p>
				            <label for="simple-input">Nhóm người dùng</label>
                               <asp:DropDownList ID="dropTypeUser" runat="server" CssClass="round default-width-input" style="height: 35px; border: 1px solid #bbbdbe; width:360px;">
                             </asp:DropDownList>
							<em>Loại nhóm người dùng! </em>		
                           <%--  <asp:DropDownList ID="drlDepartment" runat="server" 
                                CssClass="round default-width-input" 
                                style="height: 35px; border: 1px solid #bbbdbe; width:360px;" 
                                onselectedindexchanged="drlDepartment_SelectedIndexChanged" 
                                AutoPostBack="True">
                             </asp:DropDownList>--%>
				        </p>
                         <p>
							    <label for="simple-input">Khóa</label>								
                         <asp:CheckBox ID="chkBlock" runat="server" />
						    </p>
				        <p>
				             <asp:Button ID="btnSave" runat="server" Text="Lưu" 
                                CssClass="button round blue image-right ic-add text-upper" onclick="btnSave_Click" />
                           
                             <asp:Button ID="btnRefesh" runat="server" Text="Làm mới" 
                            CssClass="button round blue image-right ic-refresh text-upper" 
                          onclick="btnRefesh_Click"/>        
				        </p>
                        
				        
				    </fieldset>
			    </div>

                  	<!--end content 01-->
	  </div>
	    <div class="content-module">
	    	   
				  <div class="full-width-editor">
				        <div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách người dùng</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
				   <table>	                
				    <asp:DataList ID="dlMember" runat="server" 
                         RepeatColumns="1"  Width="100%">  
                         <HeaderTemplate>
                               <thead>            					
		                            <tr>
			                            <th>NO.</th>
			                            <th>Người dùng</th>
                                         <th>Nhóm người dùng</th> 
                                         <th>Trạng thái</th>                       		                            
			                            <th>Điều chỉnh</th>
		                            </tr>            						
	                            </thead>
                         </HeaderTemplate>                      
                         <ItemTemplate>                                      						
						            <tbody>
							            <tr>
								            <td style="text-align:left; padding-left: 10px;">								            
                                                <asp:Label ID="No" runat="server" ></asp:Label>
								            </td>
                                            <td>								            
                                                <asp:Label ID="Username" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
								            </td>
                                         	
                                           <td>								            
                                                <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
								            </td>							            
								          
								              <td>								            
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("IsBlockText") %>'></asp:Label>
								            </td>
                                            <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("UserId") %>' OnClick="btnEdit_Click"  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("UserId") %>'
                                                     OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" OnClick="btnDelete_Click" 
                                                     /> 
                                                 
                                                 
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
	  
</asp:Content>

