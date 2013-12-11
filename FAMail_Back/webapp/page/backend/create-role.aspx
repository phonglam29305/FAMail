<%@ Page Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true"
 CodeFile="create-role.aspx.cs" Inherits="webapp_page_backend_create_role" Title="Create role" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	 <script>
	     function checkAll() {
	         var checked = !$(this).data('checked');
	         $('input:checkbox').prop('checked', checked);
	         $(this).data('checked', checked);
	     }
    </script>
          
	  <div class="side-content fr">				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Phân quyền (<asp:Label ID="lblDepartmentName" runat="server" Text="" Font-Size="Large"></asp:Label>)</h3>
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

              <div class="stripe-separator"><!--  --></div>
               <p>
                <label for="simple-input">Hệ thống phân quyền FAMAIL</label>  
                <em>Lưu ý: Tùy chọn chức năng chính sẽ quyết định các chức năng chi tiết !</em> 
              </p>
              <div class="stripe-separator"><!--  --></div>

              
			  <div class="content-module-main cf"> 			        
				    <div class="half-size-column fl">			    		
					    <fieldset>  
                        <asp:HiddenField ID="hdfDepartmentId" runat="server" />
                        <p>                   
                            <asp:DataList ID="dlRoleList" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <th>
                                            <input type="checkbox" onclick="checkAll()" value = "All"  />
                                        </th>
                                        <th style="text-align: left; padding-left: 10px;">
                                            Tên quyền
                                        </th>                                    
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td style="width: 50px;">
                                            <asp:CheckBox ID="chkCheck" runat="server" />
                                            <asp:HiddenField ID="hdfRoleId" runat="server" />
                                        </td>
                                        <td style="text-align: left; padding-left: 10px;">
                                            <asp:Label ID="lblRoleName" runat="server"></asp:Label>                                            
                                        </td>                                       
                                    </tr>
                                </tbody>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:DataList>    
                        </p>              			     
				        <p>				            		
				            <asp:LinkButton ID="lbtChangeRole" runat="server" Height="15px" 
                               CssClass="button round blue image-right ic-add text-upper" 
                                Text="Thay đổi quyền" onclick="lbtChangeRole_Click">
                             </asp:LinkButton> 	
				        </p>
					    </fieldset>
					</div>
				  
                  <asp:Panel ID="PanelAdvanceRole" runat="server">                  
					<div class="half-size-column fr">
					 
					<div style="background-color: #5d6677;height:13px;
					    padding: 14px;text-transform: uppercase;color: white; margin-top:18px">
                        <asp:CheckBox ID="chkAdvance" runat="server" />  Phân quyền nâng cao
					</div> 	
					   		
					    <fieldset>  
					    
					    <div class="stripe-separator"><!--  --></div>	
					    <asp:Panel Visible="false" ID="PanelAdvance" runat="server">
                            <div class="error-box round">
                                <asp:Label ID="lblAdvanceError"  runat="server" Text=""></asp:Label> 
                            </div>
                         </asp:Panel>	
                         <asp:Panel Visible="false" ID="PanelAdvanceSuccess" runat="server">
                            <div class="confirmation-box round">
                                <asp:Label ID="lblAdvanceSuccess"  runat="server" Text=""></asp:Label> 
                            </div>
                         </asp:Panel>			        
				            <p>
							    <label for="simple-input">Hạng ngạch gửi mail</label>   
							     								
                                <asp:TextBox ID="txtLimitMailSend" Width="100px" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>&nbsp Đến ngày
                                 
                                <asp:TextBox ID="txtToDate" Width="200px" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
						    </p>
						    <div class="stripe-separator"><!--  --></div> 
						    <p>
							    <label for="simple-input">Hạng ngạch tạo khách hàng</label>    								
                                <asp:TextBox ID="txtLimitCreateCustomer" Width="100px" CssClass="round default-width-input" 
                                    runat="server"></asp:TextBox>
                                                                    
						    </p>
					        <div class="stripe-separator"><!--  --></div> 
					        <asp:LinkButton ID="lbtChangeAdvance" runat="server" Height="15px" 
                               CssClass="button round blue image-right ic-add text-upper" 
                                Text="Chấp nhận" onclick="lbtChangeAdvance_Click">
                             </asp:LinkButton> 	
					    </fieldset>
					</div>
                  </asp:Panel>
                 
			  </div>
	        </div>
	     </div>
	  </div>

<script type="text/javascript">
    $(function () {
        $('#ctl00_ctl00_ContentPlaceHolder1_ContentPlaceHolder1_txtToDate').datetimepicker({
            timeFormat: "", dateFormat: "dd/mm/yy"
        });
    });
</script> 	    
</asp:Content>

