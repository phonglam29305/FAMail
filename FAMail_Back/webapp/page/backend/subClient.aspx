

<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" 
AutoEventWireup="true" CodeFile="subClient.aspx.cs" 
Inherits="webapp_page_backend_subClient" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">		
                 <asp:HiddenField ID="hdfId" runat="server" /> 				
				<h3 class="fl">Quản lý tài khoản con</h3>
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
				            <label for="full-width-input">Tên tài khoản con</label>
				            <asp:TextBox ID="txtUsername" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                            <em>Tên tài khoản con!</em>
				        </p>
				          <p>
				            <label for="full-width-input">Email</label>
				            <asp:TextBox ID="txtEmail" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
    
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
				    <h3 class="fl">Danh sách tài khoản con</h3>
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
                                         <th>Email</th>    
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
                                                <asp:Label ID="clientName" runat="server" Text='<%# Eval("subName") %>'></asp:Label>
								            </td>
                                         	
                                            <td>								            
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("subEmail") %>'></asp:Label>
								            </td>							            
								          
								             <td>								            
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("IsBlockText") %>'></asp:Label>
								            </td>

                                      
                                             
                                              <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("subId") %>' OnClick="btnEdit_Click"  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("subId") %>'
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

