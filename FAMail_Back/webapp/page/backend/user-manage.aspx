<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/user.master" 
AutoEventWireup="true" CodeFile="user-manage.aspx.cs" 
Inherits="webapp_page_backend_user_manage" Title="FASTAUTOMATICMAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
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
				            <label for="simple-input">Chọn phòng ban</label>
                             <asp:DropDownList ID="drlDepartment" runat="server" 
                                CssClass="round default-width-input" 
                                style="height: 35px; border: 1px solid #bbbdbe; width:360px;" 
                                onselectedindexchanged="drlDepartment_SelectedIndexChanged" 
                                AutoPostBack="True">
                             </asp:DropDownList>
                             <em>Thành viên sẽ chịu ảnh hưởng quyền của phòng ban này !</em>
				        </p>
				        
				        <p>
				            <label for="full-width-input">Tài khoản</label>
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
				             <asp:Button ID="btnSave" runat="server" Text="Lưu tài khoản" 
                                CssClass="button round blue image-right ic-add text-upper" onclick="btnSave_Click" />
                              <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" 
                                CssClass="button round blue image-right ic-add text-upper" 
                                 onclick="btnUpdate_Click" />
                                 <asp:Button ID="btnAddNew" runat="server" Text="Thêm mới" 
                                CssClass="button round blue image-right ic-add text-upper" onclick="btnAddNew_Click" 
                                 />
				        </p>
				    </fieldset>
			    </div>
			    <div class="half-size-column fr" style="height: 450px;">
			        <fieldset>
			              <table>	                
				            <asp:DataList ID="dlMember" runat="server" 
                                 RepeatColumns="1"  Width="100%" CellPadding="4" ForeColor="#333333">  
                                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                 <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                 <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                 <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                 <HeaderTemplate>
                                       <thead>            					
		                                    <tr>			                                    
			                                    <th>Tài khoản</th>
			                                    <%--<th>Mật khẩu</th>--%>
			                                    <th>Phòng ban</th>	
			                                    <th>Tùy chọn</th>                              
		                                    </tr>            						
	                                    </thead>
                                 </HeaderTemplate>                      
                                 <ItemTemplate>                                      						
						                    <tbody>
							                    <tr>								                    
                                                    <td>								            
                                                        <asp:Label ID="lblUsername" style="-moz-hyphens: auto;-ms-hyphens: auto;-webkit-hyphens: auto;hyphens: auto;word-wrap: break-word;padding: 5px;" runat="server" Text=""></asp:Label>
								                    </td>
        								            
								                    <%--<td>
                                                        <asp:Label ID="lblPassword" style="-moz-hyphens: auto;-ms-hyphens: auto;-webkit-hyphens: auto;hyphens: auto;word-wrap: break-word;padding: 5px;" runat="server"  Text="" ></asp:Label>
								                    </td>--%>
								                    <td>
                                                        <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
								                    </td>
								                    <td colspan="2">     								           
								        	                
                                                         <asp:LinkButton ID="lbtEdit" runat="server" 
                                                           CssClass="table-actions-button ic-table-edit"
                                                            Width="15px" Height="15px"                                                    
                                                             onclick="lbtEdit_Click" /> 
                                                             
                                                          <asp:LinkButton ID="lbtDelete" runat="server" 
                                                           CssClass="table-actions-button ic-table-delete"
                                                            Width="15px" Height="15px"                                                                
                                                             OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa tài khoản hình này không ?')" 
                                                             onclick="lbtDelete_Click" />  
                                                        <asp:LinkButton ID="lbtViewDetail" runat="server">Xem chi tiết</asp:LinkButton>                                                             
                                                          
								                    </td>
								                 
        								            
							                    </tr>             						
						                    </tbody>            						
        					            
                                     
                                 </ItemTemplate>
                                 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
			        </fieldset>
				</div>
			  </div>
		     </div>
		     
		  </div>
     </div>

</asp:Content>

