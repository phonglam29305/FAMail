<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/template/backend/management.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" Inherits="webapp_page_backend_Package" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="side-content fr">
				         
	  <!--start content 01-->
		<div class="content-module">
		    <div class="content-module-heading cf">				
				<h3 class="fl">Thông tin gói dịch vụ</h3>
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
								    <label for="full-width-input">Tên gói dịch vụ</label>
						         	<asp:TextBox ID="txtEmailConfig" CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								  
							    <p>
								    <label for="full-width-input">Diễn giải</label>
								     <asp:TextBox ID="txtPassword"  CssClass="round default-width-input"   TextMode="MultiLine" 
                                        runat="server"></asp:TextBox>
								    							
							    </p>
							    <p>
								    <label for="full-width-input">Số tài khoản con </label>
								     <asp:TextBox ID="txtConfilmPassword"  CssClass="round default-width-input" 
                                        runat="server"></asp:TextBox>
								    							
							    </p>

                             
							    	       <br />       <br />				
						    </fieldset>	
    				
				    </div> <!-- end half-size-column -->
				    <div class="half-size-column fr" style="height: 170px;">
				        <fieldset>
				              <p>
                                     <label for="simple-input">Giới hạn mail</label>
                             <asp:DropDownList ID="drlDepartmen" runat="server" CssClass="round default-width-input" style="height: 35px; border: 1px solid #bbbdbe; width:360px;">
                             </asp:DropDownList>
                           
                             <br />
				                   </p>						
							
						   
						        <p>
							    <label for="simple-input">Kích hoạt</label>								
                         <asp:CheckBox ID="chkIsSSL" runat="server" />
                               
						    </p>
						     
								
				        </fieldset>				             
				    </div> 
				    <div class="full-width-editor" style="float: left; margin-top: 30px;">  
				          
				         <br />
                       <fieldset>
        							
                            <asp:Button ID="btnSave" runat="server" Text="Lưu cấu hình" 
                                CssClass="button round blue image-right ic-add text-upper" 
                                  />	
                            <asp:Button ID="btnTest" runat="server" Text="Kiểm tra" 
                                CssClass="button round blue image-right ic-refresh text-upper" 
                                  Visible="False" />                            
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
				    <h3 class="fl">Danh sách chức năng </h3>
				    <span class="fr expand-collapse-text">Thu vào</span>
				    <span class="fr expand-collapse-text initial-expand">Mở ra</span>			
			    </div> <!-- end content-module-heading -->	
				   <%--<table>	                --%>
				  <%--  <table>--%>
                                    <asp:DataList ID="dtfunction" runat="server" RepeatColumns="1" Width="100%">
                                        <HeaderTemplate>
                                            <thead>
                                                <tr>
                                                    
                                                    <th>  Tên chức năng </th>
                                                    <th>  Đơn Giá  </th>
                                                    <th>  Mặc định </th>
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
                                            <asp:Label ID="lblAttr" runat="server" Text='<%# Eval("functionName") %>' ></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("cost") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblYahooMail" runat="server" Text='<%# Eval("isDefault") %>'></asp:Label>
                                        </td>
                                       
                                      
                                      
                                          <td>
                                             
                                              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/webapp/resource/images/edit-validated-icon.png"
                                              CommandArgument='<%# Eval("functionId") %>'  />
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/webapp/resource/images/Delete-icon.png"
                                                    CommandArgument='<%# Eval("functionId") %>'
                                                     OnClientClick="return confirmDelete('Bạn có chắc rằng sẽ xóa thuộc tính này không ?')" 
                                                     /> 
                                                 
                                                 
                                        </td>
                                    </tr>
                                </tbody>        
                                        </ItemTemplate>
                                    </asp:DataList>
                              <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\sqlexpress;Initial Catalog=SendMailVersion3;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [functionId], [functionName], [cost], [diengiai], [isDefault] FROM [tblFunction] ORDER BY [functionId], [functionId], [functionId]"></asp:SqlDataSource>--%>
                                </table>
                  
				  </div>
				
			</div>
	    </div>
</asp:Content>

