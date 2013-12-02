<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/SendMail.master" AutoEventWireup="true" 
CodeFile="list-content-mail.aspx.cs" Inherits="webapp_page_backend_create_content_mail"
 Title="FASTAUTOMATICMAIL " ValidateRequest="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="side-content fr">
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
        <div class="content-module">
		        <div class="content-module-heading cf">				
				    <h3 class="fl">Danh sách nôi dung thư</h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->			
    	           
                
         <div class="content-module-main">
            <%--<form  runat="server">--%>
              <table>
              <asp:DataList ID="dtlContentMail" runat="server">
                 <HeaderTemplate>

                  <thead>
                    <tr style="font-size: 0.8em;">
                    	
			            <th style="width:200px;">Ngày tạo</th>
			            <th>Tiêu đề</th>
			           
			            <th style="width:150px;">Chức năng</th>
		            </tr>	
	                </thead>
                	
                    </HeaderTemplate>
                <ItemTemplate>

                 <tbody>
    	           <tr>
        			
			        <td> 
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                              ImageUrl="~/webapp/resource/images/menu-dark-indicator.png"  /> <asp:Label ID="lblCreateDate" runat="server" 
                            Text='<%# Eval("CreateDate") %>' ></asp:Label>
			          </td>
			        <td><asp:Label ID="lblSubject" runat="server"  Text='<%# Eval("Subject") %>' ></asp:Label></td>
			        
			        <td style="width:150px;">
				        <asp:ImageButton ID="btnPreview" runat="server"   
                            ImageUrl="~/webapp/resource/images/Preview-icon.png" 
                            ToolTip="Bạn click vào đây để xem trước nội dung thư với các trình duyệt mail" 
                            onclick="btnPreview_Click" CommandArgument='<%# Eval("Id") %>' />
                            
                            
                              <asp:ImageButton ID="btnEdit" runat="server"   
                            ImageUrl="~/webapp/resource/images/edit-validated-icon.png" 
                            PostBackUrl='<%#"~/webapp/page/backend/CreateContentMail.aspx?id=" + Eval("Id")%>' ToolTip="Click để sửa chữa nội dung mail" />
                          
				        <asp:ImageButton ID="btnSend" runat="server"   
                            ImageUrl="~/webapp/resource/images/Status-mail-unread-new-icon.png" CommandArgument='<%# Eval("Id") %>' 
				         
                            PostBackUrl='<%# "~/webapp/page/backend/send-register.aspx?SendContenID=" + Eval("Id") %>' ToolTip="Click vào đây để lựa chọn nội dung gửi!" />
				        <asp:ImageButton ID="btnDelete" runat="server" 
                              ImageUrl="~/webapp/resource/images/Delete-icon.png" OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa nội dung này không ?')" 
                            CommandArgument='<%# Eval("id") %>' onclick="btnDelete_Click" ToolTip="Click để xóa nội dung này!"  />
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
          <%-- </form>--%>
               </div> <!-- end content-module-main -->					
		   </div>
		</div>	
</asp:Content>

