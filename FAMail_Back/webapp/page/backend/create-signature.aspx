<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master" AutoEventWireup="true"
 CodeFile="create-signature.aspx.cs" Inherits="webapp_page_backend_CreateContentMail" Title="FASTAUTOMATICMAIL"
  ValidateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="side-content fr">
  <div class="content-module">
	         
		        <div class="content-module-heading cf">				
				    <h3 class="fl">Tạo chữ ký</h3>
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
			                				  
        				<asp:HiddenField ID="hdfId" runat="server" />       				

                    <p>
                        <label for="full-width-input">Tên chữ ký:</label>
                        <asp:TextBox ID="txtSignatureName" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
                    </p>
			         <p>
                         <label for="full-width-input">Nội dung chữ ký</label>			     
			                <asp:TextBox ID="txtBody" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                          <%--<asp:TextBox ID="txtBody" rows="15" style="width: 100%" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                     </p>
                
                    <p>
                         <div class="stripe-separator"><!--  --></div>    	
                							
                        <asp:Button ID="btnSaveContent" runat="server" Text="Lưu" 
                            CssClass="button round blue image-right ic-add text-upper" 
                          onclick="btnSaveContent_Click"/>	 
                           
                          <asp:Button ID="btnCreateNew" runat="server" Text="Tạo mới" 
                            CssClass="button round blue image-right ic-add text-upper" onclick="btnCreateNew_Click" 
                          />	                            
                    </p>

                    <div class="full-width-editor">
				       <table>	                
				    <asp:DataList ID="dlSignature" runat="server" 
                         RepeatColumns="1"  Width="100%">  
                         <HeaderTemplate>
                               <thead>            					
		                            <tr>
			                            <th>No.</th>
			                            <th>Tên chữ ký</th>			                           
			                            <th>Thao tác</th>
		                            </tr>            						
	                            </thead>
                         </HeaderTemplate>                      
                         <ItemTemplate>                                      						
						            <tbody>
							            <tr>
							                <td>								            
                                                <asp:Label ID="lblNo" runat="server" Text="ConfigId"></asp:Label>
								            </td>
								            <td>								            
                                                <asp:LinkButton ID="lbtSubject" runat="server" Width="200px"></asp:LinkButton>
								            </td>                                            			            
								            <td>
								                <asp:LinkButton ID="lbtEdit" runat="server" Height="15px" 
                                                     Width="15px" onclick="lbtEdit_Click"></asp:LinkButton>
								                <asp:LinkButton ID="lbtDelete" runat="server" Height="15px" 
								                OnClientClick="return confirmDelete('Nếu tiếp tục dữ liệu sẽ bị xóa khỏi hệ thống ?')"
                                                    Width="15px" onclick="lbtDelete_Click"></asp:LinkButton>
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
	        </div>    	      
</div>	  
                           
</asp:Content>

