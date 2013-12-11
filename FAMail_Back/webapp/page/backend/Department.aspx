<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" 
CodeFile="Department.aspx.cs" Inherits="webapp_page_backend_Department" Title="FASTAUTOMATIC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Quản lý phân quyền</h3>
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
				    <div class="half-size-column fl" style="height:auto">					
					    <fieldset>  
						        <p>
								    <label for="full-width-input">Tên bộ phận</label>
						         	<asp:TextBox ID="txtDepartment" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								    <em>Tên của bộ phận! </em>								
							    </p>							    					
						 </fieldset>	
                         <fieldset>  
						                <p>
								            <label for="full-width-input">Nhóm người dùng</label>
						         	        <asp:DropDownList ID="dropTypeUser" runat="server" Height="30px" Width="100px">
                                            <asp:ListItem Value="0">Admin</asp:ListItem>
                                            <asp:ListItem Value="1">Client</asp:ListItem>
                                            <asp:ListItem Value="2">SubClient</asp:ListItem>
                                            </asp:DropDownList>
								            <em>Loại nhóm người dùng! </em>								
							            </p>							    					
						 </fieldset>	
    				
                         
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr" style="height:auto;">
				       		             
				    </div>
				   
				    <div class="full-width-editor" style="float: left; margin-top: 30px;">     
				       <fieldset>
				          <p>
							    <label for="simple-input">Giải thích</label>								
                                <asp:TextBox ID="txtDescription" CssClass="round default-width-input"  Width="95%"  TextMode="MultiLine" 
                                    runat="server"></asp:TextBox>
                                <em>Giải thích về những thông tin của phòng ban </em>
						    </p>						
							
				       </fieldset>
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu phòng ban" 
                                CssClass="button round blue image-right ic-add text-upper" 
                                onclick="btnSave_Click"  />	
                                                        
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
				    <h3 class="fl">Danh sách phòng ban</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
				   <table>	                
				    <asp:DataList ID="dlDepartment" runat="server" 
                         RepeatColumns="1"  Width="100%">  
                         <HeaderTemplate>
                               <thead>            					
		                            <tr>
			                            <th>NO.</th>
			                            <th>Tên phòng ban</th>
                                         <th>Nhóm người dùng</th>
			                            <th>Giải thích</th>				                            		                            
			                            <th>Option</th>
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
                                                <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
								            </td>	
                                            <td>								            
                                                <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
								            </td>							            
								            <td>
								                <asp:Label ID="Description" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
								            </td>
								            
								            <td>								           
								        	        <asp:ImageButton ID="btnDelete" runat="server" 
                                                  ImageUrl="~/webapp/resource/images/Delete-icon.png" 
                                                CommandArgument='<%# Eval("ID") %>' ToolTip="Xóa phòng ban này"                                                         
                                                        OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa phòng ban này không ?')" 
                                                        onclick="btnDelete_Click"   />
                                                        
                                                <asp:HyperLink ID="hplSettingRole" runat="server"                                                      
                                                     ImageUrl="~/webapp/resource/images/settings.png" 
                                                     ToolTip="Thay đổi quyền" 
                                                        NavigateUrl='<%# "create-role.aspx?departmentId="+Eval("ID") %>'></asp:HyperLink>
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

